using EpicProjects.Constants;
using EpicProjects.View.Layout;
using EpicProjects.View.Theme;
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
        /// Interaction logic for Theme.xaml
        /// </summary>
        public partial class Theme : Window
        {
                public Theme()
                {
                        InitializeComponent();
                        this.Show();
                        SetUpWindow("Theme selection");

                        SetUpLayout();
                        ThemeSelector.InitializeTheme();


                }

                private void SetUpLayout()
                {
                        Grid.Children.Add(new ThemeLayoutNinja().GetLayout());
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
        }//class Theme
}//ns
