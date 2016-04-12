using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using EpicProjects.Constants;
using EpicProjects.Model;
using System.Xml;

/*
 * @Author : Rémy Kaloustian
 * */

namespace EpicProjects.Database
{

       
        /// <summary>
        /// This Selector allows to select rows values in the database 
        /// </summary>
        public class Selector
        {
                public string _projectsSavePath { get; set; }

                public Selector(string savePath)
                {
                        //Setting up the connection settings
                        _projectsSavePath = savePath;
                }//Selector()

                #region XMLDB
                public List<string> SelectProjects()
                {
                        List<string> projects = new List<string>();

                        XmlDocument doc = new XmlDocument();
                        doc.Load(_projectsSavePath);

                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.PROJECT_PATH);

                        foreach (XmlNode item in nodelist)
                        {

                                projects.Add(item.Attributes[DatabaseValues.NAME].InnerText);
                               
                        }

                        return projects;

                }//SelectProjects()


                public Project SelectSingleProject(string name)
                {
                        Project project = new Project("NULL", DateTime.Now.ToString(), DateTime.Now.ToString());


                        XmlDocument doc = new XmlDocument();
                        doc.Load(_projectsSavePath);

                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.PROJECT_PATH);

                        foreach (XmlNode item in nodelist)
                        {

                               if(item.Attributes[DatabaseValues.NAME].InnerText ==name )
                               {
                                       project = new Project(
                                                        item.Attributes[DatabaseValues.NAME].InnerText,
                                                        item.Attributes[DatabaseValues.STARTDATE].InnerText,
                                                        item.Attributes[DatabaseValues.ENDDATE].InnerText
                                               );
                                       break;
                               }
                        }
                        return project; //Ternaire

                }//SelectSingleProject()



                public List<Model.Task> SelectBrainstormings(string projectName)
                {
                        List<Model.Task> brainList = new List<Model.Task>();

                        XmlDocument doc = new XmlDocument();
                        doc.Load("Saves/Brainstormings.xml");

                        XmlNodeList nodelist = doc.SelectNodes("Brainstormings/Brainstorming");

                        foreach (XmlNode item in nodelist)
                        {
                                if(item.Attributes["project"].InnerText == projectName)
                                {
                                        Model.Task aBrain = new Model.Task(item.Attributes[DatabaseValues.NAME].InnerText, item.Attributes[DatabaseValues.DETAILS].InnerText, item.Attributes[DatabaseValues.PROJECT_LINK].InnerText);
                                        brainList.Add(aBrain);
                                }
                        }

                        return brainList;
                }//SelectBrainstormings


                public List<Model.AdvancedTask> SelectTrainings(string projectName)
                {
                        List<Model.AdvancedTask> trainingList = new List<Model.AdvancedTask>();

                        XmlDocument doc = new XmlDocument();
                        doc.Load("Saves/Trainings.xml");

                        XmlNodeList nodelist = doc.SelectNodes("Trainings/Training");

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes["project"].InnerText == projectName)
                                {

                                        Model.AdvancedTask aTraining = new Model.AdvancedTask(item.Attributes[DatabaseValues.NAME].InnerText, item.Attributes[DatabaseValues.DETAILS].InnerText, item.Attributes[DatabaseValues.PRIORITY].InnerText, item.Attributes[DatabaseValues.STATE].InnerText, item.Attributes[DatabaseValues.PROJECT_LINK].InnerText);
                                       
                                            trainingList.Add(aTraining);
                                }
                        }

                        return trainingList;
                }//SelectTrainings



                public List<Model.AdvancedTask> SelectAssignments(string projectName)
                {
                        List<Model.AdvancedTask> assignmentList = new List<Model.AdvancedTask>();

                        XmlDocument doc = new XmlDocument();
                        doc.Load("Saves/Assignments.xml");

                        XmlNodeList nodelist = doc.SelectNodes("Assignments/Assignment");

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes["project"].InnerText == projectName)
                                {
                                        Model.AdvancedTask anAssignment = new Model.AdvancedTask(item.Attributes[DatabaseValues.NAME].InnerText, item.Attributes[DatabaseValues.DETAILS].InnerText, item.Attributes[DatabaseValues.PRIORITY].InnerText, item.Attributes[DatabaseValues.STATE].InnerText, item.Attributes[DatabaseValues.PROJECT_LINK].InnerText);
                                        assignmentList.Add(anAssignment);
                                }
                        }

                        return assignmentList;
                }//SelectAssignments



                public List<Model.AdvancedTask> SelectMaintenances(string projectName)
                {
                        List<Model.AdvancedTask> maintenanceList = new List<Model.AdvancedTask>();

                        XmlDocument doc = new XmlDocument();
                        doc.Load("Saves/Maintenances.xml");

                        XmlNodeList nodelist = doc.SelectNodes("Maintenances/Maintenance");

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes["project"].InnerText == projectName)
                                {
                                        Model.AdvancedTask aMaintenance = new Model.AdvancedTask(item.Attributes[DatabaseValues.NAME].InnerText, item.Attributes[DatabaseValues.DETAILS].InnerText, item.Attributes[DatabaseValues.PRIORITY].InnerText, item.Attributes[DatabaseValues.STATE].InnerText, item.Attributes[DatabaseValues.PROJECT_LINK].InnerText);
                                        maintenanceList.Add(aMaintenance);
                                }
                        }

                        return maintenanceList;
                }//SelectAssignments

                #endregion XMLDB


                public  List<string> SelectLatestProjects()
                {
                        ///TODO:  
                        ///
                        List<string> fakeLatest = new List<string>();
                        fakeLatest.Add("WHAT");
                        fakeLatest.Add("IS");
                        fakeLatest.Add("THIS ?!");

                        return fakeLatest;
                }
        }//class Selector
}//ns
