using EpicProjects.Constants;
using EpicProjects.View.CustomControls;
using EpicProjects.View.CustomControls.Items;
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
                public StackPanel _container { get; set; }
                public TextBlock _titleBlock{ get; set; }
                public Separator _separator { get; set; }

                public StackPanel _themesPanel { get; set; }
                public ValidateButton _changeColor { get; set; }

                public List<ThemeItem> _themeItemlist { get; set; }




                public ThemeLayoutNinja()
                {
                        _container = new StackPanel();
                        _container.Orientation = Orientation.Vertical;

                        _titleBlock = new TextBlock();
                        _titleBlock.Text = "Theme selection";
                        _titleBlock.FontFamily = FontProvider._lato;
                        _titleBlock.FontSize = 25;
                        _titleBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);

                        _separator = new Separator();
                        _separator.Width = Dimensions.GetWidth() * 0.5;
                        _separator.Background = new Theme.CustomTheme().GetBackground();

                        _themesPanel = new StackPanel();
                        _themesPanel.Orientation = Orientation.Horizontal;
                        _themesPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _themeItemlist = new List<ThemeItem>();

                        ThemeItem dark = new ThemeItem("Dark", Palette2.MIDNIGHT_BLUE);
                        _themesPanel.Children.Add(dark);
                        _themeItemlist.Add(dark);
                        dark.MouseDown += ThemeItem_MouseDown;

                        ThemeItem light = new ThemeItem("Light", Palette2.LIGHT_GRAY);
                        _themesPanel.Children.Add(light);
                        _themeItemlist.Add(light);
                        light.MouseDown += ThemeItem_MouseDown;


                        ThemeItem custom = new ThemeItem("Custom", Palette2.ALIZARIN);
                        _themesPanel.Children.Add(custom);
                        _themeItemlist.Add(custom);
                        custom.MouseDown += ThemeItem_MouseDown;

                        _changeColor = new  ValidateButton("Change accent color", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight()* 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());


                        _container.Children.Add(_titleBlock);
                        _container.Children.Add(_separator);
                        _container.Children.Add(_themesPanel);
                        _container.Children.Add(_changeColor);


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
