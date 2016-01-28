using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Projects.Model
{
        /// <summary>
        /// Represent a task in a project, either in formation, development or maintenance
        /// </summary>
        public class ProjectTask
        {
                public uint _id { get; set; }
                public string _name{ get; set; }
                public DateTime _deadline { get; set; }
                public uint _priority { get; set; }
                public bool _isDone { get; set; }

                public ProjectTask(uint newid, string newname, DateTime newdeadline, uint newpriority)
                {
                        this._id = newid;
                        this._name = newname;
                        this._deadline = newdeadline;
                        this._priority = newpriority;

                        this._isDone = false;
                }//ProjectTask()
        }//class ProjectTask
}//ns
