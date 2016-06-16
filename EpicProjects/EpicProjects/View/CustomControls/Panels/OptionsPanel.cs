using EpicProjects.Constants;
using EpicProjects.Database;
using EpicProjects.View.CustomControls.Buttons;
using EpicProjects.View.CustomControls.Home;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class OptionsPanel : StackPanel
        {

                public DefaultButton _sortButton { get; set; }
                public DefaultButton  _showDoneButton{ get; set; }
                public OptionsPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = ThemeSelector.GetBackground();

                        _sortButton = new DefaultButton("Sort",this.Width/2,this.Height/20, new System.Windows.Thickness(0,20,0,0),new System.Windows.Thickness(0,0,0,0),HorizontalAlignment);


                        _showDoneButton = new DefaultButton("Show done", this.Width / 2, this.Height / 20, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), HorizontalAlignment);
                        _showDoneButton.MouseDown += _showDoneButton_MouseDown;
                       

                        this.Children.Add(_sortButton);
                        this.Children.Add(_showDoneButton);
                }

                void _showDoneButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if(_showDoneButton._block.Text == "Show done")
                        {
                                _showDoneButton._block.Text = "Hide done";
                                Preferences.SetShowDone(true);
                        }
                        else
                        {
                                _showDoneButton._block.Text = "Show done";
                                Preferences.SetShowDone(false);

                        }
                }//_showDoneButton_MouseDown()




        }//class OptionsPanel
}//ns
