using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpicProjects.Database;

namespace EpicProjects.Controller
{
        public class Masterchief
        {
                public DatabaseGuru _guru { get; set; }

                public Masterchief ()
	        {
                        _guru = new   DatabaseGuru ();
	        }//Masterchief()

                public List<string> GetLatestProjects()
                {
                        return _guru._propSelector.SelectLatestProjects();
                }
        }//class MasterChief
}//ns
