using EpicProjects.Constants;
using EpicProjects.Controller;
using EpicProjects.View.CustomControls;
using EpicProjects.View.CustomControls.PopUp;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.Layout
{
        public class SettingsLayoutNinja : LayoutNinja
        {
                public StackPanel _container { get; set; }

                public TextBlock _titleBlock { get; set; }
                public Separator _separator { get; set; }

                public ValidateButton _changeThemeButton { get; set; }
                public ValidateButton _renameButton{ get; set; }
                public CancelButton _backButton { get; set; }

                public string _previous { get; set; }

                public SettingsLayoutNinja(double width, double height, string previous)
                {
                        _previous = previous;   

                        _container = new StackPanel();
                        _container.Orientation = Orientation.Vertical;

                        SetUpTitleBlock();
                        SetUpSeparator(width);
                        SetUpButtons(width, height, previous);

                        _container.Children.Add(_titleBlock);
                        _container.Children.Add(_separator);
                        _container.Children.Add(_changeThemeButton);


                        //For the moment not useful
                        //if(previous != "home")
                        //{
                        //        _container.Children.Add(_renameButton);

                        //}
                        _container.Children.Add(_backButton);
                }//ctor()

                private void SetUpButtons(double width, double height, string previous)
                {
                        _changeThemeButton = new ValidateButton("Change theme", width * 0.5, height * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _changeThemeButton.MouseDown += _changeThemeButton_MouseDown;
                        _changeThemeButton._block.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                        _backButton = new CancelButton("Back to " + previous, width * 0.5, height * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _backButton.MouseDown += _backButton_MouseDown;

                        
                        _renameButton = new ValidateButton("Rename project", width * 0.5, height * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _renameButton.MouseDown += _renameButton_MouseDown;
                }//SetUpButtons()

               
                private void SetUpSeparator(double width)
                {
                        _separator = new Separator();
                        _separator.Width = width * 0.5;
                        _separator.Background = ThemeSelector.GetBackground();
                }//SetUpSeparator()

                private void SetUpTitleBlock()
                {
                        _titleBlock = new TextBlock();
                        _titleBlock.Text = "Settings";
                        _titleBlock.FontFamily = FontProvider._lato;
                        _titleBlock.FontSize = 25;
                        _titleBlock.Foreground = ThemeSelector.GetBackground();
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.Margin = new System.Windows.Thickness(0, 30, 0, 10);
                }//SetUpTitleBlock()

                void _changeThemeButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        new Captain().ToTheme(_previous);
                }

                void _renameButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        RenamePopUp pop = new RenamePopUp(Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.5, _previous);
                }


                void _backButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if(_previous.ToLower() == "home")
                        {
                                new Captain().ToHome();
                        }

                        else
                        {
                                new Captain().ToProject(_previous);
                        }
                }

                public override StackPanel GetLayout()
                {
                        return _container;
                }//GetLayout()

        }///class SettingsLayoutNinja
}//ns
