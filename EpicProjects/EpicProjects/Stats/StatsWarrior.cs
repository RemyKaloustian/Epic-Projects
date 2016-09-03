using EpicProjects.Constants;
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
                        List<AdvancedTask> trainingsList = new Selector(Constants.DatabaseValues.PROJECT_PATH).SelectTrainings(project);

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
                    List<AdvancedTask> trainingsList = new Selector(Constants.DatabaseValues.PROJECT_PATH).SelectAssignments(project);

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
                    List<AdvancedTask> trainingsList = new Selector(Constants.DatabaseValues.PROJECT_PATH).SelectMaintenances(project);

                        int done = 0;
                        int total = 0;
                        
                        if(trainingsList.Count >0)
                        {
                            foreach (AdvancedTask item in trainingsList)
                            {
                                if (item._state == States.DONE)
                                {
                                    done++;
                                }

                                total++;
                            }
                        }
                    

                        return new Ratio(done, total);
                }//GetMaintenancesRatio()


                public Ratio GetAdvancedTasksRatio(string project)
                {
                        Ratio rTrain = this.GetTrainingsRatio(project);
                        Ratio rAss = this.GetAssignmentsRatio(project);
                        Ratio rMain = this.GetMaintenancesRatio(project);


                        double done = rTrain._done + rAss._done + rMain._done;

                        double todo = rTrain._todo + rAss._todo + rMain._todo;

                        Ratio final = new Ratio(done, todo);

                        return final;

                }//GetAdvancedTasksRatio()


        }//class StatsWarrior
}//ns
