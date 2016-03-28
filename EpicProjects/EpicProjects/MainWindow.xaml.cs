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

                        DatabaseGuru guru = new DatabaseGuru(Paths.PROJECTSSAVE);





                        //Test insert

                        guru._propInserter.InsertProject("ARK mod", DateTime.Now.ToString("DD:MM:YYYY"), DateTime.Now.ToString("DD::MM::YYYY"));

                        //Test update



                        guru._propUpdater.UpdateName(3,"project", "NOUVEAUNom");



                        //Test Delete

                        guru._propDeleter.DeleteOnId(4,"project");

                        ResultTextBlock.Inlines.Add("---------------Projects------------\n");

                        List<string> list = guru._propSelector.SelectProjects();

                        foreach (string item in list)
                        {
                                ResultTextBlock.Inlines.Add("\n " + item);
                        }



                        ResultTextBlock.Inlines.Add("\n---------------------TASKS ----------------\n");
                        //Test SelectMultipleByEquality
                        //List<string> res = guru._propSelector.SelectMultipleByEquality("name", "task", "projectid", 2);

                        //foreach (var item in res)
                        //{
                        //        ResultTextBlock.Inlines.Add("\n" + item);
                        //}


                        //Test Update tasks
                        
                        guru._propUpdater.UpdateName(2, "task", "Clean code");
                        //Test Insert tasks
                        //guru._propInserter.InsertTask("Mettre tout en flat", DateTime.Now.ToString(), "task", 3, 5);

                        //Test delete

                        guru._propDeleter.DeleteOnId(4, "task");

                        //List<Object> res = guru._propSelector.Select("name", "task");

                        //foreach (var item in res)
                        //{
                        //        ResultTextBlock.Inlines.Add("\n" + item);
                        //}

                        


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
