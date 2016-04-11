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

using EpicProjects.Database;
using EpicProjects.Constants;

namespace EpicProjects.Sketches
{
        /// <summary>
        /// Interaction logic for Project.xaml
        /// </summary>
        public partial class Project : Window
        {

                public bool _isChecked { get; set; }
                public string _currentProject { get; set; }

                public int _id { get; set; } 

                public DatabaseGuru _g = new DatabaseGuru(Paths.PROJECTS_SAVE);

                public Project()
                {
                        InitializeComponent();
                        ShowProjects();


                }


                public void SetHeader(string name, int id)
                {
                        _currentProject = name;
                        _id = id;
                        HeaderText.Text = name;
                }


                public void ShowProjects()
                {

                        Database.DatabaseGuru gu = new Database.DatabaseGuru(Paths.PROJECTS_SAVE);


                        //List<object> res = gu._propSelector.Select("name", "project");

                        //foreach (var item in res)
                        //{
                        //       // DebugText.Inlines.Add(item.ToString() + "\n");
                        //}
                }

                private void CreateButton_Click(object sender, RoutedEventArgs e)
                {
                       // _g._propInserter.InsertTask()


                }

                private void CreateTask()
                {

                }

                private void FormationsPanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        FormationsPanel.Background = new SolidColorBrush(Colors.White);
                        FormationsText.Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 150, 243));
                }

                private void FormationsPanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        FormationsPanel.Background = new SolidColorBrush(Color.FromArgb(255, 33, 150, 243));
                        FormationsText.Foreground = new SolidColorBrush(Colors.White);
                }

                private void TasksPanel_MouseEnter(object sender, MouseEventArgs e)
                {
                       TasksPanel.Background = new SolidColorBrush(Colors.White);
                        TasksText.Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 150, 243));
                }

                private void TasksPanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        TasksPanel.Background = new SolidColorBrush(Color.FromArgb(255, 33, 150, 243));
                        TasksText.Foreground = new SolidColorBrush(Colors.White);
                }

                private void MaintenancePanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        MaintenancePanel.Background = new SolidColorBrush(Colors.White);
                        MaintenanceText.Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 150, 243));
                }

                private void MaintenancePanel_MouseLeave(object sender, MouseEventArgs e)
                {
                       MaintenancePanel.Background = new SolidColorBrush(Color.FromArgb(255, 33, 150, 243));
                        MaintenanceText.Foreground = new SolidColorBrush(Colors.White);
                }

                private void BrainstormingPanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        BrainstormingPanel.Background = new SolidColorBrush(Colors.White);
                       BrainstormingText.Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 150, 243));
                }

                private void BrainstormingPanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        BrainstormingPanel.Background = new SolidColorBrush(Color.FromArgb(255, 33, 150, 243));
                        BrainstormingText.Foreground = new SolidColorBrush(Colors.White);
                }

                private void NewProjectImage_MouseEnter(object sender, MouseEventArgs e)
                {
                        //myImage.Source = new BitmapImage(new Uri(@"/Images/foo.png", UriKind.Relative));
                        NewProjectImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/Blue/BLUE_new.png", UriKind.Relative));
                }

                private void NewProjectImage_MouseLeave(object sender, MouseEventArgs e)
                {
                        NewProjectImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/White/WHITE_new.png", UriKind.Relative));
                }

                private void OpenProjectImage_MouseEnter(object sender, MouseEventArgs e)
                {
                        OpenProjectImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/Blue/BLUE_Open.png", UriKind.Relative));
                }

                private void OpenProjectImage_MouseLeave(object sender, MouseEventArgs e)
                {
                        OpenProjectImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/White/WHITE_Open.png", UriKind.Relative));
                }

                private void StatsImage_MouseEnter(object sender, MouseEventArgs e)
                {
                       StatsImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/Blue/BLUE_stats.png", UriKind.Relative));
                }

                private void StatsImage_MouseLeave(object sender, MouseEventArgs e)
                {
                        StatsImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/White/WHITE_stats.png", UriKind.Relative));
                        
                }

                private void BugImage_MouseEnter(object sender, MouseEventArgs e)
                {
                        BugImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/Blue/BLUE_bug.png", UriKind.Relative));

                }

                private void BugImage_MouseLeave(object sender, MouseEventArgs e)
                {
                       BugImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/White/WHITE_bug.png", UriKind.Relative));

                }

                private void MenuImage_MouseEnter(object sender, MouseEventArgs e)
                {
                       MenuImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/Blue/BLUE_menu.png", UriKind.Relative));

                }

                private void MenuImage_MouseLeave(object sender, MouseEventArgs e)
                {
                        MenuImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/White/WHITE_menu.png", UriKind.Relative));

                }

                private void CheckImage_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        if (!_isChecked)
                        {
                                CheckImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/Blue/BLUE_check (2).png", UriKind.Relative));
                                _isChecked = true;
                        }
                        else
                        {
                                CheckImage.Source = new BitmapImage(new Uri(@"/Resources/Pictures/White/WHITE_unchecked.png", UriKind.Relative));
                                _isChecked = false;
                        }

                }

                private void EditButton_MouseEnter(object sender, MouseEventArgs e)
                {
                        EditButton.Source = new BitmapImage(new Uri(@"/Resources/Pictures/Blue/BLUE_edit.png", UriKind.Relative));
                }

                private void EditButton_MouseLeave(object sender, MouseEventArgs e)
                {
                        EditButton.Source = new BitmapImage(new Uri(@"/Resources/Pictures/White/WHITE_edit.png", UriKind.Relative));

                }

                private void DeleteButton_MouseEnter(object sender, MouseEventArgs e)
                {
                        DeleteButton.Source = new BitmapImage(new Uri(@"/Resources/Pictures/Blue/BLUE_delete.png", UriKind.Relative));

                }

                private void DeleteButton_MouseLeave(object sender, MouseEventArgs e)
                {
                        DeleteButton.Source = new BitmapImage(new Uri(@"/Resources/Pictures/White/WHITE_delete.png", UriKind.Relative));

                }
        }
}
