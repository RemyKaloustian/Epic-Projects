using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EpicProjects.Database
{
       public static class Preferences
        {
               public static List<string> GetLatestProjects()
               {
                       List<string> projects = new List<string>();

                       XmlDocument doc = new XmlDocument();
                       doc.Load("Saves/Preferences.xml");

                       XmlNodeList nodelist = doc.SelectNodes("/Preferences/Project");

                       foreach (XmlNode item in nodelist)
                       {

                               projects.Add(item.Attributes[DatabaseValues.NAME].InnerText);

                       }

                       return projects;
               }//GetLatestProjects()


               public static void InsertLastProject(string project)
               {
                       List<string> latestProjects = GetLatestProjects();

                       Constants.Debug.CW("Getting the latest Projects");
                       PrintList(latestProjects);
                       Constants.Debug.CW("Inserting the last project");

                       if(!latestProjects.Contains(project))
                       {
                               latestProjects.Insert(0, project);

                               PrintList(latestProjects);
                               Constants.Debug.CW("removing the oldest Projects");

                               latestProjects.RemoveAt(3);
                               PrintList(latestProjects);
                               XmlDocument doc = new XmlDocument();
                               doc.Load("Saves/Preferences.xml");

                               XmlNodeList nodelist = doc.SelectNodes("/Preferences/Project");
                               int i = 0;

                               foreach (XmlNode item in nodelist)
                               {
                                       Constants.Debug.CW("Should add " + latestProjects[i]);
                                       item.Attributes[DatabaseValues.NAME].InnerText = latestProjects[i];
                                       ++i;
                               }

                               doc.Save("Saves/Preferences.xml");
                       }

                   


               }//InsertLastProject()


               private static void PrintList(List<string> maList)
               {
                       for (int i = 0; i < maList.Count; i++)
                       {
                               Constants.Debug.CW("i = " + i + " : " + maList[i]);
                       }
               }//PrintList()

        }//class Preferences
}//ns
