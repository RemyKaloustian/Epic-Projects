using EpicProjects.Constants;
using EpicProjects.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Controller
{
        public class Checker
        {
                public bool IsProjectExisting(string newProject)
                {
                        DatabaseGuru guru = new DatabaseGuru(Paths.PROJECTS_SAVE);

                        List<string> projects = guru._propSelector.SelectProjects();

                        foreach (var item in projects)
                        {
                                if (newProject.Trim().ToLower() == item.Trim().ToLower())
                                        return true;
                        }

                        return false;
                }
        }//class Checker()
}//ns
