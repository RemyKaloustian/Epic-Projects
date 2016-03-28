﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using EpicProjects.Constants;
using System.Xml.Linq;

namespace EpicProjects.Database
{
        /// <summary>
        /// This class inserts values in the database
        /// </summary>
        public class Inserter
        {
                public string _savePath { get; set; }

                public Inserter(string path)
                {
                        //Setting up the connection settings      
                       
                        _savePath = path;
                }//Selector()


                /// <summary>
                /// Insert a project in the database
                /// </summary>
                /// <param name="name">Name of the project</param>
                /// <param name="startDate">start date of the project</param>
                /// <param name="endDate">end date of the project</param>
                public void InsertProject(string name, string startDate, string endDate)
                {
                        XDocument doc = XDocument.Load(Paths.PROJECTSSAVE);
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement newProject = new XElement("Project");
                        newProject.Add(new XAttribute(DatabaseValues.NAME, name));
                        newProject.Add(new XAttribute(DatabaseValues.STARTDATE, startDate));
                        newProject.Add(new XAttribute(DatabaseValues.ENDDATE, endDate));


                        root.Add(newProject);
                     
                        //doc.Element("Snippets").Add(root);
                        doc.Save(Paths.PROJECTSSAVE);
                        
                }//InsertProject()


                /// <summary>
                /// Insert a task in the database
                /// </summary>
                /// <param name="name">Name of the task</param>
                /// <param name="deadline">deadline of the task</param>
                /// <param name="type">type of the task</param>
                /// <param name="priority">priority of the task</param>
                /// <param name="projectid">id of the dedicated project</param>
                public void InsertTask(string name, string deadline, string type, int priority, string projectName)
                {
                      

                }//InsertTask

        }//class Inserter
}//ns
