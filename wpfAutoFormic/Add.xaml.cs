using System;
using System.Collections.Generic;
using System.IO;
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

namespace wpfAutoFormic
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MyLabel.Content = MyTextBox.Text;
            string text = MyTextBox.Text;
            string name = TextName.Text;

            string path = @"..\..\data\data.txt";

            string[] lines = GetAllLines();

            string last = lines[lines.Length - 1];

            string[] split = last.Split('|');

            int num = Int32.Parse(split[0]);

            int newNum = num + 1;

            string newLine = newNum.ToString() + "|" + text + "|" + name + "\r\n";

            File.AppendAllText(path, newLine);

            MainWindow m = new MainWindow();

            this.Close();
            m.ShowDialog();

            

        }

        private string[] GetAllLines()
        {
            string path = @"..\..\data\data.txt";
            string[] lines = File.ReadAllLines(path);

            return lines;
        }
    }
}
