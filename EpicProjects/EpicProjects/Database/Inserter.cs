﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using EpicProjects.Constants;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Windows;

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
                /// Insert a brainstorming in the DB
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                /// <param name="project"></param>
                public void InsertBrainstorming(string name, string details, string project)
                {

                        XDocument doc = XDocument.Load("Saves/Brainstormings.xml");
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement brain = new XElement("Brainstorming");
                        brain.Add(new XAttribute("name", name));
                        brain.Add(new XAttribute("details", details));
                        brain.Add(new XAttribute("project",project));

                        root.Add(brain);                       

                        doc.Save("Saves/Brainstormings.xml");

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                               MessageBox.Show( stringWriter.GetStringBuilder().ToString());
                        }
                       
                }//InsertBrainstorming()


                /// <summary>
                /// Insert a training in the DB
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                /// <param name="project"></param>
                public void InsertTraining(string name, string details, string project, string priority)
                {

                        XDocument doc = XDocument.Load("Saves/Trainings.xml");
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement training = new XElement("Training");
                        training.Add(new XAttribute("name", name));
                        training.Add(new XAttribute("details", details));
                        training.Add(new XAttribute("priority", priority));
                        training.Add(new XAttribute("project", project));
                        training.Add(new XAttribute("state", States.OPEN));

                        root.Add(training);

                        doc.Save("Saves/Trainings.xml");

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//InsertTraining()

                /// <summary>
                /// Insert an assignment in the DB
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                /// <param name="project"></param>
                public void InsertAssignment(string name, string details, string project, string priority)
                {

                        XDocument doc = XDocument.Load("Saves/Assignments.xml");
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement assignment = new XElement("Assignment");
                        assignment.Add(new XAttribute("name", name));
                        assignment.Add(new XAttribute("details", details));
                        assignment.Add(new XAttribute("priority", priority));
                        assignment.Add(new XAttribute("project", project));
                        assignment.Add(new XAttribute("state", States.OPEN));

                        root.Add(assignment);

                        doc.Save("Saves/Assignments.xml");

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//InsertAssignment()

                /// <summary>
                /// Insert an assignment in the DB
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                /// <param name="project"></param>
                public void InsertMaintenance(string name, string details, string project, string priority)
                {

                        XDocument doc = XDocument.Load("Saves/Maintenances.xml");
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement maintenance = new XElement("Maintenance");
                        maintenance.Add(new XAttribute("name", name));
                        maintenance.Add(new XAttribute("details", details));
                        maintenance.Add(new XAttribute("priority", priority));
                        maintenance.Add(new XAttribute("project", project));
                        maintenance.Add(new XAttribute("state", States.OPEN));

                        root.Add(maintenance);

                        doc.Save("Saves/Maintenances.xml");

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//InsertMaintenance()



        }//class Inserter
}//ns
