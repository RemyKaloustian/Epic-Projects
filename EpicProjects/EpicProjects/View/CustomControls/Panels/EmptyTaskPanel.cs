using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EpicProjects.View.CustomControls.Panels
{
        public class EmptyTaskPanel : StackPanel
        {
                public TextBlock _titleBlock { get; set; }
                public TextBlock _definitionBlock { get; set; }
                public TextBlock _emptyBlock { get; set; }

                public EmptyTaskPanel(string section)
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        _titleBlock = new TextBlock();
                        _titleBlock.Text = section;
                        _titleBlock.FontFamily = FontProvider._lato;
                        _titleBlock.FontSize = 30;
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.Foreground = Palette2.GetColor(Palette2.CONCRETE);

                        _definitionBlock = new TextBlock();
                        _definitionBlock.FontFamily = FontProvider._lato;
                        _definitionBlock.FontSize = 20;
                        _definitionBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _definitionBlock.Foreground = Palette2.GetColor(Palette2.CONCRETE);
                        _definitionBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                        _definitionBlock.Text = "A " + section + " is an idea about the project.";
                     

                        _emptyBlock = new TextBlock();
                        _emptyBlock.FontFamily = FontProvider._lato;
                        _emptyBlock.FontSize = 20;
                        _emptyBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _emptyBlock.Foreground = Palette2.GetColor(Palette2.CONCRETE);
                        _emptyBlock.Text = "There is currently no brainstorming, you can add one by clicking + under  " + section;
                        this.Children.Add(_titleBlock);
                        this.Children.Add(_definitionBlock);
                        this.Children.Add(_emptyBlock);

                }


        }//class EmptyTaskPanel
}//ns
