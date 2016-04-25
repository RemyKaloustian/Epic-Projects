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
                        this.Background = ThemeSelector.GetBackground();

                        _content = new TextBlock();
                        _content.Text = content;
                        _content.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _content.FontFamily = FontProvider._proxima;
                        _content.FontSize = 20;
                        _content.Foreground = ThemeSelector.GetAccentColor();
                        //_content.Background = ThemeSelector.GetBackground();
                        _content.Margin = new System.Windows.Thickness(0, Dimensions.GetHeight() / 40, 0, Dimensions.GetHeight() / 40);

                        _underline = new StackPanel();
                        //_underline.Height = Dimensions.GetHeight() / 200;
                        _underline.Height = 2;
                        _underline.Background = ThemeSelector.GetBackground();

                        _addPanel = new StackPanel();

                        _addContent = new TextBlock();
                        _addContent.Text = "+";
                        _addContent.FontFamily = FontProvider._bariol;
                        _addContent.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _addContent.FontSize = 40;
                        _addContent.Foreground = ThemeSelector.GetAccentColor();

                        _addPanel.Children.Add(_addContent);
                        _addPanel.Width = this.Width;
                        _addPanel.Background = ThemeSelector.GetBackground();

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
                        _addContent.Foreground = ThemeSelector.GetAccentColor();
                        _addPanel.Background = ThemeSelector.GetBackground();
                }

                void _add_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {

                        

                        _addPanel.Background = ThemeSelector.GetAccentColor();
                        _addContent.Foreground = ThemeSelector.GetBackground();

                     
                }

                void HeaderItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        _underline.Background = ThemeSelector.GetBackground();
                }

                void HeaderItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                       
                                _underline.Background = ThemeSelector.GetAccentColor();
                }

               
        }
}
