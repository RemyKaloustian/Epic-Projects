using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpicProjects.Constants;
using EpicProjects.Database;

namespace EpicProjects.Controller
{
       /// <summary>
       /// This class makes the link between the UI and the Database/Model for the Project window
       /// </summary>
        public class ProjectMasterChief
        {
                //To access the Database
                public DatabaseGuru _guru { get; set; }

                public ProjectMasterChief()
                {
                        _guru = new DatabaseGuru();
                }//ProjectMasterChief()

                public void InsertTask(string name, string deadline, string type, int priority, int projectid)
                {
                        _guru._propInserter.InsertTask(name, deadline, type, priority, projectid);
                }//InsertTask()

        }//class ProjectMasterChief
}//ns
