using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class TitlesPanel : StackPanel
        {
                public HeaderItem _brainstormingItem { get; set; }
                public HeaderItem _trainingItem { get; set; }
                public HeaderItem _assignmentsItem { get; set; }
                public HeaderItem _maintenanceItem { get; set; }


                public TitlesPanel()
                {
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.Width = Dimensions.GetWidth() * 0.9;
                       // this.Height = Dimensions.GetWidth() * 0.2;

                        this.Background = new Theme.CustomTheme().GetAccentColor();
                        _brainstormingItem = new HeaderItem(ControlsValues.BRAINSTORMING);

                        _trainingItem = new HeaderItem(ControlsValues.TRAINING);

                        _assignmentsItem = new HeaderItem(ControlsValues.ASSIGNMENTS);

                        _maintenanceItem = new HeaderItem(ControlsValues.MAINTENANCE);

                        this.Children.Add(_brainstormingItem);
                        this.Children.Add(_trainingItem);
                        this.Children.Add(_assignmentsItem);
                        this.Children.Add(_maintenanceItem);

                }

        }//class TitlesPanel
}//ns
