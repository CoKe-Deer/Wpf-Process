using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using SharpPcap;
using PacketDotNet;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;
using System.Collections;
using System.Windows.Threading;

namespace DaTaTemplae1
{

    /// <summary>
    /// Netstat.xaml 的交互逻辑
    /// </summary>
    public partial class Netstat : Window
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
        Thread t;
        public Netstat()
        {
            InitializeComponent();
            int Pid = 0;
            MainWindow Main = new MainWindow();
            Pid = MainWindow.PPID;
            ProcInfo.ProcessID = Pid;
             t = new Thread(new ThreadStart(list));
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
            for (int i = 0; i < SendLine.Count; i++)
            {
                SendLine.RemoveAt(i);
                
            }
            ReadLine.Clear();
 
        }

        void list()
        {
            ye();
            hy();
            
        }
        private delegate void SetTextx(string Txtxt, bool y);
        private void SetTextxHh(string Txtxt, bool y)                                      //委托访问接口
        {

            SetTextx d = ShowMessage;
            this.Dispatcher.Invoke(d, Txtxt, y);
        }

        private void ShowMessage(string msg, bool y)                                                 //要让主线程完成的事情
        {
            if (y)
            {
                TILLE.Content = TILLE.Content + msg;
            }
            else { TILLE.Content = msg; }

        }   

        private delegate void CanvasAdd1();
        private void CanvasAdd()  
        {
            CanvasAdd1 d =CanvasAdd2;
            Canvas1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, d);

        }
        private void CanvasAdd2()
        {
            Line Reav = new Line();
            Line ReavSYG;

            Line Send = new Line();
            Line SendSYG;
            if (ReadLine.Count == 0)
            {
                Reav.X1 = 0;
                Reav.Y1 = 10;
                if (R == 0)
                {
                    Reav.X2 = 5;
                    Reav.Y2 = 15;
                }
                else
                {
                    Reav.X2 =Reav.X1+ (R/10);
                    Reav.Y2 = -(Reav.X2 + 10);
                }
            }
            else {
                ReavSYG = (Line)ReadLine[ReadLine.Count - 1];
                Reav.X1 = ReavSYG.X2;
                Reav.Y1 = ReavSYG.Y2;
                if (R == 0)
                {
                    Reav.X2 = ReavSYG.X1 + 5;
                    Reav.Y2 = Reav.X2 + 10;
                }
                else
                {
                    Reav.X2 = Reav.X1 + (R/10) ;
                    Reav.Y2 = -(Reav.X2 + 10);
                }

                //调整线条位置
                if (Reav.X2 > 200)
                {
                    for (int i = 0; i < ReadLine.Count; i++)
                    {
                        Line u = ReadLine[i];
                        Canvas1.Children.Remove(u);

                    }
                    ReadLine.Clear();
                    return;
                }
            }


            if (SendLine.Count == 0)
            {
                
                Send.X1 = 0;
                Send.Y1 = 10;
                if (S == 0)
                {
                    Send.X2 = 5; //长度
                    Send.Y2 = 15; //下降
                }
                else
                {
                    Send.X2 = Send.X1+ (S / 4); //长度
                    Send.Y2 = -(Send.X2 + 10); //上升
                }

            }
            else
            {

                SendSYG = (Line)SendLine[SendLine.Count - 1];
                Send.X1 = SendSYG.X2;
                Send.Y1 = SendSYG.Y2;
                if (S == 0)
                {
                    Send.X2 = SendSYG.X1 + 5; //长度
                    Send.Y2 = Send.X2 + 10; //下降

                }
                else {
                    Send.X2 = Send.X1 + (S/4); //长度
                    Send.Y2 = -(Send.X2 + 10); //上升
                }
                //调整线条位置
                if (Send.X2 > 200)
                {
                    for (int i = 0; i < SendLine.Count; i++)
                    {
                        Line u = SendLine[i];
                        Canvas1.Children.Remove(u);
                        
                    }
                    SendLine.Clear();
                    return;
                    
                }
              
            }

            
            BrushConverter ie = new BrushConverter();
            Brush brush = (Brush)ie.ConvertFromString("#DC143C");
            Send.Stroke = brush;
            Send.StrokeThickness = 3;
            Canvas.SetTop(Send, 200);
            SendLine.Add(Send);

            brush = (Brush)ie.ConvertFromString("#4682B4");
            Reav.Stroke = brush;
            Reav.StrokeThickness = 3;
            Canvas.SetTop(Reav, 180);
            ReadLine.Add(Reav);

            Debug.WriteLine(ProcInfo.CpuTime);
            Canvas1.Children.Add(Reav);
            Canvas1.Children.Add(Send);
                //this.stakpanal1.Children.Add(element);
        }
        List<Line> SendLine =new List<Line>(); //上传

        List<Line> ReadLine = new List<Line>(); //下载
        long S;
        long R;
        void hy()
        {
            
            while (true)
            {

                 S = ProcInfo.NetSendBytes / 1024;
                 R = ProcInfo.NetRecvBytes / 1024;
                 CanvasAdd();
                
                // SendLine.Add(Send);
                 //CanvasAdd(Send);
                
                
                SetTextxHh("Netstat "+MainWindow.ProcessName+"  总额:" + Convert.ToString(ProcInfo.NetTotalBytes / 1024) + "  上传:" + Convert.ToString(S) + "  下载:" + Convert.ToString(R), false);

                Thread.Sleep(500);
                //每隔1s调用刷新函数对性能参数进行刷新
                RefershInfo();
            }
        }
        //记录特定进程性能信息的类
        public class ProcessPerformanceInfo : IDisposable
        {
            public int ProcessID { get; set; }//进程ID
            public string ProcessName { get; set; }//进程名
            public float PrivateWorkingSet { get; set; }//私有工作集(KB)
            public float WorkingSet { get; set; }//工作集(KB)
            public float CpuTime { get; set; }//CPU占用率(%)
            public float IOOtherBytes { get; set; }//每秒IO操作（不包含控制操作）读写数据的字节数(KB)
            public int IOOtherOperations { get; set; }//每秒IO操作数（不包括读写）(个数)
            public long NetSendBytes { get; set; }//网络发送数据字节数
            public long NetRecvBytes { get; set; }//网络接收数据字节数
            public long NetTotalBytes { get; set; }//网络数据总字节数
            public List<ICaptureDevice> dev = new List<ICaptureDevice>();

            /// <summary>
            /// 实现IDisposable的方法
            /// </summary>
            public void Dispose()
            {
                foreach (ICaptureDevice d in dev)
                {
                    d.StopCapture();
                    d.Close();
                }
            }
        }
        public ProcessPerformanceInfo ProcInfo = new ProcessPerformanceInfo();

        public void ye()
        {
            //进程id
            int pid = ProcInfo.ProcessID;
            //存放进程使用的端口号链表
            List<int> ports = new List<int>();

            #region 获取指定进程对应端口号
            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.CreateNoWindow = true;
            pro.Start();
            pro.StandardInput.WriteLine("netstat -ano");
            pro.StandardInput.WriteLine("exit");
            Regex reg = new Regex("\\s+", RegexOptions.Compiled);
            string line = null;
            ports.Clear();
            while ((line = pro.StandardOutput.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith("TCP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr[4] == pid.ToString())
                    {
                        string soc = arr[1];
                        int pos = soc.LastIndexOf(':');
                        int pot = int.Parse(soc.Substring(pos + 1));
                        ports.Add(pot);
                    }
                }
                else if (line.StartsWith("UDP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr[3] == pid.ToString())
                    {
                        string soc = arr[1];
                        int pos = soc.LastIndexOf(':');
                        int pot = int.Parse(soc.Substring(pos + 1));
                        ports.Add(pot);
                    }
                }
            }
            pro.Close();
            #endregion

            //获取本机IP地址
            IPAddress[] addrList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            string IP = addrList[0].ToString();
            //获取本机网络设备
            var devices = CaptureDeviceList.Instance;
            int count = devices.Count;
            if (count < 1)
            {
                Console.WriteLine("No device found on this machine");
                return;
            }

            //开始抓包
            for (int i = 0; i < count; ++i)
            {
                SetTextxHh("Netstat  正在初始化网卡  " + i.ToString() + "/" + count.ToString(),false);
                for (int j = 0; j < ports.Count; ++j)
                {
                    CaptureFlowRecv(IP, ports[j], i);
                    CaptureFlowSend(IP, ports[j], i);
                }
            }

        }

        
        public void CaptureFlowSend(string IP, int portID, int deviceID)
        {
            ICaptureDevice device = (ICaptureDevice)CaptureDeviceList.New()[deviceID];

            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrivalSend);

            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            string filter = "src host " + IP + " and src port " + portID;
            device.Filter = filter;
            device.StartCapture();
            ProcInfo.dev.Add(device);
        }

        public void CaptureFlowRecv(string IP, int portID, int deviceID)
        {
            ICaptureDevice device = CaptureDeviceList.New()[deviceID];
            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrivalRecv);

            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            string filter = "dst host " + IP + " and dst port " + portID;
            device.Filter = filter;
            device.StartCapture();
            ProcInfo.dev.Add(device);
        }
        private void device_OnPacketArrivalSend(object sender, CaptureEventArgs e)
        {
            var len = e.Packet.Data.Length;
            ProcInfo.NetSendBytes += len;
        }

        private void device_OnPacketArrivalRecv(object sender, CaptureEventArgs e)
        {
            var len = e.Packet.Data.Length;
            ProcInfo.NetRecvBytes += len;
        }

        /// <summary>
        /// 实时刷新性能参数
        /// </summary>
        public void RefershInfo()
        {
            ProcInfo.NetRecvBytes = 0;
            ProcInfo.NetSendBytes = 0;
            ProcInfo.NetTotalBytes = 0;
            Thread.Sleep(1000);
            ProcInfo.NetTotalBytes = ProcInfo.NetRecvBytes + ProcInfo.NetSendBytes;
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProcInfo.Dispose();
            t.Abort();
        }
    }
}
