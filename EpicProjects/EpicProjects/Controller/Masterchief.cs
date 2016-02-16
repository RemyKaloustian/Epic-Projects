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
using EpicProjects.Controller;
using EpicProjects.View;

//*
// *  @Author : Rémy Kaloustian
// * 
// * /

namespace EpicProjects.Controller
{
        /// <summary>
        /// Although there is no warthog here, there is a MasterChief. This class treats the data and makes the link between the UI and the Database/Model. This one is used for the Home page.
        /// </summary>
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
                }//GetLatestProjects

                public void InsertProject(string name, string startDate, string endDate, Home home)
                {
                        Project brandNew = new Project(name, startDate, endDate);
                        Captain captain = new Captain();
                        captain.ToProject(name, home);
                }//InsertProject()

                void quitButton_Click(object sender, System.Windows.RoutedEventArgs e)
                {
                        //Clearing the leftPanel
                        StackPanel leftPanel = VisualTreeHelper.GetParent((Button)sender) as StackPanel;
                        leftPanel.Children.Clear();

                        //Adding the default buttons
                        AddMenuButtons(leftPanel);

                }//quitButton_Click()

                private void AddMenuButtons(StackPanel element)
                {
                        //Creating the controls
                        Button newProjectButton = new Button();
                        newProjectButton.Content = "New Project";
                        //newProjectButton.Click += ShowNewProjectA;
                        //Adding the controls to the leftPanel
                        element.Children.Add(newProjectButton);
                }//AddMenuButtons()

              
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
                }//createButtonClick()

                public NewProjectPanel GetNewProjectPanel()
                {
                        NewProjectPanel leftPanel = new NewProjectPanel();                 

                        return leftPanel;
                }//NewProjectPanel()

                public ProjectsPanel GetExistingProjects()
                {
                        List<object> res = _guru._propSelector.Select(DatabaseValues.NAME, DatabaseValues.PROJECT);

                        ProjectsPanel ppanel = new ProjectsPanel(res);

                        return ppanel;
                }//GetExistingProjects()

             
        }//class MasterChief
}//ns
