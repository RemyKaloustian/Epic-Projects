﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EpicProjects.Database;
using EpicProjects.Constants;

namespace EpicProjects.Model
{
        public class Task
        {
                public string _name { get; set; }
                public string _details { get; set; }
                public string _project { get; set; }
                public DatabaseGuru _guru { get; set; }

                public Task(string name, string details, string project)
                {
                        _guru = new DatabaseGuru(Paths.PROJECTS_SAVE);
                        _name = name;
                        _details = details;
                        _project = project;
                }//Task()

                public void Update(string name, string newName)
                {
                        _guru._propUpdater.UpdateNameWithName(name,DatabaseValues.TASK, newName );
                }//Update

                public void Delete()
                {
                        //_guru._propDeleter.DeleteProject(_name, DatabaseValues.TASK);
                }//Delete()
        }//class task
}//ns
