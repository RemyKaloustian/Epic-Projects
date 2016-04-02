using EpicProjects.Constants;
using EpicProjects.View.CustomControls.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using EpicProjects.Constants.Images;

namespace EpicProjects.View.CustomControls.Panels
{
        

        public class SideMenuPanel : StackPanel
        {
                public Image _newProjectItem { get; set; }

                public Image _openProjectItem { get; set; }

                public Image _statsItem { get; set; }

                public Image _bugItem { get; set; }

                public Image _homeItem { get; set; }

                public SideMenuPanel()
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.1;
                        this.Height = Dimensions.GetHeight();

                        _newProjectItem = new Image();
                        _newProjectItem.Source = new BitmapImage(new Uri(CustomImages.NEW_PROJECT, UriKind.Relative));
                        _newProjectItem.Width = this.Width / 2;

                        _openProjectItem = new Image();
                        _openProjectItem.Source = new BitmapImage(new Uri(CustomImages.OPEN_PROJECT, UriKind.Relative));
                        _openProjectItem.Width = this.Width / 2;

                        _statsItem = new Image();
                        _statsItem.Source = new BitmapImage(new Uri(CustomImages.STATS, UriKind.Relative));
                        _statsItem.Width = this.Width / 2;

                        _bugItem = new Image();
                        _bugItem.Source = new BitmapImage(new Uri(CustomImages.BUG, UriKind.Relative));
                        _bugItem.Width = this.Width / 2;

                        _homeItem = new Image();
                        _homeItem.Source = new BitmapImage(new Uri(CustomImages.MENU, UriKind.Relative));
                        _homeItem.Width = this.Width / 2;

                        this.Children.Add(_newProjectItem);
                        this.Children.Add(_openProjectItem);
                        this.Children.Add(_statsItem);
                        this.Children.Add(_bugItem);
                        this.Children.Add(_homeItem);
                        TextBlock test = new TextBlock();
                        test.Text = "WOWWWWWWWWWWWW";
                        this.Children.Add(test);

                        this.Background = new Theme.CustomTheme().GetBackground();


                }

        }//class MenuPanel
}//ns
