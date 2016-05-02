using EpicProjects.Constants;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class HeaderPanel : StackPanel
        {
                public TitlesPanel _titlesPanel { get; set; }
                public StackPanel _plusPanel { get; set; }

                public HeaderPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.9;
                        //this.Height = Dimensions.GetHeight() * 0.2;

                        _titlesPanel = new TitlesPanel();

                        this.Children.Add(_titlesPanel);

                        this.HighlightBrainstorming();
                }


                public void HighlightBrainstorming()
                {
                        UnHighlight();
                        _titlesPanel._brainstormingItem.Background = ThemeSelector.GetAccentColor();
                        _titlesPanel._brainstormingItem._content.Foreground = ThemeSelector.GetBackground();


                }//HighlightBrainstorming()

                public void HighlightTraining()
                {
                        UnHighlight();
                        _titlesPanel._trainingItem.Background = ThemeSelector.GetAccentColor();
                        _titlesPanel._trainingItem._content.Foreground = ThemeSelector.GetBackground();
                }

                public void HighlightAssignments()
                {
                        UnHighlight();
                        _titlesPanel._assignmentsItem.Background = ThemeSelector.GetAccentColor();
                        _titlesPanel._assignmentsItem._content.Foreground = ThemeSelector.GetBackground();


                }

                public void HighlightMaintenance()
                {
                        UnHighlight();
                        _titlesPanel._maintenanceItem.Background = ThemeSelector.GetAccentColor();
                        _titlesPanel._maintenanceItem._content.Foreground = ThemeSelector.GetBackground();


                }

                public void UnHighlight()
                {
                        _titlesPanel._brainstormingItem.Background = ThemeSelector.GetBackground();
                        _titlesPanel._brainstormingItem._content.Foreground = ThemeSelector.GetAccentColor();

                        _titlesPanel._trainingItem.Background = ThemeSelector.GetBackground();
                        _titlesPanel._trainingItem._content.Foreground = ThemeSelector.GetAccentColor();

                        _titlesPanel._assignmentsItem.Background = ThemeSelector.GetBackground();
                        _titlesPanel._assignmentsItem._content.Foreground = ThemeSelector.GetAccentColor();

                        _titlesPanel._maintenanceItem.Background = ThemeSelector.GetBackground();
                        _titlesPanel._maintenanceItem._content.Foreground = ThemeSelector.GetAccentColor();


                }
        }//class HeaderPanel
}//ns
