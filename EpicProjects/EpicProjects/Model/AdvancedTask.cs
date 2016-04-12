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
                public string _state { get; set; }

                public AdvancedTask(string name, string details, string priority, string state, string project) : base(name,details, project)
                {
                        _priority = priority;
                        _state = state;
                }
        }//class AdvancedTask
}//ns
