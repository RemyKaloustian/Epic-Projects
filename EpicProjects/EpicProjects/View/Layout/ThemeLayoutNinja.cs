using EpicProjects.Constants;
using EpicProjects.Controller;
using EpicProjects.View.CustomControls;
using EpicProjects.View.CustomControls.Buttons;
using EpicProjects.View.CustomControls.Items;
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
        public class ThemeLayoutNinja : LayoutNinja
        {
                AccentSelectionPopUp _accentP;

                public StackPanel _container { get; set; }
                public TextBlock _titleBlock{ get; set; }
                public Separator _separator { get; set; }

                public StackPanel _themesPanel { get; set; }

                public TextBlock _colorTitle { get; set; }
                public Separator _colorSeparator { get; set; }
                public DefaultButton _changeColor { get; set; }

                public ValidateButton _applyButton { get; set; }



                public int MyProperty { get; set; }

                public List<ThemeItem> _themeItemlist { get; set; }

                public string _selectedTheme { get; set; }
                public string  _selectedColor{ get; set; }
                public string _previous { get; set; }



                public ThemeLayoutNinja(string previous)
                {

                        _previous = previous;
                        _container = new StackPanel();
                        _container.Orientation = Orientation.Vertical;

                        _titleBlock = new TextBlock();
                        _titleBlock.Text = "Theme selection";
                        _titleBlock.FontFamily = FontProvider._lato;
                        _titleBlock.FontSize = 25;
                        _titleBlock.Foreground = ThemeSelector.GetBackground();
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);

                        _separator = new Separator();
                        _separator.Width = Dimensions.GetWidth() * 0.5;
                        _separator.Background = ThemeSelector.GetBackground();

                        _themesPanel = new StackPanel();
                        _themesPanel.Orientation = Orientation.Horizontal;
                        _themesPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _themeItemlist = new List<ThemeItem>();

                        ThemeItem dark = new ThemeItem("Dark", Palette2.GetColor("#2c3e50"),ThemeSelector._lastSavedAccent);
                        _themesPanel.Children.Add(dark);
                        _themeItemlist.Add(dark);
                        dark.MouseDown += ThemeItem_MouseDown;
                        dark.MouseDown += dark_MouseDown;

                        ThemeItem light = new ThemeItem("Light", Palette2.GetColor("#f5f5f5"), ThemeSelector._lastSavedAccent);
                        _themesPanel.Children.Add(light);
                        _themeItemlist.Add(light);
                        light.MouseDown += ThemeItem_MouseDown;
                        light.MouseDown += light_MouseDown;


                        ThemeItem custom = new ThemeItem("Custom", ThemeSelector._lastSavedAccent,Palette2.GetColor("#f5f5f5"));
                        _themesPanel.Children.Add(custom);
                        _themeItemlist.Add(custom);
                        custom.MouseDown += ThemeItem_MouseDown;
                        custom.MouseDown += custom_MouseDown;


                        _colorTitle = new TextBlock();
                        _colorTitle.Text = "Color selection";
                        _colorTitle.FontFamily = FontProvider._lato;
                        _colorTitle.FontSize = 25;
                        _colorTitle.Foreground = ThemeSelector.GetBackground();
                        _colorTitle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _colorTitle.Margin = new System.Windows.Thickness(0, 20, 0, 0);

                        _colorSeparator = new Separator();
                        _colorSeparator.Width = Dimensions.GetWidth() * 0.5;
                        _colorSeparator.Background = ThemeSelector.GetBackground();

                        _changeColor = new  DefaultButton("Change accent color", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight()* 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _changeColor.MouseDown += _changeColor_MouseDown;


                        _applyButton = new ValidateButton("Apply Changes", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _applyButton.MouseDown += _applyButton_MouseDown;



                        _container.Children.Add(_titleBlock);
                        _container.Children.Add(_separator);
                        _container.Children.Add(_themesPanel);
                        _container.Children.Add(_colorTitle);
                        _container.Children.Add(_colorSeparator);
                        _container.Children.Add(_changeColor);
                        _container.Children.Add(_applyButton);


                }

                void _applyButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if(_selectedTheme != null)
                        {
                                ThemeSelector.ChangeThemeType(_selectedTheme);
                        }

                        if (_selectedColor != null)
                        {
                                ThemeSelector.ChangeAccent(_accentP._selectedColor);
                        }

                        new Captain().ToSettings(_previous);
                }

                void _changeColor_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                        _accentP = new AccentSelectionPopUp(Dimensions.GetWidth()*0.7, Dimensions.GetHeight()*0.8,"Select a color");
                        _accentP._selectButton.MouseDown += _selectButton_MouseDown;
                }

                void _selectButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        _selectedColor = _accentP._selectedColor;
                        _accentP.Close();
                }

                void custom_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        _selectedTheme = Themes.CUSTOM;
                        //ThemeSelector.ChangeThemeType(Themes.CUSTOM);
                }

                void light_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        _selectedTheme = Themes.LIGHT;
                        //ThemeSelector.ChangeThemeType(Themes.LIGHT);

                }

                void dark_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        _selectedTheme = Themes.DARK;
                        //ThemeSelector.ChangeThemeType(Themes.DARK);

                }

                void ThemeItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                        foreach (var item in _themeItemlist)
                        {
                                if (item.IsMouseOver)
                                {
                                        item.Hover();
                                }
                                else
                                {
                                        item.Unhover();
                                }
                        }
                }

                public override StackPanel GetLayout()
                {
                        return _container;
                }

        }//class LayoutNinja
}//ns
