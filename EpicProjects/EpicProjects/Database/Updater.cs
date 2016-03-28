﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using EpicProjects.Constants;
using System.Xml;

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

                        doc.Save(Paths.PROJECTSSAVE);

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


        }//class Updater()
}//ns
