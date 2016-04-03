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

                        XmlNodeList nodelist = doc.SelectNodes("/Projects/Project");

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

                        XmlNodeList nodelist = doc.SelectNodes("/Projects/Project");

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
                        Debug.CW("Name is  : " + projectName);
                        List<Model.Task> brainList = new List<Model.Task>();

                        XmlDocument doc = new XmlDocument();
                        doc.Load(_projectsSavePath);

                        XmlNodeList nodelist = doc.SelectNodes("/Projects/Project");

                        foreach (XmlNode item in nodelist)
                        {
                                Debug.CW("In first for loop");
                                if (item.Attributes[DatabaseValues.NAME].InnerText == projectName)
                                {
                                        XmlNodeList brainstormings = item["Brainstormings"].ChildNodes;

                                        foreach (XmlNode brain in brainstormings)
                                        {
                                                

                                                Model.Task aBrain = new Model.Task(brain.Attributes["name"].InnerText, brain.Attributes["details"].InnerText);
                                                

                                                brainList.Add(aBrain);

                                        }
                                }
                        }

                        return brainList;
                }//SelectBrainstormings


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
