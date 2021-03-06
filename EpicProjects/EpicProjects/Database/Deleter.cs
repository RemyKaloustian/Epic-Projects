﻿using System;
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
        /// This class deletes values from the database
        /// </summary>
        public class Deleter
        {
                //public string _connectionString { get; set; }
                //public SqlConnection _connection;

                public Deleter()
                {

                }//Selector()

                /// <summary>
                /// Deletes avalue based on an id
                /// </summary>
                /// <param name="id">the id</param>
                /// <param name="table">the table</param>
                public void DeleteOnId(int id, string table)
                {
                        //_connection.Open();
                        //SqlCommand command = new SqlCommand("delete from " + table + " where id = " + id, _connection);

                        //command.ExecuteNonQuery();

                        //_connection.Close();
                }//DeleteOnId()

                /// <summary>
                /// Deletes a value based on the name
                /// </summary>
                /// <param name="name">the name</param>
                public void DeleteProject(string name)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Paths.PROJECTS_SAVE);
                        XmlNodeList nodelist = doc.SelectNodes("/Projects/Project");

                        foreach (XmlNode item in nodelist)
                        {
                                if(item.Attributes[DatabaseValues.NAME].InnerText== name)
                                {
                                        if (item != null)
                                        {
                                                item.ParentNode.RemoveChild(item);
                                        }
                                }                             
                        }
                        doc.Save(Paths.PROJECTS_SAVE);


                        doc = new XmlDocument();
                        doc.Load("Saves/Preferences.xml");

                        nodelist = doc.SelectNodes("/Preferences/Project");

                        foreach (XmlNode item in nodelist)
                        {
                                if(item.Attributes["name"].InnerText == name)
                                {
                                        item.Attributes["name"].InnerText = "";
                                }
                        }

                        doc.Save("Saves/Preferences.xml");


                }//DeleteProject()

                public void DeleteBrainstorming(string name, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Paths.BRAINSTORMINGS_SAVE);
                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.BRAINSTORMINGS_PATH);

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes[DatabaseValues.PROJECT_LINK].InnerText == project && item.Attributes[DatabaseValues.NAME].InnerText == name)
                                {
                                        item.ParentNode.RemoveChild(item);
                                }
                        }


                        doc.Save(Paths.BRAINSTORMINGS_SAVE);

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                //MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//DeleteBrainstorming()

                public void DeleteTraining(string name, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Paths.TRAININGS_SAVE);
                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.TRAININGS_PATH);

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes[DatabaseValues.PROJECT_LINK].InnerText == project && item.Attributes[DatabaseValues.NAME].InnerText == name)
                                {
                                        item.ParentNode.RemoveChild(item);
                                }
                        }


                        doc.Save(Paths.TRAININGS_SAVE);

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                //MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//DeleteTraining()



                public void DeleteAssignment(string name, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Paths.ASSIGNMENTS_SAVE);
                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.ASSIGNMENTS_PATH);

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes[DatabaseValues.PROJECT_LINK].InnerText == project && item.Attributes[DatabaseValues.NAME].InnerText == name)
                                {
                                        item.ParentNode.RemoveChild(item);
                                }
                        }


                        doc.Save(Paths.ASSIGNMENTS_SAVE);

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                //MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//DeleteAssignment()


                public void DeleteMaintenance(string name, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Paths.MAINTENANCES_SAVE);
                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.MAINTENANCES_PATH);

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes[DatabaseValues.PROJECT_LINK].InnerText == project && item.Attributes[DatabaseValues.NAME].InnerText == name)
                                {
                                        item.ParentNode.RemoveChild(item);
                                }
                        }


                        doc.Save(Paths.MAINTENANCES_SAVE);

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                //MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//DeleteMaintenance()




        }//class Deleter
}//ns
