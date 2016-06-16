using EpicProjects.Constants;
using EpicProjects.Constants.Colors;
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
                public CancelButton _cancelButton{ get; set; }

                public List<ThemeItem> _themeItemlist { get; set; }

                public string _selectedTheme { get; set; }
                public string  _selectedColor{ get; set; }
                public string _previous { get; set; }

                /// <summary>
                /// Constructor
                /// </summary>
                /// <param name="previous">The previous project</param>
                public ThemeLayoutNinja(string previous)
                {

                        _previous = previous;
                        _container = new StackPanel();
                        _container.Orientation = Orientation.Vertical;

                        SetUpTitleBlock();

                        SetUpSeparator();

                        SetUpThemesPanel();

                        _themeItemlist = new List<ThemeItem>();



                        ThemeItem dark = new ThemeItem("Dark", Palette2.GetColor("#2c3e50"),ThemeSelector._lastSavedAccent);
                        _themesPanel.Children.Add(dark);
                        _themeItemlist.Add(dark);
                        dark.MouseDown += ThemeItem_MouseDown;
                        dark.MouseDown += dark_MouseDown;

                        string color = "#f5f5f5";

                        Constants.Printer.CW("The accent color is : " + ThemeSelector._accent);

                        Constants.Printer.CW("Comparison result : " + (ThemeSelector._accent == color));

                        ThemeItem light = null;

                        if (ThemeSelector._accent == color)
                        {
                                color = Palette2.MIDNIGHT_BLUE;
                                 light = new ThemeItem("Light", Palette2.GetColor(WindowsPhonePalette.LIGHT_GREY) , Palette2.GetColor(color));
                        }
                        else
                        {
                                light = new ThemeItem("Light", Palette2.GetColor("#f5f5f5"), ThemeSelector._lastSavedAccent);
                        }

                        
                        _themesPanel.Children.Add(light);
                        _themeItemlist.Add(light);
                        light.MouseDown += ThemeItem_MouseDown;
                        light.MouseDown += light_MouseDown;


                         color = "#f5f5f5";
                         ThemeItem custom = null;
                         if (ThemeSelector._accent == color)
                         {
                                 color = WindowsPhonePalette.SOLID_GREY;  
                                 custom = new ThemeItem("Custom", Palette2.GetColor(color), Palette2.GetColor(WindowsPhonePalette.LIGHT_GREY));

                         }

                         else
                         {
                                 custom = new ThemeItem("Custom", ThemeSelector._lastSavedAccent, Palette2.GetColor("#f5f5f5"));
                         }
                        _themesPanel.Children.Add(custom);
                        _themeItemlist.Add(custom);
                        custom.MouseDown += ThemeItem_MouseDown;
                        custom.MouseDown += custom_MouseDown;


                        SetUpColorTitle();

                        SetUpColorSeparator();

                        SetUpButtons();
                        
                        _container.Children.Add(_titleBlock);
                        _container.Children.Add(_separator);
                        _container.Children.Add(_themesPanel);
                        _container.Children.Add(_colorTitle);
                        _container.Children.Add(_colorSeparator);
                        _container.Children.Add(_changeColor);
                        _container.Children.Add(_applyButton);
                        _container.Children.Add(_cancelButton);


                }

                private void SetUpButtons()
                {
                        _changeColor = new DefaultButton("Change accent color", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _changeColor.MouseDown += _changeColor_MouseDown;


                        _applyButton = new ValidateButton("Apply Changes", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _applyButton.MouseDown += _applyButton_MouseDown;

                        _cancelButton = new CancelButton("Cancel", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _cancelButton.MouseDown += _cancelButton_MouseDown;
                }

                private void SetUpColorSeparator()
                {
                        _colorSeparator = new Separator();
                        _colorSeparator.Width = Dimensions.GetWidth() * 0.5;
                        _colorSeparator.Background = ThemeSelector.GetBackground();
                }

                private void SetUpColorTitle()
                {
                        _colorTitle = new TextBlock();
                        _colorTitle.Text = "Color selection";
                        _colorTitle.FontFamily = FontProvider._lato;
                        _colorTitle.FontSize = 25;
                        _colorTitle.Foreground = ThemeSelector.GetBackground();
                        _colorTitle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _colorTitle.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }

                private void SetUpThemesPanel()
                {
                        _themesPanel = new StackPanel();
                        _themesPanel.Orientation = Orientation.Horizontal;
                        _themesPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                }

                private void SetUpSeparator()
                {
                        _separator = new Separator();
                        _separator.Width = Dimensions.GetWidth() * 0.5;
                        _separator.Background = ThemeSelector.GetBackground();
                }

                private void SetUpTitleBlock()
                {

                        _titleBlock = new TextBlock();
                        _titleBlock.Text = "Theme selection";
                        _titleBlock.FontFamily = FontProvider._lato;
                        _titleBlock.FontSize = 25;
                        _titleBlock.Foreground = ThemeSelector.GetBackground();
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }

                void _cancelButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        new Captain().ToSettings(_previous);
                }

                void _applyButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if(_selectedTheme != null)
                        {
                                ThemeSelector.ChangeThemeType(_selectedTheme);
                        }

                        if (_selectedColor != null)
                        {
                                //Light Theme case with selected accent f5f5f5 : if light grey is selected and the current theme is Light or the new theme is light
                                if(_accentP._selectedColor == WindowsPhonePalette.LIGHT_GREY &&( (_selectedTheme == null && ThemeSelector._theme.GetType() == typeof (LightTheme ) || (_selectedTheme == Themes.LIGHT))))
                                {
                                        ThemeSelector.ChangeAccent(WindowsPhonePalette.SOLID_GREY);
                                }
                                //Custom Theme case
                                else if (_accentP._selectedColor == WindowsPhonePalette.LIGHT_GREY && (_selectedTheme == null && ThemeSelector._theme.GetType() == typeof(CustomTheme) || (_selectedTheme == Themes.CUSTOM)))
                                {
                                        ThemeSelector.ChangeAccent(WindowsPhonePalette.SOLID_GREY);

                                }
                                else
                                {
                                        ThemeSelector.ChangeAccent(_accentP._selectedColor);

                                }
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
                }//ThemeItem_MouseDown()

                public override StackPanel GetLayout()
                {
                        return _container;
                }//GetLayout()

        }//class LayoutNinja
}//ns
