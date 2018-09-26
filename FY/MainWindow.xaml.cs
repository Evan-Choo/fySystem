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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace FY
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fyjobspath = "c:\\test.txt";
        private string fyhostspath = "c:\\hosts.txt";
        private string fymetapath = "c:\\meta.txt";
        private static string[] hostsNeedToBeWatched = {"fy4ahpdss1",
                                                        "fy4ahpdss2",
                                                        "fy4ahppgs1",
                                                        "fy4ahppgs2",
                                                        "fy4ahppgsrs1",
                                                        "fy4ahppgsrs2",
                                                        "fy4ahppgsrs3",
                                                        "fy4ahppgsrs4",
                                                        "fy4ahppgsrs5",
                                                        "fy4ahppgsrs6",
                                                        "fy4ahppgsrs7",
                                                        "fy4ahppgsrs8",
                                                        "arss3",
                                                        "arss4"
                                                       };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.textbox1.Clear();

            int totalTasks = 0;

            StreamReader streamReader;
            getReader("fyjobs", out streamReader);

            //去除表头
            string s = streamReader.ReadLine();

            while ((s = streamReader.ReadLine())!= null){
                totalTasks++;
                this.textbox1.Text += s + "\n";
            }

            Console.WriteLine(totalTasks);
            this.textbox1.Text += totalTasks.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.textbox1.Clear();

            int runningTasks = 0;

            StreamReader sr;
            getReader("fyjobs", out sr);

            //去除表头
            string s = sr.ReadLine();

            while((s=sr.ReadLine())!=null)
            {
                string[] splits = s.Split(' ');
                ArrayList al = new ArrayList();

                foreach(string a in splits)
                {
                    if(a.Length!=0)
                        al.Add(a);
                }

                if (al[1].Equals("RUN"))
                    runningTasks++;
            }

            Console.WriteLine(runningTasks);
            this.textbox1.Text += runningTasks.ToString();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.textbox1.Clear();

            int pendingTasks = 0;

            StreamReader sr;
            getReader("fyjobs", out sr);

            //去除表头
            string s = sr.ReadLine();

            while ((s = sr.ReadLine()) != null)
            {
                string[] splits = s.Split(' ');
                ArrayList al = new ArrayList();

                foreach (string a in splits)
                {
                    if (a.Length != 0)
                        al.Add(a);
                }

                if (al[1].Equals("PEND"))
                    pendingTasks++;
            }

            Console.WriteLine(pendingTasks);
            this.textbox1.Text += pendingTasks.ToString();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.textbox1.Clear();

            int PGSs = 0;

            StreamReader sr;
            getReader("fyjobs", out sr);

            //去除表头
            string s = sr.ReadLine();

            while ((s = sr.ReadLine()) != null)
            {
                string[] splits = s.Split(' ');
                ArrayList al = new ArrayList();

                foreach (string a in splits)
                {
                    if (a.Length != 0)
                        al.Add(a);
                }

                if (((string)al[3]).Contains("PGS"))
                    PGSs++;
            }

            Console.WriteLine(PGSs);
            this.textbox1.Text += PGSs.ToString();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            this.textbox1.Clear();

            int DSSs = 0;

            StreamReader sr;
            getReader("fyjobs", out sr);

            //去除表头
            string s = sr.ReadLine();

            while ((s = sr.ReadLine()) != null)
            {
                string[] splits = s.Split(' ');
                ArrayList al = new ArrayList();

                foreach (string a in splits)
                {
                    if (a.Length != 0)
                        al.Add(a);
                }

                if (((string)al[3]).Contains("DSS"))
                    DSSs++;
            }

            Console.WriteLine(DSSs);
            this.textbox1.Text += DSSs.ToString();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ArrayList hosts = new ArrayList(hostsNeedToBeWatched);

            StreamReader sr;
            getReader("fyhosts", out sr);

            //去除表头
            string s = sr.ReadLine();

            this.textbox1.Clear();
            while ((s = sr.ReadLine()) != null)
            {
                string[] splits = s.Split(' ');
                ArrayList al = new ArrayList();

                foreach(string a in splits)
                {
                    if (a.Length != 0)
                        al.Add(a);
                }

                string color = (al[1].Equals("ok") || ((string)al[1]).Contains("close")) ? "green" : "red";
                //this.textbox1.Clear();
                if (hosts.Contains(al[0]))
                {
                    Console.WriteLine(al[0] + " " + color + " " + al[3] + " " + al[4]);
                    this.textbox1.Text += al[0] + " " + color + " " + al[3] + " " + al[4]+"\n";
                }
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr;
            getReader("fymaster", out sr);

            string version, server;

            string line = sr.ReadLine();
            version = line.Substring(line.IndexOf("is") + 3);

            line = sr.ReadLine();
            server = line.Substring(line.IndexOf("is") + 3);

            Console.WriteLine(version + " " + server);
            this.textbox1.Clear();
            this.textbox1.Text = version + " " + server;
        }

        private void getReader(string cmd, out StreamReader streamReader)
        {
            using (Process p = new Process())
            {
                cmd = cmd + "&exit";

                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
                p.Start();//启动程序
                //向cmd窗口写入命令
                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;

                //获取cmd窗口;的输出信息
                streamReader = p.StandardOutput;//截取输出流

                //去除冗余信息
                string line = streamReader.ReadLine();
                for (int i = 0; i < 4; i++)
                {
                    this.textbox1.Text += line + "\n";
                    line = streamReader.ReadLine();
                }

                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
            }
        }
    }


}
