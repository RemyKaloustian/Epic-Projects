using System;
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
                        XDocument doc = XDocument.Load(Paths.PROJECTS_SAVE);
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement newProject = new XElement(DatabaseValues.PROJECT);
                        newProject.Add(new XAttribute(DatabaseValues.NAME, name));
                        newProject.Add(new XAttribute(DatabaseValues.STARTDATE, startDate));
                        newProject.Add(new XAttribute(DatabaseValues.ENDDATE, endDate));


                        root.Add(newProject);

                        //doc.Element("Snippets").Add(root);
                        doc.Save(Paths.PROJECTS_SAVE);

                }//InsertProject()


           
                /// <summary>
                /// Insert a brainstorming in the DB
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                /// <param name="project"></param>
                public void InsertBrainstorming(string name, string details, string project)
                {

                        XDocument doc = XDocument.Load(Paths.BRAINSTORMINGS_SAVE);
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement brain = new XElement(DatabaseValues.BRAINSTORMING);
                        brain.Add(new XAttribute(DatabaseValues.NAME, name));
                        brain.Add(new XAttribute(DatabaseValues.DETAILS, details));
                        brain.Add(new XAttribute(DatabaseValues.PROJECT_LINK,project));

                        root.Add(brain);                       

                        doc.Save(Paths.BRAINSTORMINGS_SAVE);

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

                        XDocument doc = XDocument.Load(Paths.TRAININGS_SAVE);
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement training = new XElement(DatabaseValues.TRAINING);
                        training.Add(new XAttribute(DatabaseValues.NAME, name));
                        training.Add(new XAttribute(DatabaseValues.DETAILS, details));
                        training.Add(new XAttribute(DatabaseValues.PRIORITY, priority));
                        training.Add(new XAttribute(DatabaseValues.PROJECT_LINK, project));
                        training.Add(new XAttribute(DatabaseValues.STATE, States.OPEN));

                        root.Add(training);

                        doc.Save(Paths.TRAININGS_SAVE);

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

                        XDocument doc = XDocument.Load(Paths.ASSIGNMENTS_SAVE);

                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement assignment = new XElement(DatabaseValues.ASSIGNMENT);
                        assignment.Add(new XAttribute(DatabaseValues.NAME, name));
                        assignment.Add(new XAttribute(DatabaseValues.DETAILS, details));
                        assignment.Add(new XAttribute(DatabaseValues.PRIORITY, priority));
                        assignment.Add(new XAttribute(DatabaseValues.PROJECT_LINK, project));
                        assignment.Add(new XAttribute(DatabaseValues.STATE, States.OPEN));

                        root.Add(assignment);

                        doc.Save(Paths.ASSIGNMENTS_SAVE);

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

                        XDocument doc = XDocument.Load(Paths.MAINTENANCES_SAVE);
                        XElement root = doc.Root;

                        //Creation of the projects
                        XElement maintenance = new XElement(DatabaseValues.MAINTENANCE);
                        maintenance.Add(new XAttribute(DatabaseValues.NAME, name));
                        maintenance.Add(new XAttribute(DatabaseValues.DETAILS, details));
                        maintenance.Add(new XAttribute(DatabaseValues.PRIORITY, priority));
                        maintenance.Add(new XAttribute(DatabaseValues.PROJECT_LINK, project));
                        maintenance.Add(new XAttribute(DatabaseValues.STATE, States.OPEN));

                        root.Add(maintenance);

                        doc.Save(Paths.MAINTENANCES_SAVE);

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
