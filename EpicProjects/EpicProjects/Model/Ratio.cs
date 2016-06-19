using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Model
{
        public class Ratio
        {
                public double _done { get; set; }
                public double _todo { get; set; }

                public Ratio(int done, int todo)
                {
                        _done = done;
                        _todo = todo;
                }//ctor


                public double GetPercentage()
                {
                        return  _done / _todo * 100;
                }//GetPercentage()


                public override String  ToString()
                {
                        return _done + "/" + _todo ; 
                }//ToString()
        }//class Ratio
}//ns
