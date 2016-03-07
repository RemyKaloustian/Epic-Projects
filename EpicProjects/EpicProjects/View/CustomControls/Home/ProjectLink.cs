using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

using EpicProjects.Constants;

namespace EpicProjects.View.CustomControls.Home
{
        public class ProjectLink : TextBlock
        {
                public SolidColorBrush _color { get; set; }
                public ProjectLink(string projectName, SolidColorBrush accentColor)
                {
                        this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        this.Text = projectName;
                        this.FontFamily = new System.Windows.Media.FontFamily("Lato Light");
                        this.FontSize = 20;
                        _color = accentColor;
                        this.Foreground = accentColor;

                        this.MouseEnter += ProjectLink_MouseEnter;
                        this.MouseLeave += ProjectLink_MouseLeave;
                        this.MouseDown += GoToProject;
                }

                private void GoToProject(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        Debug.CW("GOING ! ! ");
                }

                void ProjectLink_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Foreground = _color;
                }

                void ProjectLink_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Foreground = new SolidColorBrush(Colors.White);
                }
        }//class ProjectLink
}//ns
