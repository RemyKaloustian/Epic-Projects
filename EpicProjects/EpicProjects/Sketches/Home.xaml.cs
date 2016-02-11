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
using System.Drawing;

using EpicProjects.Controller;

namespace EpicProjects.Sketches
{
        /// <summary>
        /// Interaction logic for Home.xaml
        /// </summary>
        public partial class Home : Window
        {
                public Masterchief _chief { get; set; }

                public Home()
                {
                        InitializeComponent();
                        _chief = new Masterchief();

                        PopulateLatestProjects();
                }

                private void PopulateLatestProjects()
                {

                        List<string> list = _chief.GetLatestProjects();

                        List<string> res = new List<string>();

                        for (int i = 0; i < 3; i++)
                        {
                                res.Add(list[i]);
                        }

                        foreach (string item in res)
                        {
                                TextBlock text = new TextBlock();
                                text.Inlines.Add(item);
                                text.Foreground = new SolidColorBrush(Color.FromArgb(255,74,137,220));
                                text.FontSize = 20;

                                LatestPanel.Children.Add(text);

                               
                        }
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
