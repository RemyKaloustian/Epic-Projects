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

namespace EpicProjects.View.Windows
{
        /// <summary>
        /// Interaction logic for TestFonts.xaml
        /// </summary>
        public partial class TestFonts : Window
        {
                public TestFonts()
                {
                        InitializeComponent();
                        Fonts.GetFontFamilies(new Uri("pack://application:,,,/Resources/Fonts/#"));

                        //NOTE  : if doesn't work, try replacing the font names with the file names
                        //NOTE : I DID THAT, DID NOT WORK :'(

                        EdmondSans.FontFamily = new FontFamily("edmond");
                        
                        ProximaNova.FontFamily = new FontFamily("proxima");
                        Raleway.FontFamily = new FontFamily("raleway");
                        Calibri.FontFamily = new FontFamily("Calibri Light");
                        Cambria.FontFamily = new FontFamily("cambria");
                        Segoe.FontFamily = new FontFamily("segoe");
                        OpenSans.FontFamily = new FontFamily("open");
                        Lato.FontFamily = new FontFamily("Lato Light");
                        Aller.FontFamily = new FontFamily("aller");
                        Aleo.FontFamily = new FontFamily("aleo");
                        Bariol.FontFamily = new FontFamily("bariol");

                }
        }
}
