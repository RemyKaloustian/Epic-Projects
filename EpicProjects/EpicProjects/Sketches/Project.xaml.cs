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

namespace EpicProjects.Sketches
{
        /// <summary>
        /// Interaction logic for Project.xaml
        /// </summary>
        public partial class Project : Window
        {
                public string _currentProject { get; set; }

                public Project()
                {
                        InitializeComponent();
                        ShowProjects();


                }


                public void SetHeader(string name)
                {
                        _currentProject = name;
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
        }
}
