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

namespace EpicProjects.Sketches.Custom
{
        /// <summary>
        /// Interaction logic for CustomHome.xaml
        /// </summary>
        public partial class CustomHome : Window
        {
                public CustomHome()
                {
                        InitializeComponent();
                        this.KeyDown += Window_KeyDown;
                }

                private void Window_KeyDown(object sender, KeyEventArgs e)
                {
                        if(e.Key == Key.N)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        MessageBox.Show("New project OMG");
                        }

                        if(e.Key == Key.O)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        MessageBox.Show("Open project damn");
                        }

                        if (e.Key == Key.S)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        MessageBox.Show("Settings, mister no happy ?");
                        }
                }

        }
}
