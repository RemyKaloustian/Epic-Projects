using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Model
{
        public class Ratio
        {
                public int _done{ get; set; }
                public int _todo{ get; set; }

                public Ratio(int done, int todo)
                {
                        _done = done;
                        _todo = todo;
                }
        }//class Ratio
}//ns
