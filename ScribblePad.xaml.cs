using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace cs2103_project_UI_logic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        WorkBoard WorkBoard = new WorkBoard();
        Ez_link ezlinkObject = new Ez_link();
        List<string> commands_entered = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            WindowStyle = WindowStyle.None;
            textBox2.IsEnabled = false;
        }

        public void messageBoxDisplay(string message)
        {
            MessageBox.Show(message);
        }
       
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //listBox1.Items.Clear();
            if (e.Key == Key.Return)
            {

                //listBox1.IsEnabled = true;
                //listBox1.Items.Add(textBox1.Text);
                
                //textBox1.Width=233;
                //textBox1.Height = 29;
                commands_entered.Add(textBox1.Text);
                if (ezlinkObject.identifyCommand(textBox1.Text))
                {
                    textBox1.Clear();
                    //listBox1.Items.Clear();
                    
                    display();
                    tasknamecheck();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Command");
                    textBox1.Clear();
                }
            }
            
        }
        public void tasknamecheck()
        {
            if (ezlinkObject.getTaskname() == "edit")
            {
               
                {
                    textBox1.IsEnabled = false;
                    textBox2.IsEnabled = true;
                    textBox2.Focus();
                }
                
                
            }
           
        }

        public void display()
        {
            bool isDisplay=false;
            List<string> concatenatedString = new List<string>();
               concatenatedString= ezlinkObject.getConcatenatedString(ref isDisplay);
               //listBox1.Items.Clear();
            if (isDisplay)
            {
                for (int i = 0; i < concatenatedString.Count(); i++)
                {
                    listBox1.Items.Add(concatenatedString[i]);
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // textBox1.Visibility = Visibility.Hidden;
            Storage tempObj = new Storage();
            tempObj.read_from_file(ref commands_entered);
            int i = 0;
            while (commands_entered.Count() != 0 && i < commands_entered.Count())
            {
                textBox1.Text = commands_entered[i++].ToString();
                
                if (ezlinkObject.identifyCommand(textBox1.Text))
                {
                    textBox1.Clear();
                    tasknamecheck();
                }
               
                textBox1.Clear();
            }
            textBox1.Visibility = Visibility.Visible;
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Storage tempObj = new Storage();
            tempObj.write_to_file(commands_entered);
            Application.Current.Shutdown();
        }

        public void button3_Click_1(object sender, RoutedEventArgs e)
        {
            WorkBoard.Show();
           
        }
  
        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
           // listBox1.Items.Clear();
            if (e.Key == Key.Enter)
            {
                if (textBox2.Text != null)
                    ezlinkObject.edit(textBox2.Text);
                display();
            }

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
    }
}
