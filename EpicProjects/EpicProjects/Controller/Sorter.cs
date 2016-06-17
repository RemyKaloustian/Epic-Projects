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

                        if (section == UIStates.ON_TRAINING)
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
                        if (Preferences.GetSort() == Sorting.IMPORTANCE)
                        {
                                advancedTasks = this.SortByImportance(advancedTasks);
                        }

                        else if (Preferences.GetSort() == Sorting.STATE)
                        {
                                advancedTasks = this.SortByState(advancedTasks);
                        }

                        return advancedTasks;
                }//SortTrainings()


                private List<AdvancedTask> SortByImportance(List<AdvancedTask> advancedTasks)
                {
                        List<AdvancedTask> notImportant = new List<AdvancedTask>();
                        List<AdvancedTask> lessImportant = new List<AdvancedTask>();
                        List<AdvancedTask> important = new List<AdvancedTask>();
                        List<AdvancedTask> mostImportant = new List<AdvancedTask>();

                        foreach (AdvancedTask item in advancedTasks)
	                {
		                if(item._priority == Priorities.NOT_IMPORTANT)
                                {
                                        notImportant.Add(item);
                                }

                                else if(item._priority == Priorities.LESS_IMPORTANT)
                                {
                                        lessImportant.Add(item);
                                }
                                else if (item._priority == Priorities.IMPORTANT)
	                        {
		                        important.Add(item);
	                        }
                                else if(item._priority == Priorities.MOST_IMPORTANT)
                                {
                                        mostImportant.Add(item);
                                }
	                 }//foreach

                        List<AdvancedTask> finalTasks = new List<AdvancedTask>();

                        foreach (AdvancedTask item in mostImportant)
	                {
		                finalTasks.Add(item);
	                }

                        foreach (AdvancedTask item in important)
	                {
		                finalTasks.Add(item);
	                }

                        foreach (AdvancedTask item in lessImportant)
	                {
		                finalTasks.Add(item);
	                }

                        foreach (AdvancedTask item in notImportant)
	                {
		                finalTasks.Add(item);
	                }


                        return finalTasks;
                }//SortByImportance()


                private List<AdvancedTask> SortByState(List<AdvancedTask> advancedTasks)
                {
                        List<AdvancedTask> open = new List<AdvancedTask>();
                        List<AdvancedTask> inprogress = new List<AdvancedTask>();
                        List<AdvancedTask> done = new List<AdvancedTask>();

                        List<AdvancedTask> finalTasks = new List<AdvancedTask>();
                        foreach (AdvancedTask item in advancedTasks)
                        {
                                if(item._state == States.OPEN)
                                {
                                        open.Add(item);
                                }
                                else if(item._state == States.PROGRESS)
                                {
                                        inprogress.Add(item);
                                }
                                else if(item._state == States.DONE)
                                {
                                        done.Add(item);
                                }
                        }//foreach

                        foreach (AdvancedTask item in open)
                        {
                                finalTasks.Add(item);
                        }

                        foreach (AdvancedTask item in inprogress)
                        {
                                finalTasks.Add(item);
                        }

                        foreach (AdvancedTask item in done)
                        {
                                finalTasks.Add(item);
                        }

                        return finalTasks;
                }//SortByState()


        }//class Sorter()
}//ns
