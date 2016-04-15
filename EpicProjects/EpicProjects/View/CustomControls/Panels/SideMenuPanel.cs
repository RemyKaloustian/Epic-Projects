using EpicProjects.Constants;
using EpicProjects.View.CustomControls.Items;
using EpicProjects.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using EpicProjects.Constants.Images;
using System.Windows;

namespace EpicProjects.View.CustomControls.Panels
{
        

        public class SideMenuPanel : StackPanel
        {
                public SideMenuItem _newProjectItem { get; set; }

                public SideMenuItem _openProjectItem { get; set; }

                public SideMenuItem _statsItem { get; set; }

                public SideMenuItem _bugItem { get; set; }

                public SideMenuItem _homeItem { get; set; }

                

                public SideMenuPanel()
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.1;
                        this.Height = Dimensions.GetHeight();

                        _newProjectItem = new SideMenuItem(ControlsValues.NEWPROJECT, 20);
                        _newProjectItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);

                        _openProjectItem = new SideMenuItem(ControlsValues.OPENPROJECT,20);
                        _openProjectItem.Padding = new Thickness(this.Width * 0.1,this.Width/8,0,this.Width/8);


                        _statsItem = new SideMenuItem(ControlsValues.STATS,20);
                        _statsItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);


                        _bugItem = new SideMenuItem(ControlsValues.REPORT,20);
                        _bugItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);


                        _homeItem = new SideMenuItem(ControlsValues.HOME,20);
                        _homeItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);
                        _homeItem.MouseDown += _homeItem_MouseDown;


                        this.Children.Add(_newProjectItem);
                        this.Children.Add(_openProjectItem);
                        this.Children.Add(_statsItem);
                        this.Children.Add(_bugItem);
                        this.Children.Add(_homeItem);
                      

                        this.Background = new Theme.CustomTheme().GetBackground();


                }

                void _homeItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                       
                        //App.Current.Windows[1].Hide();
                        //App.Current.Windows[0].Hide();

                        foreach (Window win in App.Current.Windows)
                        {
                               
                                        win.Hide();
                            
                        }
                        View.Home j = new View.Home();
                        j.Show();


                      
                       
                        

                        
                }

        }//class MenuPanel
}//ns
