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

namespace EpicProjects.Sketches
{
        /// <summary>
        /// Interaction logic for Home.xaml
        /// </summary>
        public partial class Home : Window
        {
                public Home()
                {
                        InitializeComponent();
                }

                private void newpanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        newpanel.Background = new SolidColorBrush(Color.FromArgb(255,63,81,181));
                        newtext.Foreground = new SolidColorBrush(Color.FromArgb(255, 210, 215, 211));
                }

                private void newpanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        newpanel.Background = new SolidColorBrush(Color.FromArgb(255, 238, 231, 231));
                        newtext.Foreground = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                }

                private void openpanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        openpanel.Background = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                        opentext.Foreground = new SolidColorBrush(Color.FromArgb(255, 210, 215, 211));
                }

                private void openpanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        openpanel.Background = new SolidColorBrush(Color.FromArgb(255, 238, 231, 231));
                        opentext.Foreground = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                }

                private void settingpanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        settingpanel.Background = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                        settingstext.Foreground = new SolidColorBrush(Color.FromArgb(255, 210, 215, 211));
                }

                private void settingpanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        settingpanel.Background = new SolidColorBrush(Color.FromArgb(255, 238, 231, 231));
                        settingstext.Foreground = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                }

                private void docpanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        docpanel.Background = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                        doctext.Foreground = new SolidColorBrush(Color.FromArgb(255, 210, 215, 211));
                }

                private void docpanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        docpanel.Background = new SolidColorBrush(Color.FromArgb(255, 238, 231, 231));
                        doctext.Foreground = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                }

                private void aboutpanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        aboutpanel.Background = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                        abouttext.Foreground = new SolidColorBrush(Color.FromArgb(255, 210, 215, 211));
                }

                private void aboutpanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        aboutpanel.Background = new SolidColorBrush(Color.FromArgb(255, 238, 231, 231));
                        abouttext.Foreground = new SolidColorBrush(Color.FromArgb(255, 63, 81, 181));
                }
        }
}
