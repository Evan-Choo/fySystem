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

namespace FY
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fyjobspath = "c:\\test.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int totalTasks = 0;
            
            FileStream fs = new FileStream(fyjobspath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            //去除第一行的表头
            string s = sr.ReadLine();
            while ((s = sr.ReadLine())!= null){
                totalTasks++;
            }

            Console.WriteLine(totalTasks);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int runningTasks = 0;

            FileStream fs = new FileStream(fyjobspath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

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

                string[] strings = (string[])al.ToArray(typeof(string));
                if (strings[1].Equals("RUN"))
                    runningTasks++;
            }

            Console.WriteLine(runningTasks);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int pendingTasks = 0;

            FileStream fs = new FileStream(fyjobspath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

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

                string[] strings = (string[])al.ToArray(typeof(string));
                if (strings[1].Equals("PEND"))
                    pendingTasks++;
            }

            Console.WriteLine(pendingTasks);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int PGSs = 0;

            FileStream fs = new FileStream(fyjobspath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

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

                string[] strings = (string[])al.ToArray(typeof(string));
                if (strings[3].Contains("PGS"))
                    PGSs++;
            }

            Console.WriteLine(PGSs);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            int DSSs = 0;

            FileStream fs = new FileStream(fyjobspath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

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

                string[] strings = (string[])al.ToArray(typeof(string));
                if (strings[3].Contains("DSS"))
                    DSSs++;
            }

            Console.WriteLine(DSSs);
        }
    }
}
