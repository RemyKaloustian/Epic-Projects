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

                        DatabaseGuru guru = new DatabaseGuru();

                        

                       

                        //Test insert

                        guru._propInserter.InsertProject("ARK mod", DateTime.Now.ToString("DD:MM:YYYY"), DateTime.Now.ToString("DD::MM::YYYY"));

                        //Test update

                       

                        guru._propUpdater.UpdateProjectName(3, "NOUVEAUNom");

                       

                        //Test Delete

                        guru._propDeleter.DeleteOnId(4);


                        List<Object> list = guru._propSelector.Select("name", "project");

                        foreach (string item in list)
                        {
                                ResultTextBlock.Inlines.Add("\n " + item);
                        }

                     
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
