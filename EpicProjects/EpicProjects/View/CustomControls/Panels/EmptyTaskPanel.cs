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
                        SetUpTitle(section);
                        SetUpDefinition(section);
                        SetUpEmpty(section);
                       
                        this.Children.Add(_titleBlock);
                        this.Children.Add(_definitionBlock);
                        this.Children.Add(_emptyBlock);

                }//ctor

                private void SetUpEmpty(string section)
                {
                        _emptyBlock = new TextBlock();
                        _emptyBlock.FontFamily = FontProvider._lato;
                        _emptyBlock.FontSize = 20;
                        _emptyBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _emptyBlock.Foreground = Palette2.GetColor(Palette2.CONCRETE);
                        if (section == ControlsValues.ASSIGNMENTS)
                        {
                                _emptyBlock.Text = "There is currently no " + section.ToLower().Remove(section.Length - 1) + "s, you can add one by clicking + under  " + section;
                        }

                        else
                        {
                                _emptyBlock.Text = "There is currently no " + section.ToLower() + "s, you can add one by clicking + under  " + section;
                        }
                }

                private void SetUpDefinition(string section)
                {
                        _definitionBlock = new TextBlock();
                        _definitionBlock.FontFamily = FontProvider._lato;
                        _definitionBlock.FontSize = 20;
                        _definitionBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _definitionBlock.Foreground = Palette2.GetColor(Palette2.CONCRETE);
                        _definitionBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                        _definitionBlock.Text = CreateDefinition(section);

                }

                private void SetUpTitle(string section)
                {
                        _titleBlock = new TextBlock();
                        _titleBlock.Text = section;
                        _titleBlock.FontFamily = FontProvider._lato;
                        _titleBlock.FontSize = 30;
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.Foreground = Palette2.GetColor(Palette2.CONCRETE);
                }

                private string CreateDefinition(string section)
                {
                        string toReturn = "";

                        if(section == ControlsValues.ASSIGNMENTS)
                        {
                                toReturn += "An " + section.Remove(section.Length -1);
                        }
                        else
                        {
                                toReturn += "A " + section;
                        }

                        if(section == ControlsValues.BRAINSTORMING)
                        {
                                toReturn += " is an idea or group of idea written before beginning a project.";
                        }

                        else if(section == ControlsValues.TRAINING)
                        {
                                toReturn += " is something you need to learn or master in order to make the project.";
                        }

                        else if(section == ControlsValues.ASSIGNMENTS)
                        {
                                toReturn += " is a task to accomplish during the development of the project.";
                        }

                        else if(section == ControlsValues.MAINTENANCE)
                        {
                                toReturn += " is a problem you have to fix after the project is finished.";
                        }

                        return toReturn;
                }


        }//class EmptyTaskPanel
}//ns
