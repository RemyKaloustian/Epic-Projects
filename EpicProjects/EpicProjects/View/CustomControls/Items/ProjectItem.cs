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
                        this.Background = Palette2.GetColor(Palette2.SILVER);
                        
                        

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = content;
                        _nameBlock.FontFamily = FontProvider._lato;
                        _nameBlock.FontSize = 17;
                        _nameBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        _nameBlock.Margin = new System.Windows.Thickness(40, 0, 0, 0);
                        _nameBlock.TextWrapping = System.Windows.TextWrapping.Wrap;

                        this.Children.Add(_nameBlock);

                }

                public void Hover()
                {
                        this.Background = new Theme.CustomTheme().GetBackground();
                        _nameBlock.Foreground = new Theme.CustomTheme().GetAccentColor();
                }

                public void Unhover()
                {
                        this.Background = Palette2.GetColor(Palette2.SILVER);
                        _nameBlock.Foreground = new Theme.CustomTheme().GetBackground();
                }



        }//class ProjectItem
}//ns
