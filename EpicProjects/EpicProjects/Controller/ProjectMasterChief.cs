using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpicProjects.Constants;
using EpicProjects.Database;

/*
 * @Author : Rémy Kaloustian
 * */

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


                /// <summary>
                /// Insert a task in the database using the Guru
                /// </summary>
                /// <param name="name">Name of the task</param>
                /// <param name="deadline">   Deadline o' the task</param>
                /// <param name="type">Type o' the task</param>
                /// <param name="priority">Priority o' the task</param>
                /// <param name="projectid">the id of the project linked to the task</param>
                public void InsertTask(string name, string deadline, string type, int priority, int projectid)
                {
                        _guru._propInserter.InsertTask(name, deadline, type, priority, projectid);
                }//InsertTask()

        }//class ProjectMasterChief
}//ns
