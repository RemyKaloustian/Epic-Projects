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
        /// Interaction logic for Project.xaml
        /// </summary>
        public partial class Project : Window
        {
                public string _currentProject { get; set; }

                public int _id { get; set; } 

                public DatabaseGuru _g = new DatabaseGuru();

                public Project()
                {
                        InitializeComponent();
                        ShowProjects();


                }


                public void SetHeader(string name, int id)
                {
                        _currentProject = name;
                        _id = id;
                        HeaderText.Text = name;
                }


                public void ShowProjects()
                {

                        Database.DatabaseGuru gu = new Database.DatabaseGuru();


                        List<object> res = gu._propSelector.Select("name", "project");

                        foreach (var item in res)
                        {
                                DebugText.Inlines.Add(item.ToString() + "\n");
                        }
                }

                private void CreateButton_Click(object sender, RoutedEventArgs e)
                {
                       // _g._propInserter.InsertTask()


                }

                private void CreateTask()
                {

                }
        }
}
