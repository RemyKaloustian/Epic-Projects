using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using EpicProjects.Controller;
using EpicProjects.Constants;

namespace EpicProjects.View.CustomControls
{
        
       
        public class ProjectsPanel : StackPanel
        {

                public Button _quitButton { get; set; }

                public List<Button> _projectsList { get; set; }

                public ProjectsPanel(List<object> projectNames)
                {
                        this.Orientation = Orientation.Vertical;
                        _projectsList = new List<Button>();

                        foreach (var item in projectNames)
                        {
                                Button but = new Button();
                                but.Content = item.ToString();
                                _projectsList.Add(but);
                                this.Children.Add(but);
                        }

                        _quitButton = new Button();
                        _quitButton.Content = ControlsValues.QUIT;
                        this.Children.Add(_quitButton);


                }//ProjectsPanel()

               


        }//class ProjectsPanel()
}//ns
