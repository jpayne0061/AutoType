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
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using wpfAutoFormic;


namespace wpfAutoFormic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            

            //Process notepad = Process.GetProcessesByName("notepad").SingleOrDefault();

            //Icon ico = System.Drawing.Icon.ExtractAssociatedIcon(notepad.MainModule.FileName);

            //System.Windows.Controls.Image img = new System.Windows.Controls.Image();

            //img.Source = ico.ToBitmap().ToBitmapImage();

            //gridMain.Children.Add(img);

        }


        private void NavToAdd(object sender, RoutedEventArgs e)//By Prince Jain 
        {
            Add window1 = new Add();
            this.Visibility = Visibility.Hidden;
            this.Close();
            // window1.Show(); // Win10 tablet in tablet mode, use this, when sub Window is closed, the main window will be covered by the Start menu.
            window1.ShowDialog();
            
        }

        private string[] GetAllLines()
        {
            string path = @"..\..\data\data.txt";
            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        private void Show_Names(object sender, RoutedEventArgs e)
        {

            string[] lines = GetAllLines();

            for (var i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split('|');

                System.Windows.Application.Current.MainWindow.Height += 25;

                System.Windows.Controls.Button MyControl1 = new System.Windows.Controls.Button();
                //use enum here instead of magic number
                MyControl1.Content = line[1];
                MyControl1.Name = line[2].Replace(" ", "");
                MyControl1.Click += button1_Click;

                gridMain.RowDefinitions.Add(new RowDefinition());

                //Grid.SetColumn(MyControl1, );
                Grid.SetRow(MyControl1, i + 5);

                gridMain.Children.Add(MyControl1);
                //gridMain.Height = new GridLength(0, GridUnitType.Pixel);
            }

        }


        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);


        private void button1_Click(object sender, EventArgs e)
        {
            string name = ((System.Windows.Controls.Button)sender).Name;

            string[] lines = GetAllLines();


            string line = lines.Where(l => l.Split('|')[2].Replace(" ", "") == name).SingleOrDefault();

            string text = line.Split('|')[1];

            //Process notepad = Process.GetProcessesByName("notepad").SingleOrDefault();

            //if (notepads.Length == 0) return;
            //if (notepad != null)
            //{
                //IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), "Edit", null);

                Thread.Sleep(3000);

                SendKeys.SendWait(text);


            //}
        }


        //private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        //}

        //private void pnlMainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        //{

        //}

        //private void btnClickMe_Click(object sender, RoutedEventArgs e)
        //{
        //    lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
        //    lbResult.Items.Add(this.FindResource("strWindow").ToString());
        //    lbResult.Items.Add(Application.Current.FindResource("strApp").ToString());
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string s = null;
        //    try
        //    {
        //        s.Trim();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //    s.Trim();
        //}
    }
}
