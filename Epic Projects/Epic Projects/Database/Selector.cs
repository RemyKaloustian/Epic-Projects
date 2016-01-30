using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Xml.Dom;
using Epic_Projects.Model;

namespace Epic_Projects.Database
{
        public class Selector
        {

                public Project SelectProject(string name)
                {
                        XmlDocument save = new XmlDocument();
                        save.LoadXml("Database/Resources/Save.xml");
                        
                       int id =Int32.Parse(save.DocumentElement.SelectSingleNode("/Projects/" + name + "/id").InnerText);

                       string projectname = save.DocumentElement.SelectSingleNode("/Projects/" + name + "/name").InnerText;

                        string startDateString = save.DocumentElement.SelectSingleNode("/Projects/" + name + "/startDate").InnerText;

                       DateTime startdate = DateTime.Parse(startDateString);

                       string endDate = save.DocumentElement.SelectSingleNode("/Projects/" + name + "/endDate").InnerText;

                       return new Project(id, projectname, startdate, endDate);

                }//SelectProject()
        }//class Selector
}//ns 
