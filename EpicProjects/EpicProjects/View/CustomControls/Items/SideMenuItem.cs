using EpicProjects.Constants;
using EpicProjects.View.Theme;
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
                        this.Foreground = ThemeSelector.GetAccentColor();

                        this.MouseEnter += SideMenuItem_MouseEnter;
                        this.MouseLeave += SideMenuItem_MouseLeave;

                }

                void SideMenuItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Foreground = ThemeSelector.GetAccentColor();
                        this.Background = ThemeSelector.GetBackground();
                }

                void SideMenuItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                       

                        this.Background = ThemeSelector.GetAccentColor();
                        this.Foreground = ThemeSelector.GetBackground();
                }


        }// class SideMenuItem
}
