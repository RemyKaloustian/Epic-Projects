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
                        View.Debug.Debug maDeb = new Debug.Debug();
                        maDeb.Show();
                        InitializeComponent();



                        SetDimensions();

                        _chief = new Masterchief();
                        _ninja = new HomeLayoutNinja();
                        _mainPanel = new StackPanel();

                       

                        _mainPanel = _ninja.GetLayout(); 
                        
                        MainGrid.Children.Add(_mainPanel);

                        this.KeyDown += Home_KeyDown;

                }//Home()...family, future

               

                /// <summary>
                /// Sets the dimensions of the window
                /// </summary>
                private void SetDimensions()
                {
                        this.Width = Dimensions.GetWidth();
                        this.Height = Dimensions.GetHeight();
                }

                private void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
                {
                        _mainPanel = _ninja.GetLayout();
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
                        
                }
                #endregion

             

            
         
        }//class Home.xaml
}//ns
