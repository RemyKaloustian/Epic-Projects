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

                public DefaultMenuPanel()
                {
                        _newProjectButton = new Button();
                         _newProjectButton.Content = ControlsValues.NEWPROJECT;

                         this.Orientation = Orientation.Vertical;

                         this.Children.Add(_newProjectButton);
                }//DefaultMenuPanel()

        }//class DefaultMenuPanel
}//ns
