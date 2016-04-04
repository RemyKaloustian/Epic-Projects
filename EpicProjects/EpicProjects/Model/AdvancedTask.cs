using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Model
{
        public class AdvancedTask : Model.Task
        {
                public string _priority { get; set; }

                public AdvancedTask(string name, string details, string priority) : base(name,details)
                {
                        _priority = priority;
                }
        }//class AdvancedTask
}//ns
