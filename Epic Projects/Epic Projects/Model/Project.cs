using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Projects.Model
{
        /// <summary>
        /// Represents a project
        /// </summary>
        public class Project
        {
                //main attributes
                public uint _id { get; set; } 
                public string _name { get; set; }
                public DateTime  _startDate { get; set; }
                public  DateTime _endDate { get; set; }

                //Lists
                public List<ProjectTask> _formations { get; set; }
                public List<ProjectTask> _tasks { get; set; }
                public List<ProjectTask> _maintenance { get; set; }


                public Project(uint newid, string newname, DateTime newstartDate, DateTime newendDate)
                {
                        this._id = newid;
                        this._name = newname;
                        this._startDate = newstartDate;
                        this._endDate = newendDate;
                }//Project()

                
        }//class Project
}//ns
