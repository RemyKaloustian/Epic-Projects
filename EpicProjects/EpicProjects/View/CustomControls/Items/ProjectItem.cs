using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Items
{
        public class ProjectItem : StackPanel
        {
                public TextBlock _nameBlock{ get; set; }

                public ProjectItem(double height, string content)
                {
                        this.Height = height;
                        this.Background = new Theme.CustomTheme().GetAccentColor();
                        
                        

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = content;
                        _nameBlock.FontFamily = FontProvider._lato;
                        _nameBlock.FontSize = 17;
                        _nameBlock.Foreground = new Theme.CustomTheme().GetBackground();
                      //  _nameBlock.Foreground = Palette2.GetColor(Palette2.ORANGE);

                        this.Children.Add(_nameBlock);

                }

                public void Hover()
                {
                        this.Background = new Theme.CustomTheme().GetBackground();
                        _nameBlock.Foreground = new Theme.CustomTheme().GetAccentColor();
                }

                public void Unhover()
                {
                        this.Background = new Theme.CustomTheme().GetAccentColor();
                        _nameBlock.Foreground = new Theme.CustomTheme().GetBackground();
                }



        }//class ProjectItem
}//ns
