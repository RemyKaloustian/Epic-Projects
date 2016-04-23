using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using EpicProjects.Controller;
using EpicProjects.Database;
using EpicProjects.Constants;
using EpicProjects.View.CustomControls;
using EpicProjects.View.Layout;
using EpicProjects.View.Windows;
using EpicProjects.Exception;
using EpicProjects.View.Theme;
using EpicProjects.View.CustomControls.PopUp;

namespace EpicProjects.View
{
        /// <summary>
        /// Interaction logic for Home.xaml
        /// </summary>
        public partial class Home : Window
        {
                public Masterchief _chief { get; set; }
                public HomeLayoutNinja _ninja { get; set; }

                public StackPanel _mainPanel { get; set; }

                public Home()
                {
                        try
                        {
                                //View.Debug.Debug maDeb = new Debug.Debug();
                                //maDeb.Show();

                                //Sketches.Dark.DarkProject darkP = new Sketches.Dark.DarkProject();
                                //darkP.Show();

                                //Sketches.Light.LightProject lightP = new Sketches.Light.LightProject();
                                //lightP.Show();


                                InitializeComponent();
                                this.Show();
                                SetFonts();
                                SetDimensions();
                                ThemeSelector.InitializeTheme();

                                TestFonts t = new TestFonts();
                               // t.Show();


                                FontsHolder.Visibility = System.Windows.Visibility.Hidden;

                                _chief = new Masterchief();
                                _ninja = new HomeLayoutNinja();
                                _mainPanel = new StackPanel();
                                _mainPanel = _ninja.GetLayout();

                                MainGrid.Children.Add(_mainPanel);

                                this.KeyDown += Home_KeyDown;
                                SetClickHandling();


                        }
                        catch (System.Exception e)
                        {

                                LaunchException l = new LaunchException(e.Message, e.ToString(), e.Data.Values.ToString());
                        }


                }//Home()...family, future

                private void SetFonts()
                {
                        FontProvider._aleo = Xaleo.FontFamily;
                        FontProvider._aller = Xaller.FontFamily;
                        FontProvider._bariol = Xbariol.FontFamily;
                        FontProvider._calibri = Xcalibri.FontFamily;
                        FontProvider._cambria = Xcambria.FontFamily;
                        FontProvider._code = Xcode.FontFamily;
                        FontProvider._edmond = Xedmond.FontFamily;
                        FontProvider._lato = Xlato.FontFamily;
                        FontProvider._open = Xopen.FontFamily;
                        FontProvider._proxima = Xproxima.FontFamily;
                        FontProvider._raleway = Xraleway.FontFamily;
                        FontProvider._segoe = Xsegoe.FontFamily;
                        FontProvider._droid = Xdroid.FontFamily;
                        FontProvider._consolas = Xconsolas.FontFamily;
                        FontProvider._mido = Xmido.FontFamily;
                }



                /// <summary>
                /// Sets the dimensions of the window
                /// </summary>
                private void SetDimensions()
                {
                        
                        this.Width = Dimensions.GetWidth();
                        this.Height = Dimensions.GetHeight();
                        this.MinHeight = Dimensions.GetHeight();
                        this.MinWidth = Dimensions.GetWidth();
                        this.ResizeMode = System.Windows.ResizeMode.CanResize;
                        this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        this.WindowState = WindowState.Maximized;
                        this.Title = WindowsTitle.HOME_TITLE;
                }

                private void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
                {
                        //Useless for now
                        //  _mainPanel = _ninja.GetLayout();
                }//SetDimensions()


                #region Key_Handling

                void Home_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Key == Key.N)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        _mainPanel = _ninja.GetNewProjectPanel();
                        }

                        if (e.Key == Key.O)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        _mainPanel = _ninja.GetOpenProjectPanel();
                        }


                        if (e.Key == Key.S)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        new Captain().ToSettings("home");
                        }



                        if (e.Key == Key.B)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                {
                                        ReportBug rep = new ReportBug(Dimensions.GetWidth() * 0.5, Dimensions.GetHeight() * 0.8, "Report a bug");
                                }
                        }

                }

                void SetClickHandling()
                {
                        _ninja._newProjectItem.MouseDown += ShowNewProject;
                        _ninja._openProjectItem.MouseDown += ShowOpenProject;
                }

                #endregion


                #region LayoutChange
                void ShowNewProject(object sender, MouseButtonEventArgs e)
                {
                        _mainPanel = _ninja.GetOpenProjectPanel();


                }

                void ShowOpenProject(object sender, MouseButtonEventArgs e)
                {
                        _mainPanel = _ninja.GetNewProjectPanel();

                }



                #endregion





        }//class Home.xaml
}//ns
