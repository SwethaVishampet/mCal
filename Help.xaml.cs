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
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
            listBox1.Items.Add("The list of commands available are shown below with example usage");
            listBox1.Items.Add("");
            listBox1.Items.Add("1.Add");
            listBox1.Items.Add("2.Delete");
            listBox1.Items.Add("3.Edit");
            listBox1.Items.Add("4.Search");
            listBox1.Items.Add("5.Mark");
            listBox1.Items.Add("6.Clear");
            listBox1.Items.Add("7.Undo");
            listBox1.Items.Add("8.Redo");
            listBox1.Items.Add("9.Star");
            listBox1.Items.Add("1.Add");
            listBox1.Items.Add("");
            listBox1.Items.Add("add; \"Rotaract meeting at YIH\";-dt 9/10/2011");
            listBox1.Items.Add("The commands, task description and the tags are separated by a ; and the task description is given within double quotes");
            listBox1.Items.Add("");
            listBox1.Items.Add("2.Delete");
            listBox1.Items.Add("delete;\"meeting\";-dt 9/10/2011");
            listBox1.Items.Add("The tasks with the word meeting on the specified date(9/10/2011) are displayed and the user then gives the delete command to delete the required tasks as follows");
            listBox1.Items.Add("1,2 is written by the user in another textbox");
            listBox1.Items.Add("this deletes the tasks numbered 1 and 2 in the display results");
            listBox1.Items.Add("");
            listBox1.Items.Add("3.Edit");
            listBox1.Items.Add("edit;\"meeting\";-dt 9/10/2011");
            listBox1.Items.Add("works the same way as delete, except that users uses edit command instead");
            listBox1.Items.Add("");
            listBox1.Items.Add("4.Search");
            listBox1.Items.Add("search;\"meeting\";-dt 9/10/2011");
            listBox1.Items.Add("displays all the tasks with the word meeting and on that specified date");
            listBox1.Items.Add("");
            listBox1.Items.Add("5.Mark");
            listBox1.Items.Add("mark;\"meeting\";-dt 9/10/2011");
            listBox1.Items.Add("works the same way as delete and edit except that user has to use mark command");
            listBox1.Items.Add("");
            listBox1.Items.Add("6.Clear");
            listBox1.Items.Add("Clears all the tasks in the calender when the user types clear; in the textbox");
            listBox1.Items.Add("");
            listBox1.Items.Add("7.Undo");
            listBox1.Items.Add("undo; is the command which undoes the last volatile command and infinite undoes are possbile");
            listBox1.Items.Add("");
            listBox1.Items.Add("8.Redo");
            listBox1.Items.Add("redo; is the command which redoes the last undone command");
            listBox1.Items.Add("");
            listBox1.Items.Add("9.Star");
            listBox1.Items.Add("star;\"meeting\";-dt 9/10/2011");
            listBox1.Items.Add("works the same way as delete , edit except that user has to use star command");
            listBox1.Items.Add("");
            listBox1.Items.Add("The following are the list of tags that the user can use");
            listBox1.Items.Add("");
            listBox1.Items.Add("1.-dt(specifies date)");
            listBox1.Items.Add("2.-enddt(specifies events ending on the given date )");
            listBox1.Items.Add("3.-t(specifies events starting at the given time)");
            listBox1.Items.Add("4.-b4t(specifies events before the given time)");
            listBox1.Items.Add("5.-at(specifies events at and after given time + 1 hour)");
            listBox1.Items.Add("6.-stat(specifies events starting at the given time)");
            listBox1.Items.Add("7.-endat(specifies events ending at the given time)");
            listBox1.Items.Add("8.-s(the particular task is starred(while adding the task)");


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
