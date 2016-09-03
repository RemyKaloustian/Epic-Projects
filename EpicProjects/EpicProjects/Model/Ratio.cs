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

                public Ratio(double done, double todo)
                {
                        _done = done;
                        _todo = todo;
                }//ctor


                public double GetPercentage()
                {
                    if (Double.IsNaN(_done / _todo))
                        return 0;

                    return  _done / _todo * 100;
                }//GetPercentage()


                public override String  ToString()
                {
                    string result = "";
                    if(Double.IsNaN(_done/_todo))
                    {
                        result = "0";
                    }
                    else
                    {
                        result = _done + "/" + _todo;
                    }
                        return  result; 
                }//ToString()
        }//class Ratio
}//ns
