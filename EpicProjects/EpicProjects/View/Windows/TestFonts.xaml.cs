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
                        //Fonts.GetFontFamilies(new Uri("pack://application:,,,/Resources/Fonts/#"));

                        //NOTE  : if doesn't work, try replacing the font names with the file names
                        //NOTE : I DID THAT, DID NOT WORK :'(

                        EdmondSans.FontFamily = Xedmond.FontFamily;

                        ProximaNova.FontFamily = Xproxima.FontFamily;
                        Raleway.FontFamily = Xraleway.FontFamily;
                        Calibri.FontFamily = Xcalibri.FontFamily;
                        Cambria.FontFamily = Xcambria.FontFamily;
                        Segoe.FontFamily = Xsegoe.FontFamily;
                        OpenSans.FontFamily = Xopen.FontFamily;
                        Lato.FontFamily = Xlato.FontFamily;
                        Aller.FontFamily = Xaller.FontFamily;
                        Aleo.FontFamily = Xaleo.FontFamily;
                        Bariol.FontFamily = Xbariol.FontFamily;

                        XPanel.Visibility = System.Windows.Visibility.Hidden;

                }
        }
}
