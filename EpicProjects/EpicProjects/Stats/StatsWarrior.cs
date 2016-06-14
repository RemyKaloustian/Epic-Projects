﻿using EpicProjects.Constants;
using EpicProjects.Database;
using EpicProjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Stats
{
        public class StatsWarrior
        {
                public Ratio GetTrainingsRatio(string project)
                {
                        List<AdvancedTask> trainingsList = new Selector("tamaire").SelectTrainings(project);

                        int done = 0;
                        int total = 0;

                        foreach (AdvancedTask item in trainingsList)
                        {
                                if(item._state == States.DONE)
                                {
                                        done++;
                                }

                                total++;
                        }

                        return new Ratio(done, total);
                }//GetTrainingsRatio()

                public Ratio GetAssignmentsRatio(string project)
                {
                        List<AdvancedTask> trainingsList = new Selector("tamaire").SelectAssignments(project);

                        int done = 0;
                        int total = 0;

                        foreach (AdvancedTask item in trainingsList)
                        {
                                if (item._state == States.DONE)
                                {
                                        done++;
                                }

                                total++;
                        }

                        return new Ratio(done, total);
                }//GetAssignmentsRatio()


                public Ratio GetMaintenancesRatio(string project)
                {
                        List<AdvancedTask> trainingsList = new Selector("tamaire").SelectMaintenances(project);

                        int done = 0;
                        int total = 0;

                        foreach (AdvancedTask item in trainingsList)
                        {
                                if (item._state == States.DONE)
                                {
                                        done++;
                                }

                                total++;
                        }

                        return new Ratio(done, total);
                }//GetMaintenancesRatio()


                public string GetAdvancedTasksRatio(string project)
                {
                        Ratio rTrain = this.GetTrainingsRatio(project);
                        Ratio rAss = this.GetAssignmentsRatio(project);
                        Ratio rMain = this.GetMaintenancesRatio(project);


                        int done = rTrain._done + rAss._done + rMain._done;

                        int todo = rTrain._todo + rAss._todo + rMain._todo;


                        return done.ToString() + "/" + todo.ToString();

                }//GetAdvancedTasksRatio()



        }//class StatsWarrior
}//ns