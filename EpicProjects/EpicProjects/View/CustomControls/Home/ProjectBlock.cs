using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Home
{
        class ProjectBlock : StackPanel
        {
                public TextBlock _block { get; set; }

                public ProjectBlock(string content, double width, double height, Theme.Theme theme)
                {
                        _block = new TextBlock();
                        _block.Text = content;
                        _block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _block.Foreground = theme.GetAccentColor();
                        _block.FontFamily = new System.Windows.Media.FontFamily("Lato Light");
                        _block.FontSize = 18;

                        this.Background = theme.GetBackground();
                        this.Width = width;
                        this.Height = height;
                        this.Children.Add(_block);
                       
                        
                }//ProjectBlock()
        }//class projectBlock
}//ns
