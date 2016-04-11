using EpicProjects.Constants;
using EpicProjects.Controller;
using EpicProjects.View.CustomControls.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class NewTaskPopUp : PopUp
        {
                public string _projectName{ get; set; }
                public string  _section{ get; set; }

                public Separator _separator { get; set; }

                public TextBlock _nameBlock { get; set; }
                public TextBox _nameBox { get; set; }

                public TextBlock _alertBlock { get; set; }

                public TextBlock _detailsBlock { get; set; }
                public TextBox _detailsBox { get; set; }

                public ValidateButton _validateButton { get; set; }
                public CancelButton _cancelButton { get; set; }

                public ContentPanel _contentPanel { get; set; }

                public NewTaskPopUp(double width, double height, string content, string projectName, bool isAdvanced, ContentPanel contentPanel)
                        : base(width,  height,  content)
                {
                        this.Background = new Theme.CustomTheme().GetPopUpBackground();

                        _contentPanel = contentPanel;

                        _block.Text = "New " + content;
                        _section = content;

                        _projectName = projectName;
                        _separator = new Separator();
                        _separator.Width = this.Width / 2;
                        _separator.Background = new Theme.CustomTheme().GetBackground();
                        _separator.Margin = new System.Windows.Thickness(0, 10, 0, 50);

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = "Name  ";
                        _nameBlock.FontFamily = FontProvider._lato;
                        _nameBlock.FontSize = 25;
                        _nameBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBlock.Foreground = new Theme.CustomTheme().GetBackground();

                        _nameBox = new TextBox();
                        _nameBox.Width = this.Width * 0.5;
                        _nameBox.FontFamily = FontProvider._lato;
                        _nameBox.Height = this.Height * 0.06;
                        _nameBox.FontSize = 20;

                        _alertBlock = new TextBlock();
                        _alertBlock.FontFamily = FontProvider._open;
                        _alertBlock.FontSize = 20;

                        _detailsBlock = new TextBlock();
                        _detailsBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _detailsBlock.FontSize = 25;
                        _detailsBlock.FontFamily = FontProvider._lato;
                        _detailsBlock.Text = "Description";
                        _detailsBlock.Foreground = new Theme.CustomTheme().GetBackground();

                        _detailsBox = new TextBox();

                        _detailsBox.Width = this.Width * 0.5;
                        _detailsBox.FontFamily = FontProvider._lato;
                        _detailsBox.Height = this.Height * 0.2;
                        _detailsBox.FontSize = 16;
                        _detailsBox.TextWrapping = System.Windows.TextWrapping.Wrap;


                        _validateButton = new ValidateButton( "Create",this.Width*0.5,this.Height*0.07,new System.Windows.Thickness(0,30,0,30),new System.Windows.Thickness(5,5,5,5), System.Windows.HorizontalAlignment.Center,new Theme.CustomTheme());
                        _validateButton.MouseDown += _validateButton_MouseDown;

                        _cancelButton = new CancelButton("Cancel", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _cancelButton.MouseDown += _cancelButton_MouseDown;

                        _container.Children.Add(_separator);
                        _container.Children.Add(_nameBlock);
                        _container.Children.Add(_nameBox);
                        _container.Children.Add(_alertBlock);
                        _container.Children.Add(_detailsBlock);
                        _container.Children.Add(_detailsBox);

                        if (!isAdvanced)
                        {
                                _container.Children.Add(_validateButton);
                                _container.Children.Add(_cancelButton);
                        }

                }

                void _validateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if (_section == ControlsValues.BRAINSTORMING)
                        {
                                new TaskMasterChief(_projectName).InsertBrainstorming(_nameBox.Text, _detailsBox.Text);
                                _contentPanel.LoadBrainstorming();
                        }
                    
                        this.Close();
                }

                void _cancelButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }
        }
}
