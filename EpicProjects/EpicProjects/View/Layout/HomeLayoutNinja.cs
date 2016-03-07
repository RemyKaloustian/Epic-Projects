using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using EpicProjects.View.Theme;
using EpicProjects.Constants;
using System.Windows.Media;
using EpicProjects.View.CustomControls;
using EpicProjects.View.CustomControls.Home;
using EpicProjects.Controller;


namespace EpicProjects.View.Layout
{
        public class HomeLayoutNinja : LayoutNinja
        {
                public Theme.Theme _theme { get; set; }
                public Masterchief _chief { get; set; }

                public StackPanel _mainPanel { get; set; }
                public StackPanel _containerPanel { get; set; }

                public StackPanel _headerPanel { get; set; }

                public TextBlock _windowTitle{ get; set; }
                public TextBlock _catchPhrase { get; set; }

                public Separator _headerSeparator { get; set; }

                public StackPanel _itemsPanel { get; set; }

                public Separator _itemsSeparator { get; set; }

                public StackPanel _latestProjectsPanel { get; set; }
                public TextBlock _latestBlock { get; set; }

                public HomeLayoutNinja()
                {
                        _theme = new CustomTheme();
                        _chief = new Masterchief();
                        SetUpMainAndContainer();

                        SetUpHeader();

                        SetUpItems();

                        SetUpLatestProjects();

                }//HomeLayoutNinja()

                private void SetUpLatestProjects()
                {
                        _latestProjectsPanel = new StackPanel();
                        _latestProjectsPanel.Orientation = Orientation.Vertical;
                        _latestProjectsPanel.Width = _containerPanel.Width;

                        _latestBlock = new TextBlock();
                        _latestBlock.Text = "Latest Projects";
                        _latestBlock.FontFamily = new FontFamily("Edmondsans Regular");
                        _latestBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _latestBlock.FontSize = 45;
                        _latestBlock.Foreground = _theme.GetAccentColor();
                        _latestBlock.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);


                        _latestProjectsPanel.Children.Add(_latestBlock);

                        List<string> latestProjects = _chief.GetLatestProjects().GetRange(0, 4);

                        foreach (var item in latestProjects)
                        {
                                ProjectLink link = new ProjectLink(item, _theme.GetAccentColor());
                                _latestProjectsPanel.Children.Add(link);
                        }


                        _containerPanel.Children.Add(_latestProjectsPanel);
                }

                private void SetUpItems()
                {
                        _itemsPanel = new StackPanel();
                        _itemsPanel.Orientation = Orientation.Horizontal;
                        _itemsPanel.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);

                        _itemsPanel.Children.Add(new HomeItem(@"/Resources/Pictures/WhiteEEEEEE/WhiteEEEEEE_gear.png", "CTRL + S", _theme, _containerPanel.Width / 5, "Settings"));
                        _itemsPanel.Children.Add(new HomeItem(@"/Resources/Pictures/WhiteEEEEEE/WhiteEEEEEE_open.png", "CTRL + O", _theme, _containerPanel.Width / 5, "Open project"));
                        _itemsPanel.Children.Add(new HomeItem(@"/Resources/Pictures/WhiteEEEEEE/WhiteEEEEEE_new.png", "CTRL + N", _theme, _containerPanel.Width / 5, "New project"));
                        _itemsPanel.Children.Add(new HomeItem(@"/Resources/Pictures/WhiteEEEEEE/WhiteEEEEEE_doc.png", "CTRL + D", _theme, _containerPanel.Width / 5, "Documentation"));
                        _itemsPanel.Children.Add(new HomeItem(@"/Resources/Pictures/WhiteEEEEEE/WhiteEEEEEE_bug.png", "CTRL + R", _theme, _containerPanel.Width / 5, "Report bug"));

                        _itemsSeparator = new Separator();
                        _itemsSeparator.Width = _containerPanel.Width;
                        _itemsSeparator.Background = _theme.GetAccentColor();
                        _itemsSeparator.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 20, 0, 0);



                        _containerPanel.Children.Add(_itemsPanel);
                        _containerPanel.Children.Add(_itemsSeparator);
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
                        _windowTitle.FontSize = 82;
                        _windowTitle.Padding = new System.Windows.Thickness(0, Convert.ToDouble(Dimensions.GetHeight() / 40), 0, 0);
                }

                private void SetUpMainAndContainer()
                {
                        _mainPanel = new StackPanel();
                        _containerPanel = new StackPanel();
                        _containerPanel.Orientation = Orientation.Vertical;
                        _containerPanel.Height = Dimensions.GetHeight();
                        _containerPanel.Width = Dimensions.GetWidth() * 0.9;
                       // _containerPanel.Background = new SolidColorBrush(Colors.Black);


                        _mainPanel.Children.Add(_containerPanel);
                        _mainPanel.Background = _theme.GetBackground();
                }
                public override StackPanel GetLayout()
                {
                        return _mainPanel;
                }
        }//class HomeLayoutNinja
}//ns
