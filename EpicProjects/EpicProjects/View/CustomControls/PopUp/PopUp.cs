using EpicProjects.Constants;
using EpicProjects.View.Theme;
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

                

                public PopUp(double width, double height, string content)
                {
                        this.Width = width;
                        this.Height = height;
                        this.WindowStyle = System.Windows.WindowStyle.None;
                        this.ResizeMode = System.Windows.ResizeMode.NoResize;
                        this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        this.Background = ThemeSelector.GetPopUpBackground();

                        this.Deactivated += PopUp_Deactivated;

                        _container = new StackPanel();
                        _container.Orientation = Orientation.Vertical;

                        _block = new TextBlock();
                        _block.Text = content;
                        _block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _block.FontSize = 30;
                        _block.FontFamily = FontProvider._lato;
                        _block.Foreground = ThemeSelector.GetBackground();
                        _block.Margin = new Thickness(0, height / 20, 0, 0);

                        _container.Children.Add(_block);

                        this.AddChild(_container);
                        this.Show();

                }

                void PopUp_Deactivated(object sender, EventArgs e)
                {
                        this.Hide();
                }

        }//class PopUp
}//ns
