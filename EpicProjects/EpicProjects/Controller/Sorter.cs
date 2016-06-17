using EpicProjects.Constants;
using EpicProjects.Constants.Model;
using EpicProjects.Database;
using EpicProjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Controller
{
        public class Sorter
        {
                public Sorter()
                {

                }


                public List<AdvancedTask> Sort(TaskMasterChief chief, string section)
                {
                        List<AdvancedTask> advancedTasks = new List<AdvancedTask>();

                        if(section == UIStates.ON_TRAINING)
                        {
                                advancedTasks = chief.SelectTrainings();
                        }
                        else if (section == UIStates.ON_ASSIGNMENT)
                        {
                                advancedTasks = chief.SelectAssignments();
                        }
                        else if (section == UIStates.ON_MAINTENANCE)
                        {
                                advancedTasks = chief.SelectMaintenances();
                        }

                        advancedTasks = this.SpecificSorting(advancedTasks);

                        List<AdvancedTask> finalTasks = new List<AdvancedTask>();                      

                        for (int i = 0; i < advancedTasks.Count; ++i)
                        {

                                if (advancedTasks[i]._state == States.DONE && Preferences.GetShowDone())
                                {
                                        finalTasks.Add(advancedTasks[i]);
                                }
                                else if (advancedTasks[i]._state != States.DONE)
                                {
                                        finalTasks.Add(advancedTasks[i]);

                                }
                        }

                        return finalTasks;

                }

                private List<AdvancedTask> SpecificSorting(List<AdvancedTask> advancedTasks)
                {
                        if(Preferences.GetSort() == Sorting.IMPORTANCE)
                        {
                                advancedTasks = this.SortByImportance(advancedTasks);
                        }

                        else if(Preferences.GetSort() == Sorting.STATE)
                        {
                                //advancedTasks = this.SortByState(advancedTasks);
                        }

                        return advancedTasks;
                }//SortTrainings()


                private List<AdvancedTask> SortByImportance(List<AdvancedTask> advancedTasks)
                {
                        return null;
                }


                

        }//class Sorter()
}//ns
