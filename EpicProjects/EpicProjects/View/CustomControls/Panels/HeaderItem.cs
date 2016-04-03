using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class HeaderItem : StackPanel
        {
                public TextBlock _content { get; set; }
                public StackPanel _underline { get; set; }
                public HeaderItem(string content)
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                      //  this.Height = Dimensions.GetHeight() / 10;
                        this.Width = Dimensions.GetWidth() * 0.9 / 4;
                        this.Background = new Theme.CustomTheme().GetAccentColor();

                        _content = new TextBlock();
                        _content.Text = content;
                        _content.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _content.FontFamily = FontProvider._proxima;
                        _content.FontSize = 20;
                        _content.Foreground = new Theme.CustomTheme().GetBackground();
                        _content.Background = new Theme.CustomTheme().GetAccentColor();
                        _content.Margin = new System.Windows.Thickness(0, Dimensions.GetHeight() / 40, 0, Dimensions.GetHeight() / 40);

                        _underline = new StackPanel();
                        _underline.Height = Dimensions.GetHeight() / 100;
                        _underline.Background = new Theme.CustomTheme().GetAccentColor();

                        this.Children.Add(_content);
                        this.Children.Add(_underline);


                        this.MouseEnter += HeaderItem_MouseEnter;
                        this.MouseLeave += HeaderItem_MouseLeave;

                        //_content.MouseEnter += HeaderItem_MouseEnter;
                        //_content.MouseLeave += HeaderItem_MouseLeave;

                }

                void HeaderItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        _underline.Background = new Theme.CustomTheme().GetAccentColor();
                }

                void HeaderItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        _underline.Background = new Theme.CustomTheme().GetBackground();
                }

               
        }
}
