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
        public class BadPerson : Window
        {
                public StackPanel _container { get; set; }
                public TextBlock _block { get; set; }
                public CustomButton _badButton { get; set; }

                public BadPerson()
                {

                        Theme.Theme th = new Theme.CustomTheme();
                        this.Width = Dimensions.GetWidth() / 4;
                        this.Height = Dimensions.GetHeight() / 5;

                        this.WindowStyle = System.Windows.WindowStyle.None;
                        this.ResizeMode = System.Windows.ResizeMode.NoResize;
                        this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        this.Background = Palette2.GetColor(Palette2.MIDNIGHT_BLUE);

                        _block = new TextBlock();
                        _block.Text = "You are a bad person. ";
                        _block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _block.FontSize = 30;
                        _block.FontFamily = FontProvider._lato;
                        _block.Foreground = th.GetAccentColor();
                        _block.Margin = new Thickness(0, this.Height / 10, 0, 0);

                        _badButton = new CancelButton(ControlsValues.BAD, this.Width * 0.75, this.Width / 6, new Thickness(0, this.Width / 20, 0, 0), new Thickness(0, this.Width / 30, 0, 0), HorizontalAlignment.Center, th);
                        _badButton.MouseDown += _badButton_MouseDown;

                        _container = new StackPanel();
                        _container.Orientation = Orientation.Vertical;

                        _container.Children.Add(_block);
                        _container.Children.Add(_badButton);

                        this.AddChild(_container);
                        this.Show();
                }

                void _badButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }
        }//class BadPerson
}//ns
