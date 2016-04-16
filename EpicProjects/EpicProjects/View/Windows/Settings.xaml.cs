using EpicProjects.Constants;
using EpicProjects.View.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EpicProjects.View.Windows
{
        /// <summary>
        /// Interaction logic for Settings.xaml
        /// </summary>
        public partial class Settings : Window
        {


                public Settings(string previous)
                {
                        InitializeComponent();
                        this.Show();
                        SetUpWindow("Settings");
                        SetLayout(previous);
                }

                private void SetLayout(string previous)
                {
                        Grid.Children.Add(new SettingsLayoutNinja(this.Width, this.Height,previous ).GetLayout());
                }


                private void SetUpWindow(string name)
                {
                        this.Width = Dimensions.GetWidth();
                        this.Height = Dimensions.GetHeight();
                        this.MinHeight = Dimensions.GetHeight();
                        this.MinWidth = Dimensions.GetWidth();
                        this.ResizeMode = System.Windows.ResizeMode.CanResize;
                        this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        this.WindowState = WindowState.Maximized;
                        this.Title = name;
                }


        }//class Settings
}//ns
