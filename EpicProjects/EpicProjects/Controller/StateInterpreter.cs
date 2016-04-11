using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Controller
{
        public class StateInterpreter
        {
                public string _state{ get; set; }

                public StateInterpreter(string state)
                {
                        _state = state;
                }

                internal string ToUIState()
                {
                        string toReturn ="";

                        if(_state == States.OPEN)
                        {
                                toReturn = States.UIOPEN;
                        }

                        else if(_state == States.PROGRESS)
                        {
                                toReturn = States.UIPROGRESS;
                        }

                        else if(_state == States.DONE)
                        {
                                toReturn = States.UIDONE;
                        }

                        return toReturn;
                }//ToUIState()

        }//class StateInterpreter
}//ns
