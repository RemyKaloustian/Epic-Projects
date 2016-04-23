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

       
        public class SingleTaskPanel : StackPanel
        { 
                public Model.Task _task { get; set; }

                public TextBlock _content { get; set; }
                public bool _isSelected { get; set; }

                /// <summary>
                /// This constructor is used for SingleAdvancedTaskPanel, cuz in SingleAdvancedTaskPanel, we already have an AdvancedTask in constructor, so no need of parameters here
                /// </summary>
                public SingleTaskPanel()
                {
                        this.Margin = new System.Windows.Thickness(10, 2, 0, 1);

                        this.MinHeight = Dimensions.GetHeight() / 20;
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.Background = ThemeSelector.GetBackground();
                        SetUpContent();
                        this.Children.Add(_content);
                }


                public SingleTaskPanel(Model.Task task)
                {
                        this.Margin = new System.Windows.Thickness(10, 2, 0, 1);

                        this.MinHeight = Dimensions.GetHeight() / 20;
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.Background = ThemeSelector.GetBackground();
                        _task = task;

                        SetUpContent();

                        _content.Text = _task._name;

                        this.Children.Add(_content);
                }


                private void SetUpContent()
                {
                        _content = new TextBlock();
                        _content.FontFamily = FontProvider._lato;
                        _content.FontSize = 20;
                        _content.Foreground = ThemeSelector.GetAccentColor();
                        _content.Margin = new System.Windows.Thickness(10, 0, 0, 0);
                        _content.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                }            

                internal void TriggerHover()
                {
                        this.Background = ThemeSelector.GetAccentColor();
                        _content.Foreground = ThemeSelector.GetBackground();
                }

                internal void UnHover()
                {
                        this.Background = ThemeSelector.GetBackground();
                        _content.Foreground = ThemeSelector.GetAccentColor();
                }

        }//class SingleTaskPanel
}//ns
