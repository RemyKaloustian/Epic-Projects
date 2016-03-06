using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

using EpicProjects.Constants;

namespace EpicProjects.View.CustomControls.Home
{
        public class HomeItem : StackPanel
        {
                public Image _image { get; set; }
                public TextBlock _itemBlock { get; set; }
                public Theme.Theme _theme { get; set; }

                public HomeItem(string imageSrc, string text, Theme.Theme th, double width, string tooltip)
                {
                        _theme = th;

                        _image = new Image();
                        var uriSource = new Uri( imageSrc, UriKind.Relative);
                        _image.Source = new BitmapImage(uriSource);
                        _image.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _image.Width = Dimensions.GetWidth()/15;
                        _image.Height = Dimensions.GetHeight() / 15;

                        _itemBlock = new TextBlock();
                        _itemBlock.Text = text;
                        _itemBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _itemBlock.FontFamily = new System.Windows.Media.FontFamily("Bariol Regular");
                        _itemBlock.FontSize = 20;
                        _itemBlock.Foreground = _theme.GetAccentColor(); 
                        _itemBlock.Margin = new System.Windows.Thickness(0, _image.Height/3, 0, 0);
                       


                        this.ToolTip = tooltip;
                        this.Orientation = Orientation.Vertical;
                        this.Width = width;
                        this.Children.Add(_image);
                        this.Children.Add(_itemBlock);
                }
        }//class HomeItem
}//ns
