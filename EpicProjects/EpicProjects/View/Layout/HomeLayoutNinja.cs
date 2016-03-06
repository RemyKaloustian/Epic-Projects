using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using EpicProjects.View.Theme;
using EpicProjects.Constants;
using System.Windows.Media;

namespace EpicProjects.View.Layout
{
        public class HomeLayoutNinja : LayoutNinja
        {
                public Theme.Theme _theme { get; set; }

                public StackPanel _mainPanel { get; set; }
                public StackPanel _containerPanel { get; set; }

                public StackPanel _headerPanel { get; set; }

                public TextBlock _windowTitle{ get; set; }
                public TextBlock _catchPhrase { get; set; }

                public Separator _headerSeparator { get; set; }

                public HomeLayoutNinja()
                {
                        _theme = new CustomTheme();
                        SetUpMainAndContainer();

                        SetUpHeader();

                }

                private void SetUpHeader()
                {
                        _windowTitle = new TextBlock();
                        _catchPhrase = new TextBlock();
                        _headerSeparator = new Separator();

                        SetUpWindowTitle();

                        SetUpCatchPhrase();

                        _headerSeparator.Width = _containerPanel.Width;
                        _headerSeparator.Background = _theme.GetAccentColor();

                        FillHeader();
                }

                private void FillHeader()
                {
                        _headerPanel = new StackPanel();
                        _headerPanel.Orientation = Orientation.Vertical;
                        _headerPanel.Children.Add(_windowTitle);
                        _headerPanel.Children.Add(_catchPhrase);
                        _headerPanel.Children.Add(_headerSeparator);

                        _containerPanel.Children.Add(_headerPanel);
                }

                private void SetUpCatchPhrase()
                {
                        _catchPhrase.Text = "Lead your projects like a winner.";
                        _catchPhrase.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _catchPhrase.FontFamily = new FontFamily("Edmondsans Regular");
                        _catchPhrase.Foreground = _theme.GetAccentColor();
                        _catchPhrase.FontSize = 40;
                        _catchPhrase.Padding = new System.Windows.Thickness(0, Convert.ToDouble(Dimensions.GetHeight() / 50), 0, Convert.ToDouble(Dimensions.GetHeight() / 50));
                }

                private void SetUpWindowTitle()
                {
                        _windowTitle.Text = "EPIC PROJECTS";
                        _windowTitle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _windowTitle.FontFamily = new FontFamily("CODE LIGHT");
                        _windowTitle.Foreground = _theme.GetAccentColor();
                        _windowTitle.FontSize = 70;
                        _windowTitle.Padding = new System.Windows.Thickness(0, Convert.ToDouble(Dimensions.GetHeight() / 40), 0, 0);
                }

                private void SetUpMainAndContainer()
                {
                        _mainPanel = new StackPanel();
                        _containerPanel = new StackPanel();
                        _containerPanel.Orientation = Orientation.Vertical;
                        _containerPanel.Height = Dimensions.GetHeight();
                        _containerPanel.Width = Dimensions.GetWidth() * 0.9;
                        _containerPanel.Background = new SolidColorBrush(Colors.Black);


                        _mainPanel.Children.Add(_containerPanel);
                        _mainPanel.Background = _theme.GetBackground();
                }
                public override StackPanel GetLayout()
                {
                        return _mainPanel;
                }
        }//class HomeLayoutNinja
}//ns
