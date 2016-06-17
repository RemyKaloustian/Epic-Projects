using EpicProjects.Constants;
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

                }//SortTrainings()


                public List<AdvancedTask> SortAssignments(TaskMasterChief chief)
                {
                        List<AdvancedTask> assignments = chief.SelectAssignments();

                        List<AdvancedTask> finalAssignments = new List<AdvancedTask>();
                        foreach (AdvancedTask item in assignments)
                        {
                        }

                        for (int i = 0; i < assignments.Count; ++i)
                        {
                                
                                if (assignments[i]._state == States.DONE && Preferences.GetShowDone())
                                {
                                        finalAssignments.Add(assignments[i]);
                                }
                                else if (assignments[i]._state != States.DONE)
                                {
                                        finalAssignments.Add(assignments[i]);

                                }

                        }

                        //foreach(AdvancedTask item in trainings)
                        //{
                        //        Constants.Debug.CW("name =  " + item._name + " | " +
                        //                        "state =" + item._state + " | " +
                        //                        "shodone = " + Preferences.GetShowDone());
                        //        if (item._state == States.DONE && !Preferences.GetShowDone())
                        //        {

                        //                trainings.Remove(item);
                        //                Constants.Debug.CW("Removing this item");
                        //        }

                        //}


                        foreach (AdvancedTask item in finalAssignments)
                        {
                        }

                        return finalAssignments;

                }//SortTrainings()


        }//class Sorter()
}//ns
