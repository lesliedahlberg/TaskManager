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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Task> items;
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<Task>();
            items.Add(new Task() { Title = "John Doe", Text = "..." });
            items.Add(new Task() { Title = "Jane Doe", Text = "..." });
            items.Add(new Task() { Title = "Sammy Doe", Text = "..." });
            taskListView.ItemsSource = items;
        }
        public class Task
        {
            public string Title { get; set; }

            public string Text { get; set; }

            public override string ToString()
            {
                return this.Title + ": " + this.Text;
            }
        }

        private void addTask()
        {
            AddDialog addDialog = new AddDialog();
            if(addDialog.ShowDialog() == true)
            {
                items.Add(new Task() { Title = addDialog.TaskTitle, Text = addDialog.TaskText });
            }
        }

        private void removeTask(int id)
        {
            if (items != null && id != -1)
            {
                items.RemoveAt(id);
            }
           
        }

        private void AddCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            addTask();
        }

        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            removeTask(taskListView.SelectedIndex);
        }

    }
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Add = new RoutedUICommand
            (
                "Add",
                "Add",
                typeof(CustomCommands)
            );

        public static readonly RoutedUICommand Remove = new RoutedUICommand
            (
                "Remove",
                "Remove",
                typeof(CustomCommands)
            );
    }
}
