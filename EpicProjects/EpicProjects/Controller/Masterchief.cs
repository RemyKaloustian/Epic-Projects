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
                //Makes the link with the database
                public DatabaseGuru _guru { get; set; }

                public Masterchief ()
	        {
                        _guru = new   DatabaseGuru (Paths.PROJECTSSAVE);
	        }//Masterchief()

                /// <summary>
                /// Gets the latest projects used 
                /// </summary>
                /// <returns>A list of the names of the projects</returns>
                public List<string> GetLatestProjects()
                {
                        return _guru._propSelector.SelectLatestProjects();
                }//GetLatestProjects


                public List<string > SelectProjects()
                {
                        return _guru._propSelector.SelectProjects();
                }


                public void Rename(string name, string field,string newname)
                {
                        _guru._propUpdater.UpdateProject(name,field,newname);
                }



                //USEFUL ?????????????? RENAME !!!!!!!!!!!!!!!!!!!!
                /// <summary>
                /// Creates a new project and go straight to it
                /// </summary>
                /// <param name="name">The name of the project</param>
                /// <param name="startDate">the start date</param>
                /// <param name="endDate">the end date</param>
                /// <param name="home">The home window, in order to close it</param>
                public void InsertProject(string name, string startDate, string endDate, Home home = null)
                {
                        //USEFUL ??????????
                        Project brandNew = new Project(name, startDate, endDate);
                        //Going to the project window
                        Captain captain = new Captain();
                       // captain.ToProject(name, home);
                }//InsertProject()

                /// <summary>
                /// Return to the default  home layout 
                /// </summary>
                /// <param name="sender">The sender (duh)</param>
                /// <param name="e">hem hem</param>
                void quitButton_Click(object sender, System.Windows.RoutedEventArgs e)
                {
                        //Clearing the leftPanel
                        StackPanel leftPanel = VisualTreeHelper.GetParent((Button)sender) as StackPanel;
                        leftPanel.Children.Clear();

                        //Adding the default buttons
                        AddMenuButtons(leftPanel);

                }//quitButton_Click()


                /// <summary>
                /// Adds the default buttons to the home window
                /// </summary>
                /// <param name="element">The panel we add the buttons to</param>
                private void AddMenuButtons(StackPanel element)
                {
                        //Creating the controls
                        Button newProjectButton = new Button();
                        newProjectButton.Content = "New Project";
                        //newProjectButton.Click += ShowNewProjectA;
                        //Adding the controls to the leftPanel
                        element.Children.Add(newProjectButton);
                }//AddMenuButtons()

              
                /// <summary>
                /// Creates the project
                /// </summary>
                /// <param name="sender">Dah sender (duh)</param>
                /// <param name="e">OK</param>
                void createButton_Click(object sender, System.Windows.RoutedEventArgs e)
                {
                        //Getting the parent
                         StackPanel leftPanel = VisualTreeHelper.GetParent((Button)sender) as StackPanel;
                      //Getting the controls
                        TextBox nameBox = leftPanel.Children.OfType<TextBox>().FirstOrDefault();

                        //Saving the name in a variable
                        string name = nameBox.Text;

                        //Saving the start date
                        DatePicker startPick = leftPanel.Children.OfType<DatePicker>().FirstOrDefault();
                        string startDate = startPick.Text;
                        //Saving the end date
                        DatePicker endPick = leftPanel.Children.OfType<DatePicker>().Last();
                        string endDate = endPick.Text;

                        //Inserting the project in the database
                        _guru._propInserter.InsertProject(name, startDate, endDate);
                }//createButtonClick()

                /// <summary>
                /// Returns the new projectt panel
                /// </summary>
                /// <returns>the panel for the new project creation</returns>
                public NewProjectPanel GetNewProjectPanel()
                {
                        NewProjectPanel leftPanel = new NewProjectPanel();                 

                        return leftPanel;
                }//NewProjectPanel()

                /// <summary>
                /// Returns the existing projects
                /// </summary>
                /// <returns>A panel with the existing projects</returns>
                public ProjectsPanel GetExistingProjects()
                {
                        //We get the projects from the guru
                        List<string> res = _guru._propSelector.SelectProjects();

                        ProjectsPanel ppanel = new ProjectsPanel(res);

                        return ppanel;
                }//GetExistingProjects()


                public void Delete(string name, string table)
                {
                        _guru._propDeleter.DeleteProject(name);
                }//Delete()
             
        }//class MasterChief
}//ns
