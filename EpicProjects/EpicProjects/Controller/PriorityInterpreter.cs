using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpicProjects.Constants;

namespace EpicProjects.Controller
{
        public class PriorityInterpreter
        {
                public string _code { get; set; }
                public PriorityInterpreter(string code)
                {
                        _code = code;
                }

                public string Interpret()
                {
                        if (_code == Priorities.NOT_IMPORTANT_CODE)
                                return Priorities.NOT_IMPORTANT;

                        else if (_code == Priorities.LESS_IMPORTANT_CODE)
                                return Priorities.LESS_IMPORTANT;

                        else if (_code == Priorities.IMPORTANT_CODE)
                                return Priorities.IMPORTANT;

                        else if (_code == Priorities.ULTRA_IMPORTANT_CODE)
                                return Priorities.ULTRA_IMPORTANT;

                        else if (_code == Priorities.MOST_IMPORTANT_CODE)
                                return Priorities.MOST_IMPORTANT;

                        return "";
                }
        }
}
