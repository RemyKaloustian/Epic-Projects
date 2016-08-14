using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using EpicProjects.Constants;
using System.Xml;
using System.IO;
using System.Windows;

/*
 * @Author : Rémy Kaloustian
 * */

namespace EpicProjects.Database
{
        /// <summary>
        /// Updates the rows in the database
        /// </summary>
        public class Updater
        {
                public string _savePath { get; set; }

                public Updater(string path)
                {
                        //Setting up the connection settings
                        _savePath = path;
                }//Selector()


                /// <summary>
                /// Updates the name of a row
                /// </summary>
                /// <param name="id">Name of the row</param>
                /// <param name="field">Name of the field to change</param>
                /// <param name="newname">new name of the row</param>
                public void UpdateProject(string name, string field,string newValue)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(_savePath);

                        XmlNodeList nodelist = doc.SelectNodes("/Projects/Project");

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes[DatabaseValues.NAME].InnerText == name)
                                {
                                        item.Attributes["name"].InnerText = newValue;
                                }
                        }

                        doc.Save(Paths.PROJECTS_SAVE);

                }//UpdateProjectName()

                /// <summary>
                /// Updates the name of a row based on the name
                /// </summary>
                /// <param name="name">current name</param>
                /// <param name="table">the table</param>
                /// <param name="newname">the new name</param>
                public void UpdateNameWithName(string name, string table, string newname)
                {
                       
                }//UpdateProjectName()


                public void UpdateBrainstorming(string name, string newname, string newdetails, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("Saves/Brainstormings.xml");

                        XmlNodeList nodelist = doc.SelectNodes("Brainstormings/Brainstorming");

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes["project"].InnerText == project && item.Attributes["name"].InnerText == name)
                                {
                                        item.Attributes["name"].InnerText = newname;
                                        item.Attributes["details"].InnerText = newdetails;
                                }
                        }

                        doc.Save("Saves/Brainstormings.xml");

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                //MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//UpdateBrainstorming()


                public void UpdateTraining(string name, string newname, string newdetails,string newpriority, string newstate, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("Saves/Trainings.xml");

                        XmlNodeList nodelist = doc.SelectNodes("Trainings/Training");

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes["project"].InnerText == project && item.Attributes["name"].InnerText == name)
                                {
                                        item.Attributes["name"].InnerText = newname;
                                        item.Attributes["details"].InnerText = newdetails;
                                        item.Attributes["priority"].InnerText = newpriority;
                                        item.Attributes["state"].InnerText = newstate;
                                }
                        }

                        doc.Save("Saves/Trainings.xml");

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                //MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//UpdateTraining()


                public void UpdateAssignment(string name, string newname, string newdetails, string newpriority, string newstate, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("Saves/Assignments.xml");

                        XmlNodeList nodelist = doc.SelectNodes("Assignments/Assignment");

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes["project"].InnerText == project && item.Attributes["name"].InnerText == name)
                                {
                                        item.Attributes["name"].InnerText = newname;
                                        item.Attributes["details"].InnerText = newdetails;
                                        item.Attributes["priority"].InnerText = newpriority;
                                        item.Attributes["state"].InnerText = newstate;
                                }
                        }

                        doc.Save("Saves/Assignments.xml");

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                //MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//UpdateAssignments()


                public void UpdateMaintenance(string name, string newname, string newdetails, string newpriority, string newstate, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("Saves/Maintenances.xml");

                        XmlNodeList nodelist = doc.SelectNodes("Maintenances/Maintenance");

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes["project"].InnerText == project && item.Attributes["name"].InnerText == name)
                                {
                                        item.Attributes["name"].InnerText = newname;
                                        item.Attributes["details"].InnerText = newdetails;
                                        item.Attributes["priority"].InnerText = newpriority;
                                        item.Attributes["state"].InnerText = newstate;
                                        
                                }
                        }

                        doc.Save("Saves/Maintenances.xml");

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                //MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//UpdateMaintenance()




        }//class Updater()
}//ns
