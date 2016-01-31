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
using System.Windows.Navigation;
using System.Windows.Shapes;

using EpicProjects.Constants;
using EpicProjects.Database;

namespace EpicProjects
{
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
                public MainWindow()
                {
                        InitializeComponent();

                        TryColors();

                        Selector sel = new Selector();

                        string s = sel.SelectByEquality(DatabaseValues.ID, DatabaseValues.PROJECT,DatabaseValues.NAME, "AFK");

                        StringBuilder text = new StringBuilder();
                        ResultTextBlock.Inlines.Add("Test de SelectByEquality avec string : "  + s);

                        string i = sel.SelectByEquality(DatabaseValues.NAME, DatabaseValues.PROJECT, DatabaseValues.ID, 5);
                        ResultTextBlock.Inlines.Add("\n Test de SelectByEquality avec int : "  +i);

                        string c = sel.SelectCount(DatabaseValues.PROJECT).ToString();

                        ResultTextBlock.Inlines.Add("\n Test de SelectCount : " + c);
                     
                }

                public void TryColors()
                {
                        SolidColorBrush col = new SolidColorBrush(Color.FromArgb(255, 210, 82, 127));

                        toppanel.Background = col;
                        text.Foreground = col;

                        button1.Foreground = col;
                        button1.BorderBrush = col;

                        button2.Foreground = col;
                        button2.BorderBrush = col;

                        button3.Foreground = col;
                        button3.BorderBrush = col;
                        
                }
        }
}
