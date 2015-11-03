using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DaTaTemplae1
{
    public class s_文本操作
    {
        public static string RandomText(int Qun)
        {
            string g = "";
            byte[] array = new byte[1];
            Random a = new Random();
            for (; Qun > 0; Qun--)
            {
                array[0] = (byte)(Convert.ToInt32(a.Next(65, 90)));
                g = g + System.Text.Encoding.Default.GetString(array);
            }
            return g;
        }
        /// <summary>
        /// 取文本中间的内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="leftstr"></param>
        /// <param name="rightstr"></param>
        /// <returns></returns>
        public static string Between(string str, string leftstr, string rightstr)//取中间文本_子
        {

            try
            {
                int i = str.IndexOf(leftstr);
                i = i + leftstr.Length;
                string temp = str.Substring(i, str.IndexOf(rightstr, i) - i);
                return temp;
            }
            catch
            {
                return "";
            }

        }
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
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
        private DispatcherTimer timer;
        public MainWindow()
        {
            
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window1_Loaded);
            list();
            //MessageBox.Show( System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
            //MessageBox.Show( File.Exists(@"Only.png").ToString());
            
          
        }
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Ssgx();
        }
        private void Ssgx()
        {
            ArrayList pid1 = new ArrayList();
            Process[] b = Process.GetProcesses();
            int y = 0;
            //查找新建的进程
            if (b.Length > a.Length)
            {
                for (int i = 0; i < b.Length; i++)
                {
                    pid1.Add(b[i].Id);
                    for (int i1 = 0; i1 < a.Length; i1++)
                    {
                        if (Convert.ToInt32(pid1[y]) == a[i1].Id)
                        {
                            pid1.RemoveAt(y);
                            y--;
                            break;
                        }
                    }
                    y++;
                }
                y = 0;

                for (int i = 0; i < b.Length; i++)
                {

                    if (Convert.ToInt32(pid1[y]) == b[i].Id)
                    {
                        pid1.RemoveAt(y);
                        try
                        {

                            ss.Add(new { ImgPath = GetIcon(b[i].MainModule.FileName), coke = "#800080", ProcessNamea = b[i].ProcessName, PrTH = b[i].MainModule.FileName, PDid = b[i].Id, Tiele1 = b[i].MainWindowTitle });
                        }
                        catch
                        {

                            ss.Add(new { ProcessNamea = b[i].ProcessName, coke = "#326939", ImgPath = imgprth + @"\Only.png", PrTH = "       ", PDid = b[i].Id, Tiele1 = b[i].MainWindowTitle }

                                );
                        }
                    }

                    if (pid1.Count == 0)
                    {
                        break;
                    }

                }

            }
            y = 0;
            //删除已结束的进程
                if (b.Length < a.Length)
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        pid1.Add(a[i].Id);
                        for (int i1 = 0; i1 < b.Length; i1++)
                        {
                            if (Convert.ToInt32(pid1[y]) == b[i1].Id)
                            {
                                pid1.RemoveAt(y);
                                y--;
                                break;
                            }
                        }
                        y++;
                    }
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (pid1.Count == 0)
                        {
                            break;
                        }
                        
                        if (Convert.ToInt32(pid1[0]) == a[i].Id)
                        {
                            for (int nd = 0; nd < this.listViewProcess.Items.Count; nd++)
                            {
                                y = Convert.ToInt32(s_文本操作.Between(this.listViewProcess.Items[nd].ToString(), "PDid = ", ", Tiele1"));
                                if (y == Convert.ToInt32(pid1[0]))
                                {
                                    ss.RemoveAt(ss.IndexOf(this.listViewProcess.Items[nd]));
                                    break;
                                }
                            }

                            pid1.RemoveAt(0);

                        }

                    }

                }
            
            a = b;
            GridView1.Columns[4].Header = "进程路径   [" + a.Length.ToString() + "]";

        }
        ObservableCollection<object> ss = new ObservableCollection<object>();
        //public ObservableCollection<object> ObservableObj;
        public static string imgprth = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);


        public Process[] a;
        public void list()
        {
            ss.Clear();
            this.listViewProcess.DataContext= ss;
            a = Process.GetProcesses();
            

            foreach (Process u in a)
            {
                try
                {

                    ss.Add(new { ProcessNamea = u.ProcessName, coke = "#800080", ImgPath = GetIcon(u.MainModule.FileName), PrTH = u.MainModule.FileName, PDid = u.Id, Tiele1 = u.MainWindowTitle });
                }
                catch
                {

                    ss.Add(new { ProcessNamea = u.ProcessName, coke = "#326939", ImgPath = imgprth + @"\Only.png", PrTH = "       ", PDid = u.Id, Tiele1 = u.MainWindowTitle }
                    
                        );
                }
            }
                
            this.listViewProcess.DataContext = ss;
            
        }
        public static ImageSource GetIcon(string fileName)
        {

            System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height),
                        BitmapSizeOptions.FromEmptyOptions());
        }

        private void ProceName_GotFocus_1(object sender, RoutedEventArgs e)
        {
            TextBlock gg = e.OriginalSource as TextBlock;
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;    //起始值
            da.To = 1;      //结束值
            da.Duration = TimeSpan.FromSeconds(2);         //动画持续时间
            gg.BeginAnimation(TextBlock.OpacityProperty, da);//开始动画

            ThicknessAnimation ta = new ThicknessAnimation();
            ta.From = new Thickness(200, 0, 0, 0);             //起始值
            ta.To = new Thickness(0,0 , 0, 0);        //结束值
            ta.Duration = TimeSpan.FromSeconds(1);         //动画持续时间
            gg.BeginAnimation(TextBlock.MarginProperty, ta);//开始动画
            //ListViewItem fafa = this.listViewProcess.SelectedItem as ListViewItem;
            ContentPresenter cp = gg.TemplatedParent as ContentPresenter;
            
            object y = cp.Content as object;
            ListViewItem lvi = this.listViewProcess.ItemContainerGenerator.ContainerFromItem(y) as ListViewItem;
            
            //MessageBox.Show(y.ToString());

           // TextBlock fa = fafa.FindName("Prth") as TextBlock;
        }




        private ChildType FindVisualChild<ChildType>(DependencyObject obj) where ChildType : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChildren = FindVisualChild<ChildType>(child);
                    if (childOfChildren != null)
                    {
                        return childOfChildren;
                    }
                }
            }
            return null;

        }
        /// <summary> 
        /// 获得指定元素的所有子元素 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="obj"></param> 
        /// <returns></returns> 
        public List<T> GetChildObjects<T>(DependencyObject obj) where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();

            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);

                if (child is T)
                {
                    childList.Add((T)child);
                }
                childList.AddRange(GetChildObjects<T>(child));
            }
            return childList;
        }
        private void UID(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Image IMA = e.OriginalSource as Image;
                ContentPresenter cp = IMA.TemplatedParent as ContentPresenter;
                ListViewItem lvi = this.listViewProcess.ItemContainerGenerator.ContainerFromItem(cp.Content) as ListViewItem;
                Canvas oioi = FindVisualChild<Canvas>(lvi);


                StackPanel St = FindVisualChild<StackPanel>(lvi);
                if (FindVisualChild<ListView>(St) != null)
                {
                    ListView UIDlist = FindVisualChild<ListView>(St);
                   
                    St.Children.Remove(UIDlist);

                    this.GridView1.Columns[0].Width = 50;
                }
                else
                {
                    ListView UIDlist = new ListView();
                    UIDlist.Width = 1000;
                    this.GridView1.Columns[0].Width = 1100;
                    
                    UIDlist.Name = "UIDlist";
                    object u = cp.Content;
                    int Pid = Convert.ToInt32(s_文本操作.Between(this.listViewProcess.SelectedItem.ToString(), "PDid = ", ", Tiele1"));
                    for (int y = 0; y <= a.Length; y++)
                    {
                        if (a[y].Id == Pid)
                        {
                            ProcessThreadCollection o = a[y].Threads;
                            ListViewItem item = new ListViewItem();
                            item.Height = 25;
                            item.Background = Brushes.Orange;
                            item.Content = "UID             StartAddress            PriorityBoostEnabled         PriorityLevel          PrivilegedProcessorTime                       StartTime            ThreadState           WaitReason ";
                            UIDlist.Items.Add(item);
                            UIDlist.Height = o.Count + 170;

                            for (int t = 0; y < o.Count; t++)
                            {
                                if (t == o.Count)
                                {
                                    break;
                                }
                                item = new ListViewItem();
                                item.Content = string.Format("{0}             {1}            {2}         {3}          {4}                       {5}            {6}           {7}", o[t].Id.ToString(), o[t].StartAddress.ToString(), o[t].PriorityBoostEnabled.ToString(), o[t].PriorityLevel.ToString(), o[t].PrivilegedProcessorTime.ToString(), o[t].StartTime.ToString(), o[t].ThreadState.ToString(), o[t].WaitReason.ToString());
                                UIDlist.Items.Add(item);
                            }



                            St.Children.Add(UIDlist);

                            DoubleAnimation da = new DoubleAnimation();
                            da.From = 0;    //起始值
                            da.To = 1;      //结束值
                            da.Duration = TimeSpan.FromSeconds(2);         //动画持续时间
                            UIDlist.BeginAnimation(TextBlock.OpacityProperty, da);//开始动画

                            lvi.BeginAnimation(TextBlock.OpacityProperty, da);//开始动画


                            ThicknessAnimation ta = new ThicknessAnimation();
                            ta.From = new Thickness(-200, 0, 0, 0);             //起始值
                            ta.To = new Thickness(0, 0, 0, 0);        //结束值
                            ta.Duration = TimeSpan.FromSeconds(1);         //动画持续时间
                            lvi.BeginAnimation(TextBlock.MarginProperty, ta);//开始动画

                            ta.From = new Thickness(400, 0, 0, 0);             //起始值
                            ta.To = new Thickness(0, 0, 0, 0);        //结束值
                            ta.Duration = TimeSpan.FromSeconds(2);         //动画持续时间
                            UIDlist.BeginAnimation(TextBlock.MarginProperty, ta);//开始动画
                            return;
                        }

                    }

                }
            }
            catch { }
                /*自绘标签和按钮方案
                {
                    if (FindVisualChild<TextBlock>(St) != null)
                    {
                        TextBlock i = FindVisualChild<TextBlock>(St);
                        St.Children.Remove(i);
                        St.UnregisterName("i");
                    }
                    else
                    {

                        TextBlock UID = new TextBlock();
                        UID.Text = "UID    ";
                        UID.Name = "i";
                        UID.Width = 50;
                        UID.Height = 50;
                        St.RegisterName("i", UID);
                        St.Children.Add(UID);

                        TextBlock yxj = new TextBlock();
                        yxj.Text = "优先级";
                        yxj.Name = "yxj";
                        yxj.Width = 100;
                        St.Children.Add(yxj);
                    }
                }*/
           
        }
        private void listdh()
        {
            List<ListViewItem> j = GetChildObjects<ListViewItem>(this.listViewProcess);
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;    //起始值
            da.To = 1;      //结束值
            ThicknessAnimation ta = new ThicknessAnimation();
            double i = 1;
            Random ran = new Random();
            int RandKey = ran.Next(-150,150);
            foreach (ListViewItem h in j)
            {
                RandKey = ran.Next(-150, 150);
                i = i + 0.3;
                da.Duration = TimeSpan.FromSeconds(i);         //动画持续时间

                h.BeginAnimation(TextBlock.OpacityProperty, da);//开始动画

                ta.From = new Thickness(RandKey, 0, 0, 0);             //起始值
                ta.To = new Thickness(0, 0, 0, 0);        //结束值
                ta.Duration = TimeSpan.FromSeconds(i);         //动画持续时间
                h.BeginAnimation(TextBlock.MarginProperty, ta);//开始动画
            }
        }
        private void listViewProcess_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            listdh();
        }

        private void listViewProcess_Loaded(object sender, RoutedEventArgs e)
        {
            listdh();
        }


        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Pid = 0;
                Pid = Convert.ToInt32(s_文本操作.Between(this.listViewProcess.SelectedItem.ToString(), "PDid = ", ", Tiele1"));
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i].Id == Pid)
                    {
                        a[i].Kill();
                        return;
                    }
                }
            }
            catch { }

        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window h = (Window)sender;
            DoubleAnimation da;

            /*
            DoubleAnimationUsingKeyFrames dak = new DoubleAnimationUsingKeyFrames();
            //关键帧定义
            dak.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
            dak.KeyFrames.Add(new LinearDoubleKeyFrame(240, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))));
            dak.KeyFrames.Add(new LinearDoubleKeyFrame(240, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6))));
            dak.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(9))));

            dak.BeginTime = TimeSpan.FromSeconds(2);//从第2秒开始动画
            dak.RepeatBehavior = new RepeatBehavior(3);//动画重复3次
            //开始动画
           h.BeginAnimation(Border.WidthProperty, dak);
            */
            da = new DoubleAnimation();
            da.From = h.Height;    //起始值
            da.To = 1;      //结束值
            da.Duration = TimeSpan.FromSeconds(1);         //动画持续时间
            h.BeginAnimation(TextBlock.HeightProperty, da);//开始动画

            da.From = h.Width;    //起始值
            da.To = 1;      //结束值
            da.Duration = TimeSpan.FromSeconds(2);         //动画持续时间
            h.BeginAnimation(TextBlock.WidthProperty, da);//开始动画

            MessageBox.Show(h.Name);

            System.Environment.Exit(0); 

        }

        public static int PPID = 1;
        private void Moke_Click(object sender, RoutedEventArgs e)
        {

            PPID = Convert.ToInt32(s_文本操作.Between(listViewProcess.SelectedItem.ToString(), "PDid = ", ", Tiele1"));
            Mokuai u = new Mokuai();
            u.Show();
        }
        public static string ProcessName = "";
        private void Liul_Click(object sender, RoutedEventArgs e)
        {
            PPID = Convert.ToInt32(s_文本操作.Between(listViewProcess.SelectedItem.ToString(), "PDid = ", ", Tiele1"));
           
            ProcessName = s_文本操作.Between(listViewProcess.SelectedItem.ToString(), "ProcessNamea = ",",");
            Netstat u = new Netstat();
            u.Show();
        }

        private void listViewProcess_MouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }


        public static int Brush1 = 0;
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

        private void ser_Click_1(object sender, RoutedEventArgs e)
        {
            PPID = Convert.ToInt32(s_文本操作.Between(listViewProcess.SelectedItem.ToString(), "PDid = ", ", Tiele1"));
            ProcessName = s_文本操作.Between(listViewProcess.SelectedItem.ToString(), "ProcessNamea = ", ",");
            Service u = new Service();
            u.Show();
        }






    }

   /* public class SuProcessg
    {
    
        ImageSource ImgPath{get;set;}
        string ProcessNamea { get; set; }
    }*/
   

}
