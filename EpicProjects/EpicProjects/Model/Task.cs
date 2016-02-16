using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EpicProjects.Database;
using EpicProjects.Constants;

namespace EpicProjects.Model
{
        public class Task
        {
                public string _name { get; set; }
                public DatabaseGuru _guru { get; set; }

                public Task(string name)
                {
                        _guru = new DatabaseGuru();
                        _name = name;
                }//Task()

                public void Delete()
                {
                        _guru._propDeleter.DeleteOnName(_name, DatabaseValues.TASK);
                }//Delete()
        }//class task
}//ns
