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

                       PrintList(latestProjects);

                       if(!latestProjects.Contains(project))
                       {
                               latestProjects.Insert(0, project);

                               PrintList(latestProjects);

                               latestProjects.RemoveAt(3);
                               PrintList(latestProjects);
                               XmlDocument doc = new XmlDocument();
                               doc.Load("Saves/Preferences.xml");

                               XmlNodeList nodelist = doc.SelectNodes("/Preferences/Project");
                               int i = 0;

                               foreach (XmlNode item in nodelist)
                               {
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
                               //Constants.Debug.CW("i = " + i + " : " + maList[i]);
                       }
               }//PrintList()

               public static void SetOpening(bool opening)
               {

                       XmlDocument doc = new XmlDocument();
                       doc.Load("Saves/Preferences.xml");

                       XmlNodeList nodelist = doc.SelectNodes("/Preferences/ProjectOpening");

                       foreach (XmlNode item in nodelist)
                       {

                               item.Attributes["value"].InnerText = opening.ToString();

                       }

                       doc.Save("Saves/Preferences.xml");

               }//SetOpening()

               public static bool GetOpening()
               {
                       XmlDocument doc = new XmlDocument();
                       doc.Load("Saves/Preferences.xml");

                       bool isProjectOpening = false;

                       XmlNodeList nodelist = doc.SelectNodes("/Preferences/ProjectOpening");

                       foreach (XmlNode item in nodelist)
                       {
                               if (item.Attributes["value"].InnerText == "True")
                                       isProjectOpening = true;
                       }

                       return isProjectOpening;

               }//GetOpening()


               public static bool GetShowDone()
               {
                       //Debug.CW("In GetShowDOne()");
                       XmlDocument doc = new XmlDocument();
                       doc.Load("Saves/Preferences.xml");

                       bool showdone = false;

                       XmlNodeList nodelist = doc.SelectNodes("/Preferences/ShowDone");

                       foreach (XmlNode item in nodelist)
                       {
                               if (item.Attributes["value"].InnerText == "True")
                               {
                                       showdone = true;
                               }
                       }


                       return showdone;
               }//GetShowDone()


               internal static void SetShowDone(bool showDone)
               {
                       XmlDocument doc = new XmlDocument();
                       doc.Load("Saves/Preferences.xml");

                       

                       XmlNodeList nodelist = doc.SelectNodes("/Preferences/ShowDone");

                       foreach (XmlNode item in nodelist)
                       {
                               item.Attributes["value"].InnerText =showDone.ToString() ;
                       }


                       doc.Save("Saves/Preferences.xml");


               }//SetShowDone()


               public static void SetSort(string option)
               {
                       XmlDocument doc = new XmlDocument();
                       doc.Load("Saves/Preferences.xml");



                       XmlNodeList nodelist = doc.SelectNodes("/Preferences/Sort");

                       foreach (XmlNode item in nodelist)
                       {
                               item.Attributes["value"].InnerText =option;
                       }


                       doc.Save("Saves/Preferences.xml");

               }//SetSort()

               public static string GetSort()
               {
                       XmlDocument doc = new XmlDocument();
                       doc.Load("Saves/Preferences.xml");

                       string option = "";

                       XmlNodeList nodelist = doc.SelectNodes("/Preferences/Sort");

                       foreach (XmlNode item in nodelist)
                       {

                               option = item.Attributes["value"].InnerText;
                           
                       }


                       return option;
               }//GetSort()

        }//class Preferences
}//ns
