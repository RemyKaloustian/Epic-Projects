using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpicProjects.Database;
using EpicProjects.Constants;

namespace EpicProjects.Model
{
        public class Project
        {
                public string _name { get; set; }
                public string _startDate { get; set; }
                public string _endDate { get; set; }

                public List<string> _formations { get; set; }
                public List<string> _tasks { get; set; }
                public List<string> _maintenances { get; set; }

                private   DatabaseGuru _guru { get; set; }

                public Project()
                {
                        _guru = new DatabaseGuru();

                        _name = _guru._propSelector.SelectSingleByEquality(DatabaseValues.NAME, DatabaseValues.PROJECT, DatabaseValues.NAME, "AFK");

                        _startDate = _guru._propSelector.SelectSingleByEquality(DatabaseValues.STARTDATE, DatabaseValues.PROJECT, DatabaseValues.NAME, "AFK");

                        _endDate = _guru._propSelector.SelectSingleByEquality(DatabaseValues.ENDDATE, DatabaseValues.PROJECT, DatabaseValues.NAME, "AFK");

                        _formations = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME,DatabaseValues.TASK,DatabaseValues.TYPE,ModelConstants.FORMATION,3);

                        _tasks = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME, DatabaseValues.TASK, DatabaseValues.TYPE, ModelConstants.TASK,3);

                        _maintenances = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME, DatabaseValues.TASK, DatabaseValues.TYPE, ModelConstants.MAINTENANCE,3);

                }


        }//class Project
}//ns
