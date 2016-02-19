using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EpicProjects.Sketches.Custom
{
        /// <summary>
        /// Interaction logic for CustomDoc.xaml
        /// </summary>
        public partial class CustomDoc : Window
        {
                public CustomDoc()
                {
                        InitializeComponent();

                        StringBuilder content = new StringBuilder();

                        for (int i = 0; i < 100; i++)
                        {
                                TextBlock t = new  TextBlock();
                                t.Inlines.Add(i + "___IM IN THE PANEL OH YEAH WHAAAAAAAAAAAAAOU\n");
                                content.Append(i + "__THis is a nice text LEL Livai Hecho !!!!!!!!!!!!!!!!!!!!!! \n");
                        }

                        MyScroller.Content = content.ToString();
                        MyScroller.Content = new StackPanel();


                     
                }

                private void NewProjectImage_MouseEnter(object sender, MouseEventArgs e)
                {

                }

                private void NewProjectImage_MouseLeave(object sender, MouseEventArgs e)
                {

                }

                private void OpenProjectImage_MouseEnter(object sender, MouseEventArgs e)
                {

                }

                private void OpenProjectImage_MouseLeave(object sender, MouseEventArgs e)
                {

                }

                private void StatsImage_MouseEnter(object sender, MouseEventArgs e)
                {

                }

                private void StatsImage_MouseLeave(object sender, MouseEventArgs e)
                {

                }

                private void BugImage_MouseEnter(object sender, MouseEventArgs e)
                {

                }

                private void BugImage_MouseLeave(object sender, MouseEventArgs e)
                {

                }

                private void MenuImage_MouseEnter(object sender, MouseEventArgs e)
                {

                }

                private void MenuImage_MouseLeave(object sender, MouseEventArgs e)
                {

                }
        }
}
