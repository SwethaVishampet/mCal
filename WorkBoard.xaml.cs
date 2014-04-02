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
using System.Windows.Shapes;

namespace cs2103_project_UI_logic
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WorkBoard : Window
    {
        Window ScribblePad = new Window();

        public WorkBoard()
        {
            InitializeComponent();
            
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e )
        {
            Application.Current.Shutdown();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ScribblePad.Show();
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
