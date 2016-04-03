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

                public StackPanel _addPanel { get; set; }
                public TextBlock _addContent{ get; set; }
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
                        _underline.Height = Dimensions.GetHeight() / 200;
                        _underline.Background = new Theme.CustomTheme().GetAccentColor();

                        _addPanel = new StackPanel();

                        _addContent = new TextBlock();
                        _addContent.Text = "+";
                        _addContent.FontFamily = FontProvider._bariol;
                        _addContent.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _addContent.FontSize = 40;
                        _addContent.Foreground = new Theme.CustomTheme().GetBackground();

                        _addPanel.Children.Add(_addContent);
                        _addPanel.Width = this.Width;
                        _addPanel.Background = new Theme.CustomTheme().GetAccentColor();

                        this.Children.Add(_content);
                        this.Children.Add(_underline);
                        this.Children.Add(_addPanel);


                        this.MouseEnter += HeaderItem_MouseEnter;
                        this.MouseLeave += HeaderItem_MouseLeave;

                        _addPanel.MouseEnter += _add_MouseEnter;
                        _addPanel.MouseLeave += _add_MouseLeave;

                        //_content.MouseEnter += HeaderItem_MouseEnter;
                        //_content.MouseLeave += HeaderItem_MouseLeave;

                }

                void _add_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        _addContent.Foreground = new Theme.CustomTheme().GetBackground();
                        _addPanel.Background = new Theme.CustomTheme().GetAccentColor();
                }

                void _add_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        _addPanel.Background = new Theme.CustomTheme().GetBackground();
                        _addContent.Foreground = new Theme.CustomTheme().GetAccentColor();

                     
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
