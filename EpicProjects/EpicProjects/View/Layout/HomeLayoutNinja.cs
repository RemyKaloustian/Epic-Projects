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
using System.Windows.Input;
using System.Windows;


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

                public StackPanel _subContainer { get; set; }

                public StackPanel _latestProjectsPanel { get; set; }
                public TextBlock _latestBlock { get; set; }
                public Separator _latestSeparator { get; set; }

                public StackPanel _footerPanel { get; set; }
                public TextBlock _remyBlock { get; set; }
                public TextBlock _siteBlock{ get; set; }

                public StackPanel _createProjectButton { get; set; }
                public StackPanel  _quitProjectButton{ get; set; }

                public HomeLayoutNinja()
                {
                        _theme = new CustomTheme();
                        _chief = new Masterchief();

                        
                        SetUpMainAndContainer();

                        SetUpHeader();

                        SetUpItems();

                        SetUpLatestProjects();

                        SetUpFooter();
                        
                }//HomeLayoutNinja()



# region Layout_Handling

                private void SetUpFooter()
                {
                        _footerPanel = new StackPanel();
                        _footerPanel.Orientation = Orientation.Vertical;

                        _remyBlock = new TextBlock();
                        _remyBlock.Text = "Created by Rémy Kaloustian | remykaloustian.com";
                        _remyBlock.Foreground = _theme.GetAccentColor();
                        _remyBlock.FontFamily = new FontFamily("Lato Light");
                        _remyBlock.FontSize = 20;
                        _remyBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _remyBlock.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);


                        _siteBlock = new TextBlock();
                        _siteBlock.Text = "http://remykaloustian.com/epicprojects (Coming soon)";
                        _siteBlock.Foreground = _theme.GetAccentColor();
                        _siteBlock.FontFamily = new FontFamily("Lato Light");
                        _siteBlock.FontSize = 20;
                        _siteBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _siteBlock.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);


                        _footerPanel.Children.Add(_remyBlock);
                        _footerPanel.Children.Add(_siteBlock);

                        _subContainer.Children.Add(_footerPanel);
                }

                private void SetUpLatestProjects()
                {
                        _subContainer = new StackPanel();
                        _subContainer.Orientation = Orientation.Vertical;


                        _latestProjectsPanel = new StackPanel();
                        _latestProjectsPanel.Orientation = Orientation.Vertical;
                        _latestProjectsPanel.Width = _containerPanel.Width;

                        SetUpLatestTitle();                        
                        SetUpLatestProjectsNames();
                        SetUpLatestSeparator();

                        _subContainer.Children.Add(_latestProjectsPanel);

                        _containerPanel.Children.Add(_subContainer);
                }

                #region SetUp
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

                private void SetUpWindowTitle()
                {
                        _windowTitle.Text = "EPIC PROJECTS";
                        _windowTitle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _windowTitle.FontFamily = new FontFamily("CODE LIGHT");
                        _windowTitle.Foreground = _theme.GetAccentColor();
                        _windowTitle.FontSize = 82;
                        _windowTitle.Padding = new System.Windows.Thickness(0, Convert.ToDouble(Dimensions.GetHeight() / 40), 0, 0);
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

                private void FillHeader()
                {
                        _headerPanel = new StackPanel();
                        _headerPanel.Orientation = Orientation.Vertical;
                        _headerPanel.Children.Add(_windowTitle);
                        _headerPanel.Children.Add(_catchPhrase);
                        _headerPanel.Children.Add(_headerSeparator);

                        _containerPanel.Children.Add(_headerPanel);
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
                        //Bacause it would be displayed horizontally
                        _containerPanel.Children.Add(_itemsSeparator);

                }

                private void SetUpLatestTitle()
                {

                        _latestBlock = new TextBlock();
                        _latestBlock.Text = "Latest Projects";
                        _latestBlock.FontFamily = new FontFamily("Edmondsans Regular");
                        _latestBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _latestBlock.FontSize = 45;
                        _latestBlock.Foreground = _theme.GetAccentColor();
                        _latestBlock.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);

                        _latestProjectsPanel.Children.Add(_latestBlock);
                }

                private void SetUpLatestProjectsNames()
                {
                        List<string> latestProjects = _chief.GetLatestProjects().GetRange(0, 1);

                        foreach (var item in latestProjects)
                        {
                                ProjectLink link = new ProjectLink(item, _theme.GetAccentColor());
                                _latestProjectsPanel.Children.Add(link);
                        }
                }

                private void SetUpLatestSeparator()
                {

                        _latestSeparator = new Separator();
                        _latestSeparator.Width = _containerPanel.Width;
                        _latestSeparator.Background = _theme.GetAccentColor();
                        _latestSeparator.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);

                        _latestProjectsPanel.Children.Add(_latestSeparator);
                }
                #endregion

                #region layout
                public override StackPanel GetLayout()
                {
                        return _mainPanel;
                }

                public StackPanel GetNewProjectPanel()
                {
                        _createProjectButton = new StackPanel();
                        _createProjectButton.MouseDown += _createProjectButton_MouseDown;
                        _createProjectButton.MouseEnter += _createProjectButton_MouseEnter;
                        _createProjectButton.MouseLeave += _createProjectButton_MouseLeave;
                        _quitProjectButton = new StackPanel();
                        _quitProjectButton.MouseDown += _quitProjectButton_MouseDown;
                        _quitProjectButton.MouseEnter += _quitProjectButton_MouseEnter;
                        _quitProjectButton.MouseLeave += _quitProjectButton_MouseLeave;
                        _subContainer = new CustomControls.Home.NewProjectPanel(_createProjectButton, _quitProjectButton,_theme, _containerPanel.Width);
                        ReloadLayout();
                        return _mainPanel;
                       
                }

                public StackPanel GetOpenProjectPanel()
                {
                        OpenProjectPanel openProjectPanel = new CustomControls.Home.OpenProjectPanel(_chief._guru._propSelector.SelectProjects(),_theme, _containerPanel.Width);

                        _subContainer = openProjectPanel;

                        openProjectPanel._leaveButton.MouseDown += _leaveButton_MouseDown;

                        ReloadLayout();
                        return _mainPanel;
                } 

                private void RestoreDefaultLayout()
                {
                        this.SetUpLatestProjects();
                        this.SetUpFooter();
                        this.ReloadLayout();
                }

                private void ReloadLayout()
                {
                        _containerPanel.Children.Clear();
                        _containerPanel.Children.Add(_headerPanel);
                        _containerPanel.Children.Add(_itemsPanel);
                        _containerPanel.Children.Add(_itemsSeparator);
                        _containerPanel.Children.Add(_subContainer);
                }
                #endregion


                #region events
                void _leaveButton_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        this.RestoreDefaultLayout();
                }

                void _quitProjectButton_MouseLeave(object sender, MouseEventArgs e)
                {
                        _quitProjectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL));
                }

                void _quitProjectButton_MouseEnter(object sender, MouseEventArgs e)
                {
                        _quitProjectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL_HOVER));
                }

                void _createProjectButton_MouseLeave(object sender, MouseEventArgs e)
                {
                        _createProjectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.VALIDATE));
                }

                void _createProjectButton_MouseEnter(object sender, MouseEventArgs e)
                {
                        _createProjectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.VALIDATE_HOVER));
                }

                void _quitProjectButton_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        RestoreDefaultLayout();
                }


                void _createProjectButton_MouseDown(object sender, MouseButtonEventArgs e)
                {
                       // _chief.InsertProject((NewProjectPanel)_subContainer.)
                }
                #endregion



#endregion


        }//class HomeLayoutNinja
}//ns
