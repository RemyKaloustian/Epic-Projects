using EpicProjects.Constants;
using EpicProjects.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class DetailsPanel : StackPanel
        {
                public TextBlock _name { get; set; }
                public Separator _nameSeparator { get; set; }
                public TextBlock _priority{ get; set; }
                public Separator _prioritySeparator { get; set; }   
                public TextBlock _details { get; set; }
                public CancelButton _quitButton { get; set; }

                public SingleTaskPanel _taskPanel { get; set; }


                public DetailsPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = new Theme.CustomTheme().GetAccentColor();

                        _name = new TextBlock();
                        _details = new TextBlock();
                        _priority = new TextBlock();
                        _quitButton = new CancelButton(ControlsValues.CLOSE,this.Width*0.6,this.Height*0.05,new System.Windows.Thickness(0,0,0,0), new System.Windows.Thickness(0,0,0,0), System.Windows.HorizontalAlignment.Center,new Theme.CustomTheme());
                        _quitButton.Visibility = System.Windows.Visibility.Hidden;
                        _quitButton.MouseDown += _quitButton_MouseDown;

                        SetUpName();
                        SetUpSeparator();
                        SetUpPrioritySeparator();
                        SetUpDetails();

                        this.Children.Add(_name);
                        this.Children.Add(_nameSeparator);
                        this.Children.Add(_priority);
                        this.Children.Add(_prioritySeparator);
                        this.Children.Add(_details);
                        this.Children.Add(_quitButton);
                }

                void _quitButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        _taskPanel.UnHover();
                }

                private void SetUpDetails()
                {
                        _details.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _details.FontFamily = FontProvider._lato;
                        _details.FontSize = 15;
                        _details.Width = this.Width * 0.8;
                        _details.MinHeight = 100;
                        _details.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _details.Foreground = new Theme.CustomTheme().GetBackground();
                }

                private void SetUpPrioritySeparator()
                {
                        _prioritySeparator = new Separator();
                        _prioritySeparator.Width = this.Width * 0.85;
                        _prioritySeparator.Background = new Theme.CustomTheme().GetBackground();
                        _prioritySeparator.Visibility = System.Windows.Visibility.Hidden;
                        _prioritySeparator.Margin = new System.Windows.Thickness(0, this.Height * 0.025, 0, this.Height * 0.025);
                }

                private void SetUpSeparator()
                {
                        _nameSeparator = new Separator();
                        _nameSeparator.Width = this.Width * 0.85;
                        _nameSeparator.Background = new Theme.CustomTheme().GetBackground();
                        _nameSeparator.Visibility = System.Windows.Visibility.Hidden;
                        _nameSeparator.Margin = new System.Windows.Thickness(0, this.Height * 0.025, 0, this.Height * 0.025);
                }

                private void SetUpName()
                {

                        _name.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _name.FontFamily = FontProvider._lato;
                        _name.FontSize = 28;
                        _name.Width = this.Width * 0.8;
                        _name.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _name.Foreground = new Theme.CustomTheme().GetBackground();
                        _name.Margin = new System.Windows.Thickness(0, this.Height * 0.015, 0, 0);
                }

                public void AddSeparator()
                {
                        _nameSeparator.Visibility = System.Windows.Visibility.Visible;

                }

                public void SetPriorityLayout(string content)
                {
                        _prioritySeparator.Visibility = System.Windows.Visibility.Visible;
                        _priority.Text = "Priority : " + new PriorityInterpreter(content).Interpret();

                        _priority.FontFamily = FontProvider._lato;
                        _priority.FontSize = 22;
                        _priority.Width = this.Width * 0.8;
                        _priority.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _priority.Foreground = new Theme.CustomTheme().GetBackground();

                }
        }//class DetailsPanel()
}//ns
