using EpicProjects.Constants;
using EpicProjects.Constants.Colors;
using EpicProjects.View.CustomControls.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class AccentSelectionPopUp : PopUp
        {
                public ScrollViewer _scroller { get; set; }
                public StackPanel _colorsContainer  { get; set; }
                public TextBlock _selectedBlock { get; set; }
                public StackPanel _actionspanel { get; set; }
                public ValidateButton _selectButton { get; set; }
                public CancelButton _closeButton { get; set; }
                public List<string> _colorsList { get; set; }
                public string  _selectedColor { get; set; }

                public AccentSelectionPopUp(double width, double height, string content):base( width,  height,  content)
                {
                        this.Background = Palette2.GetColor("#B0BEC5");

                        _scroller = new ScrollViewer();
                        _scroller.MaxHeight = 700;

                        _colorsContainer = new StackPanel();
                        _colorsContainer.Orientation = Orientation.Vertical;
                        _colorsContainer.MaxWidth = width * 0.8;

                        SetUpColorList();

                        _selectedBlock = new TextBlock();
                        _selectedBlock.FontFamily = FontProvider._lato;
                        _selectedBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _selectedBlock.FontSize = 25;
                        _selectedBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);


                        _actionspanel = new StackPanel();
                        _actionspanel.Orientation = Orientation.Horizontal;
                        _actionspanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _selectButton = new ValidateButton("Select", Dimensions.GetWidth() * 0.2, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 30, 20, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _selectButton.IsEnabled = false;

                        _closeButton = new CancelButton("Cancel", Dimensions.GetWidth() * 0.2, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 30,0 , 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _closeButton.MouseDown += _closeButton_MouseDown;

                        _actionspanel.Children.Add(_selectButton);
                        _actionspanel.Children.Add(_closeButton);

                        _scroller.Content = _colorsContainer;

                        _container.Children.Add(_scroller);
                        _container.Children.Add(_selectedBlock);
                        _container.Children.Add(_actionspanel);
                }

                private void SetUpColorList()
                {
                        _colorsList = new List<string>();
                        InitializeColorsList();

                        int colorCount = 0;
                        StackPanel colorPanel = new StackPanel();
                        colorPanel.Orientation = Orientation.Horizontal;
                        colorPanel.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                        colorPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        foreach (var item in _colorsList)
                        {
                                if (colorCount > 6)
                                {
                                        colorCount = 0;
                                        _colorsContainer.Children.Add(colorPanel);
                                        colorPanel = new StackPanel();
                                        colorPanel.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                                        colorPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                                        colorPanel.Orientation = Orientation.Horizontal;
                                }
                                ColorItem color = new ColorItem(item);
                                color.MouseDown += color_MouseDown;
                                colorPanel.Children.Add(color);
                                colorCount++;
                        }

                        _colorsContainer.Children.Add(colorPanel);
                }

                void color_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        ColorItem source = (ColorItem)sender;

                        _selectedBlock.Text = "Selected color : " + source._accent;
                        _selectedBlock.Foreground = Palette2.GetColor(source._accent);
                        _selectButton.IsEnabled = true;

                        _selectedColor = source._accent;
                }

                private void InitializeColorsList()
                {
                        _colorsList.Add(WindowsPhonePalette.AMBER);
                        _colorsList.Add(WindowsPhonePalette.BROWN);
                        _colorsList.Add(WindowsPhonePalette.COBALT);
                        _colorsList.Add(WindowsPhonePalette.CRIMSON);
                        _colorsList.Add(WindowsPhonePalette.CYAN);
                        _colorsList.Add(WindowsPhonePalette.EMERALD);
                        _colorsList.Add(WindowsPhonePalette.GREEN);
                        _colorsList.Add(WindowsPhonePalette.INDiGO);
                        _colorsList.Add(WindowsPhonePalette.LIME);
                        _colorsList.Add(WindowsPhonePalette.MAGENTA);
                        _colorsList.Add(WindowsPhonePalette.MAUVE);
                        _colorsList.Add(WindowsPhonePalette.OLIVE);
                        _colorsList.Add(WindowsPhonePalette.ORANGE);
                        _colorsList.Add(WindowsPhonePalette.PINK);
                        _colorsList.Add(WindowsPhonePalette.RED);
                        _colorsList.Add(WindowsPhonePalette.SIENNA);
                        _colorsList.Add(WindowsPhonePalette.STEEL);
                        _colorsList.Add(WindowsPhonePalette.TEAL);
                        _colorsList.Add(WindowsPhonePalette.VIOLET);
                        _colorsList.Add(WindowsPhonePalette.YELLOW);
                        _colorsList.Add(WindowsPhonePalette.LIGHT_GREY);

                        
                }

                void _closeButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }
        }//class AccentSelectionpopUp
}//ns
