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

namespace EpicProjects.View
{
        /// <summary>
        /// Interaction logic for ProjectWindow.xaml
        /// </summary>
        public partial class ProjectWindow : Window
        {
                public Project _project { get; set; }

                public TextBlock _nameBlock { get; set; }
                public TextBlock _startBlock { get; set; }
                public TextBlock _startDate { get; set; }

                public TextBlock _endBlock { get; set; }
                public TextBlock _endDate { get; set; }


                public ProjectWindow(string name)
                {
                        InitializeComponent();

                        _project = new Project(name);                        

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = _project._name;
                        _nameBlock.FontSize = 30;

                        _startBlock = new TextBlock();
                        _startBlock.Text = "Commence le ";
                        _startDate = new TextBlock();
                        _startDate.Text = _project._startDate;

                        _endBlock = new TextBlock();
                        _endBlock.Text = "S'arrete le";
                        _endDate = new TextBlock();
                        _endDate.Text = _project._endDate;

                        StackPanel panel = new StackPanel();
                        panel.Orientation = Orientation.Vertical;

                        panel.Children.Add(_nameBlock);
                        panel.Children.Add(_startBlock);
                        panel.Children.Add(_startDate);
                        panel.Children.Add(_endBlock);
                        panel.Children.Add(_endDate);

                        ProjectGrid.Children.Add(panel);

                }//ProjetWindow()

        }//class ProjectWindow
}//ns
