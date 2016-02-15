using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


using EpicProjects.Database;
using EpicProjects.Constants;
using System.Windows.Media;
using EpicProjects.View.CustomControls;
using EpicProjects.Model;

namespace EpicProjects.Controller
{
        public class Masterchief
        {
                public DatabaseGuru _guru { get; set; }

                public Masterchief ()
	        {
                        _guru = new   DatabaseGuru ();
	        }//Masterchief()

                public List<string> GetLatestProjects()
                {
                        return _guru._propSelector.SelectLatestProjects();
                }

                public void InsertProject(string name, string startDate, string endDate)
                {
                        Project brandNew = new Project(name, startDate, endDate);
                }

                

                void quitButton_Click(object sender, System.Windows.RoutedEventArgs e)
                {
                        //Clearing the leftPanel
                        StackPanel leftPanel = VisualTreeHelper.GetParent((Button)sender) as StackPanel;
                        leftPanel.Children.Clear();

                        //Adding the default buttons
                        AddMenuButtons(leftPanel);

                }

                private void AddMenuButtons(StackPanel element)
                {
                        //Creating the controls
                        Button newProjectButton = new Button();
                        newProjectButton.Content = "New Project";
                        //newProjectButton.Click += ShowNewProjectA;
                        //Adding the controls to the leftPanel
                        element.Children.Add(newProjectButton);
                }

                /*private void ShowNewProjectA(object sender, System.Windows.RoutedEventArgs e)
                {
                        //Clearing the left Panel
                        LeftPanel.Children.Clear();

                        //Creating the controls
                        TextBlock nameBlock = new TextBlock();
                        nameBlock.Inlines.Add(ControlsValues.NAME);

                        TextBox nameBox = new TextBox();

                        TextBlock startBlock = new TextBlock();
                        nameBlock.Inlines.Add(ControlsValues.STARTDATE);

                        DatePicker startPicker = new DatePicker();

                        TextBlock endBlock = new TextBlock();
                        nameBlock.Inlines.Add(ControlsValues.ENDATE);

                        DatePicker endPicker = new DatePicker();

                        Button createButton = new Button();
                        createButton.Content = ControlsValues.CREATE;
                        createButton.Click += createButton_Click;

                        Button quitButton = new Button();
                        quitButton.Content = "Quit";
                        quitButton.Click += quitButton_Click;

                        //Adding the controls to the leftPanel
                        LeftPanel.Children.Add(nameBlock);
                        LeftPanel.Children.Add(nameBox);
                        LeftPanel.Children.Add(startBlock);
                        LeftPanel.Children.Add(startPicker);
                        LeftPanel.Children.Add(endBlock);
                        LeftPanel.Children.Add(endPicker);
                        LeftPanel.Children.Add(createButton);
                        LeftPanel.Children.Add(quitButton);
                }*/

                void createButton_Click(object sender, System.Windows.RoutedEventArgs e)
                {
                        //Getting the parent
                         StackPanel leftPanel = VisualTreeHelper.GetParent((Button)sender) as StackPanel;
                      //Getting the controls
                        TextBox nameBox = leftPanel.Children.OfType<TextBox>().FirstOrDefault();

                        string name = nameBox.Text;

                        DatePicker startPick = leftPanel.Children.OfType<DatePicker>().FirstOrDefault();
                        string startDate = startPick.Text;

                        DatePicker endPick = leftPanel.Children.OfType<DatePicker>().Last();
                        string endDate = endPick.Text;

                        //Inserting the project
                        _guru._propInserter.InsertProject(name, startDate, endDate);
                }

                public NewProjectPanel GetNewProjectPanel()
                {
                        NewProjectPanel leftPanel = new NewProjectPanel();                 

                        return leftPanel;
                }//NewProjectPanel()

                 

             
        }//class MasterChief
}//ns
