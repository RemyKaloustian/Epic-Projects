using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpicProjects.Constants;
using EpicProjects.Database;

namespace EpicProjects.Controller
{
       
        public class ProjectMasterChief
        {

                public DatabaseGuru _guru { get; set; }

                public ProjectMasterChief()
                {
                        _guru = new DatabaseGuru();
                }

                public void InsertTask(string name, string deadline, string type, int priority, int projectid)
                {
                        _guru._propInserter.InsertTask(name, deadline, type, priority, projectid);

                }
        }//class ProjectMasterChief
}//ns
