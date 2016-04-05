using EpicProjects.Constants;
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

                public Border _checkBoxBorder { get; set; }
                public StackPanel _checkBox { get; set; }

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
                        this.Background = new Theme.CustomTheme().GetAccentColor();


                        SetUpCheckBox();

                        SetUpContent();

                        this.Children.Add(_checkBoxBorder);
                        this.Children.Add(_content);
                }

                private void SetUpContent()
                {
                        _content = new TextBlock();
                        _content.FontFamily = FontProvider._lato;
                        _content.FontSize = 20;
                        _content.Foreground = new Theme.CustomTheme().GetBackground();
                        _content.Margin = new System.Windows.Thickness(10, 0, 0, 0);
                        _content.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                }

                private void SetUpCheckBox()
                {
                        _checkBox = new StackPanel();
                        _checkBox.Background = new Theme.CustomTheme().GetAccentColor();

                        _checkBoxBorder = new Border();
                        _checkBoxBorder.Width = Dimensions.GetWidth() * 0.02;
                        _checkBoxBorder.Height = Dimensions.GetWidth() * 0.02;
                        _checkBoxBorder.Margin = new System.Windows.Thickness(10, 0, 0, 0);

                        _checkBoxBorder.BorderBrush = new Theme.CustomTheme().GetBackground();
                        _checkBoxBorder.BorderThickness = new System.Windows.Thickness(1);

                        _checkBoxBorder.Child = _checkBox;
                }

                public SingleTaskPanel(Model.Task task)
                {
                        this.Margin = new System.Windows.Thickness(10, 2, 0, 1);
                      
                        this.MinHeight = Dimensions.GetHeight() / 20;
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.Background = new Theme.CustomTheme().GetAccentColor();
                        _task = task;

                        SetUpCheckBox();

                        SetUpContent();

                        _content.Text = _task._name;

                        this.Children.Add(_checkBoxBorder);
                        this.Children.Add(_content);
                }


                internal void TriggerHover()
                {
                        this.Background = new Theme.CustomTheme().GetBackground();

                        _checkBoxBorder.BorderBrush = new Theme.CustomTheme().GetAccentColor();
                        _content.Foreground = new Theme.CustomTheme().GetAccentColor();
                }

                internal void UnHover()
                {
                        this.Background = new Theme.CustomTheme().GetAccentColor();

                        _checkBoxBorder.BorderBrush = new Theme.CustomTheme().GetBackground();
                        _content.Foreground = new Theme.CustomTheme().GetBackground();
                }
        }
}
