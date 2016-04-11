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
                }//DeleteProject()

                public void DeleteBrainstorming(string name, string project)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Paths.BRAINSTORMINGS_SAVE);
                        Debug.CW("In Deleter, name = " + name + " , project = " + project);
                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.BRAINSTORMINGS_PATH);

                        foreach (XmlNode item in nodelist)
                        {
                                if (item.Attributes[DatabaseValues.PROJECT_LINK].InnerText == project && item.Attributes[DatabaseValues.NAME].InnerText == name)
                                {
                                        Debug.CW("Removing item");
                                        item.ParentNode.RemoveChild(item);
                                }
                        }


                        doc.Save(Paths.BRAINSTORMINGS_SAVE);

                        using (var stringWriter = new StringWriter())
                        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                        {
                                doc.WriteTo(xmlTextWriter);
                                xmlTextWriter.Flush();
                                MessageBox.Show(stringWriter.GetStringBuilder().ToString());
                        }
                }//DeleteBrainstorming()

        }//class Deleter
}//ns
