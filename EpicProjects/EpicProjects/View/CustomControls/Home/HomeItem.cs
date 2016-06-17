using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

using EpicProjects.Constants;
using EpicProjects.View.Theme;

namespace EpicProjects.View.CustomControls.Home
{
        public class HomeItem : StackPanel
        {
                public MenuTitle _title { get; set; }
                public TextBlock _itemBlock { get; set; }
                public Theme.Theme _theme { get; set; }

                public bool _isOver { get; set; }

                public HomeItem(string title, string text, double width, string tooltip)
                {
                        

                        _title = new MenuTitle(title,35);
                        
                        _title.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        //_image.Width = Dimensions.GetWidth()/15;
                        //_image.Height = Dimensions.GetHeight() / 15;

                        _itemBlock = new TextBlock();
                        _itemBlock.Text = text;
                        _itemBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _itemBlock.FontFamily = FontProvider._lato;
                        _itemBlock.FontSize = 20;
                        _itemBlock.Foreground = ThemeSelector.GetAccentColor(); 
                        _itemBlock.Margin = new System.Windows.Thickness(0, 15, 0, 0);
                       


                        //this.ToolTip = tooltip;
                        this.Orientation = Orientation.Vertical;
                        this.Width = width;
                        this.Children.Add(_title);
                        this.Children.Add(_itemBlock);

                        _title.MouseEnter += HomeItem_MouseEnter;
                        _title.MouseLeave += HomeItem_MouseLeave;
                }

                void HomeItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {

                        _title.Foreground = ThemeSelector.GetAccentColor();
                }

                void HomeItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {

                        _title.Foreground = ThemeSelector.GetHighlightColor();
                }
        }//class HomeItem
}//ns
