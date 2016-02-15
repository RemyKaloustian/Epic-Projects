using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using EpicProjects.Constants;

namespace EpicProjects.View.CustomControls
{
        public class DefaultMenuPanel : StackPanel
        {
                public Button _newProjectButton { get; set; }
                public Button _openProjectButton { get; set; }

                public DefaultMenuPanel()
                {
                        _newProjectButton = new Button();
                         _newProjectButton.Content = ControlsValues.NEWPROJECT;

                         _openProjectButton = new Button();
                         _openProjectButton.Content = ControlsValues.OPENPROJECT;

                         this.Orientation = Orientation.Vertical;

                         this.Children.Add(_newProjectButton);
                         this.Children.Add(_openProjectButton);
                }//DefaultMenuPanel()

        }//class DefaultMenuPanel
}//ns
