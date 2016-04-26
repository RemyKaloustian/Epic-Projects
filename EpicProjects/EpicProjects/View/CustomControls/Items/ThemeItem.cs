using EpicProjects.Constants;
using EpicProjects.Constants.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace EpicProjects.View.CustomControls.Items
{
        public class ThemeItem : StackPanel
        {
                public TextBlock _themeName { get; set; }

                public ThemeItem(string content, SolidColorBrush background, SolidColorBrush contentColor)
                {
                       //this.Width = Dimensions.GetWidth() / 3;

                        _themeName = new TextBlock();
                        _themeName.Text = content;
                        _themeName.FontFamily = FontProvider._lato;
                        _themeName.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _themeName.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        _themeName.FontSize = 20;
                        _themeName.Foreground = contentColor;
                        _themeName.Width = Dimensions.GetWidth()/3.5;
                        _themeName.Height = Dimensions.GetHeight() * 0.2;
                        _themeName.Margin = new System.Windows.Thickness(10, 10, 10, 10);

                        _themeName.Background = background;

                        this.Children.Add(_themeName);

                }

                public void Hover()
                {
                        this.Background = Palette2.GetColor(Palette2.SILVER);
                }

                public void Unhover()
                {
                        this.Background = null;
                }

        }//class ThemeItem
}//ns
