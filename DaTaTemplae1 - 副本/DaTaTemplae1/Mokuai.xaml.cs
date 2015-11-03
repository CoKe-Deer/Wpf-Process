using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DaTaTemplae1
{
    /// <summary>
    /// Mokuai.xaml 的交互逻辑
    /// </summary>
    public partial class Mokuai : Window
    {
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else { this.WindowState = WindowState.Maximized; }
            e.Handled = true;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            e.Handled = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            e.Handled = true;
        }
        private void StackPanel_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Normal;
                this.DragMove();
            }
            e.Handled = true;
        }

        ObservableCollection<object> Mok = new ObservableCollection<object>();
        public Mokuai()
        {
            InitializeComponent();
            BrushConverter ie = new BrushConverter();
            Brush brush;
            if (MainWindow.Brush1 == 1)
            {
                brush = (Brush)ie.ConvertFromString("#FF747378");
                Grid1.Background = brush;
                MainWindow.Brush1 = 0;
            }
            else {
                brush = (Brush)ie.ConvertFromString("#156aba");
                Grid1.Background = brush;
                MainWindow.Brush1 = 1;
            }
            list();
           
        }
        public static ImageSource GetIcon(string fileName)
        {

            System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height),
                        BitmapSizeOptions.FromEmptyOptions());
        }
        public List<T> GetChildObjects<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();
            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if (child is T && (((T)child).Name == name || string.IsNullOrEmpty(name)))
                {
                    childList.Add((T)child);
                }
                childList.AddRange(GetChildObjects<T>(child, ""));//指定集合的元素添加到List队尾  
            }
            return childList;
        }  
        private void listdh()
        {
            try
            {
                List<ListViewItem> j = GetChildObjects<ListViewItem>(this.Mok1, "");
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0;    //起始值
                da.To = 1;      //结束值
                ThicknessAnimation ta = new ThicknessAnimation();
                double i = 1;
                Random ran = new Random();
                int RandKey = ran.Next(-150, 150);
                foreach (ListViewItem h in j)
                {
                    RandKey = ran.Next(-150, 150);
                    i = i + 0.3;
                    da.Duration = TimeSpan.FromSeconds(i);         //动画持续时间

                    h.BeginAnimation(TextBlock.OpacityProperty, da);//开始动画

                    ta.From = new Thickness(200, 0, 0, 0);             //起始值
                    ta.To = new Thickness(0, 0, 0, 0);        //结束值
                    ta.Duration = TimeSpan.FromSeconds(i);         //动画持续时间
                    h.BeginAnimation(TextBlock.MarginProperty, ta);//开始动画
                }
            }
            catch { }
        }

        private void list()
        {
            int Pid = 0;
            MainWindow Main = new MainWindow();
            ProcessModuleCollection b;
            Pid = MainWindow.PPID;
            for (int i = 0; i < Main.a.Length; i++)
            {
                if (Main.a[i].Id == Pid)
                {
                    b = Main.a[i].Modules;
                    for (int i1 = 0; i1 < b.Count; i1++)
                    {
                        
                        try
                        {
                            Mok.Add(new { ImgMo = GetIcon(b[i1].FileName), Moname = b[i1].ModuleName, Banben=b[i1].FileVersionInfo, CCAll = b[i1].EntryPointAddress, PAATH = b[i1].FileName });
                        }
                        catch {
                            try
                            {
                                Mok.Add(new { ImgMo = MainWindow.imgprth + @"\Only.png", Moname = b[i1].ModuleName, Banben = b[i1].FileVersionInfo, CCAll = b[i1].EntryPointAddress, PAATH = b[i1].FileName });
                            }
                            catch { }
                        }
                        
                        
                    }
                    this.Mok1.DataContext = Mok;
                    break;
                }
            }
            
        }

        private void Mok1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            listdh();
        }

        private void Mok1_Loaded(object sender, RoutedEventArgs e)
        {
            listdh();
        }
    }
}
