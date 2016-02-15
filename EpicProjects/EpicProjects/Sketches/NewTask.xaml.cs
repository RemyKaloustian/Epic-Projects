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

using EpicProjects.Database;

namespace EpicProjects.Sketches
{
        /// <summary>
        /// Interaction logic for NewTask.xaml
        /// </summary>
        public partial class NewTask : Window
        {
                public int id { get; set; }

                public NewTask(int id)
                {
                        InitializeComponent();
                }

                private void CreateButton_Click(object sender, RoutedEventArgs e)
                {
                        DatabaseGuru g = new DatabaseGuru();

                       // g._propInserter.InsertTask(TextButton.Text, Deadline.SelectedDate, "formation");
                }
        }
}
