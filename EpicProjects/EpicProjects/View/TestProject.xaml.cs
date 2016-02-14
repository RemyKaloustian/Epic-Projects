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

using EpicProjects.Model;

namespace EpicProjects.MVP
{
        /// <summary>
        /// Interaction logic for TestProject.xaml
        /// </summary>
        public partial class TestProject : Window
        {
                public Project _project { get; set; }

                public string _currentPhase { get; set; }

                public TestProject()
                {
                        InitializeComponent();

                        _project = new Project();
                }

                private void FormationsButton_Click(object sender, RoutedEventArgs e)
                {

                        _currentPhase = "formations";
                        ResultText.Inlines.Clear();

                        List<string> res = _project._formations;

                        foreach (string item in res)
                        {
                                ResultText.Inlines.Add("\n" + item);
                        }
                }

                private void TasksButton_Click(object sender, RoutedEventArgs e)
                {
                        _currentPhase = "tasks";
                        ResultText.Inlines.Clear();

                        List<string> res = _project._tasks;

                        foreach (string item in res)
                        {
                                ResultText.Inlines.Add("\n" + item);
                        }
                }

                private void MaintenanceButton_Click(object sender, RoutedEventArgs e)
                {
                        _currentPhase = "maintenances";

                        ResultText.Inlines.Clear();

                        List<string> res = _project._maintenances;

                        foreach (string item in res)
                        {
                                ResultText.Inlines.Add("\n" + item);
                        }
                }

                private void AddButton_Click(object sender, RoutedEventArgs e)
                {
                       // if(_currentPhase == "formations")
                                
                }
        }
}
