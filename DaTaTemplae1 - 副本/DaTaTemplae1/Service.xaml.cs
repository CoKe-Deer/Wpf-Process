using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ServiceProcess;
using System.Diagnostics;
namespace DaTaTemplae1
{
    /// <summary>
    /// Service.xaml 的交互逻辑
    /// </summary>
    public partial class Service : Window
    {
        ObservableCollection<object> services1 = new ObservableCollection<object>();
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
        public Service()
        {
            InitializeComponent();
            list(0);
        }
        ServiceController[] services;
        void list( int a)
        {
            services1.Clear();
            if (a == 0)
            {
                services = ServiceController.GetServices();
                int y = 0;
                foreach (ServiceController sController in services)
                {
                    services1.Add(new { DisplayName = sController.DisplayName, ServiceName = sController.ServiceName, Status = sController.Status });
                    y++;
                }
                ServiceList.DataContext = services1;
            }
            else {
            services = ServiceController.GetDevices();

                foreach (ServiceController sController in services)
                {
                    
                    services1.Add(new { DisplayName = sController.DisplayName, ServiceName = sController.ServiceName, Status = sController.Status });
                }
                ServiceList.DataContext = services1;
            }
            
            
        
        }

        private void ServiceList_MouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void sx_Click_1(object sender, RoutedEventArgs e)
        {
            list(5);
        }

        private void sx1_Click(object sender, RoutedEventArgs e)
        {
            list(0);
        }


    }
}
