using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class PopUp : Window
        {
                public StackPanel _container { get; set; }
                public TextBlock _block { get; set; }

                public Theme.Theme _theme { get; set; }

                public PopUp(double width, double height, string content)
                {
                        _theme = new Theme.CustomTheme();

                        _container = new StackPanel();
                        _container.Orientation = Orientation.Vertical;

                        _block = new TextBlock();
                        _block.Text = content;
                        _block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _block.FontSize = 30;
                        _block.FontFamily = FontProvider._lato;
                        _block.Foreground = _theme.GetBackground();
                        _block.Margin = new Thickness(0, height / 10, 0, 0);

                        this.Background = _theme.GetAccentColor();


                      this.Width = width;
                        this.Height = height;
                        this.WindowStyle = System.Windows.WindowStyle.None;
                        this.ResizeMode = System.Windows.ResizeMode.NoResize;
                        this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

                        _container.Children.Add(_block);

                        this.AddChild(_container);
                        this.Show();

                }//PopUp
        }//class PopUp
}//ns
