using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EpicProjects.View.CustomControls.Items
{
        public class SideMenuItem : TextBlock
        {
                public SideMenuItem(string content, int fontSize)
                {
                        this.Text = content;
                        this.FontSize = fontSize;
                        this.FontFamily = FontProvider._proxima;
                        this.Foreground = new Theme.CustomTheme().GetAccentColor();

                        this.MouseEnter += SideMenuItem_MouseEnter;
                        this.MouseLeave += SideMenuItem_MouseLeave;

                }

                void SideMenuItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Foreground = new Theme.CustomTheme().GetAccentColor();
                        this.Background = new Theme.CustomTheme().GetBackground();
                }

                void SideMenuItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                       

                        this.Background = new Theme.CustomTheme().GetAccentColor();
                        this.Foreground = new Theme.CustomTheme().GetBackground();
                }


        }// class SideMenuItem
}
