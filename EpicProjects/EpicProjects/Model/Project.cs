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

                public int _id  { get; set; }

                public List<string> _formations { get; set; }
                public List<string> _tasks { get; set; }
                public List<string> _maintenances { get; set; }

                private   DatabaseGuru _guru { get; set; }

                public Project(string name, string startDate, string endDate)
                {
                        _guru = new DatabaseGuru();
                        _guru._propInserter.InsertProject(name, startDate, endDate);
                }

                public Project(string name)
                {
                        _name = name;
                        _guru = new DatabaseGuru();

                        //_name = _guru._propSelector.SelectSingleByEquality(DatabaseValues.NAME, DatabaseValues.PROJECT, DatabaseValues.NAME, "AFK");

                        _id = Convert.ToUInt16(_guru._propSelector.SelectSingleByEquality(DatabaseValues.ID, DatabaseValues.PROJECT, DatabaseValues.NAME, _name));

                        _startDate = _guru._propSelector.SelectSingleByEquality(DatabaseValues.STARTDATE, DatabaseValues.PROJECT, DatabaseValues.NAME, name);

                        _endDate = _guru._propSelector.SelectSingleByEquality(DatabaseValues.ENDDATE, DatabaseValues.PROJECT, DatabaseValues.NAME, name);

                        _formations = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME,DatabaseValues.TASK,DatabaseValues.TYPE,ModelConstants.FORMATION,_id);

                        _tasks = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME, DatabaseValues.TASK, DatabaseValues.TYPE, ModelConstants.TASK,_id);

                        _maintenances = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME, DatabaseValues.TASK, DatabaseValues.TYPE, ModelConstants.MAINTENANCE,_id);

                }//Project()

                public void Reload()
                {
                        _formations = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME, DatabaseValues.TASK, DatabaseValues.TYPE, ModelConstants.FORMATION, _id);

                        _tasks = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME, DatabaseValues.TASK, DatabaseValues.TYPE, ModelConstants.TASK,_id);

                        _maintenances = _guru._propSelector.SelectMultipleByEqualityWithProject(DatabaseValues.NAME, DatabaseValues.TASK, DatabaseValues.TYPE, ModelConstants.MAINTENANCE, _id);
                }


        }//class Project
}//ns
