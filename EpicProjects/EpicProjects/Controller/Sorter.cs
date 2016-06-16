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


                public List<AdvancedTask> SortTrainings(TaskMasterChief chief)
                {
                        List<AdvancedTask> trainings= chief.SelectTrainings();

                        List<AdvancedTask> finalTrainings = new List<AdvancedTask>();
                        Constants.Debug.CW("In SortTrainings, count  = " + trainings.Count);
                        foreach (AdvancedTask item in trainings)
                        {
                                Constants.Debug.CW("Name = " + item._name);
                        }

                        for (int i = 0; i < trainings.Count; ++i)
                        {
                                Constants.Debug.CW("i = " + i + "| name =  " + trainings[i]._name + " | " +
                                                "state =" + trainings[i]._state + " | " +
                                                "shodone = " + Preferences.GetShowDone());
                                if (trainings[i]._state == States.DONE && Preferences.GetShowDone())
                                {
                                        finalTrainings.Add(trainings[i]);
                                        Constants.Debug.CW("Removing this item");
                                }
                                else if(trainings[i]._state != States.DONE)
                                {
                                        finalTrainings.Add(trainings[i]);

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

                        Constants.Debug.CW("After the sort");

                        foreach (AdvancedTask item in finalTrainings)
                        {
                                Constants.Debug.CW(item._name);
                        }

                        return finalTrainings;

                }//SortTrainings()


                public List<AdvancedTask> SortAssignments(TaskMasterChief chief)
                {
                        List<AdvancedTask> assignments = chief.SelectAssignments();

                        List<AdvancedTask> finalAssignments = new List<AdvancedTask>();
                        Constants.Debug.CW("In SortTrainings, count  = " + assignments.Count);
                        foreach (AdvancedTask item in assignments)
                        {
                                Constants.Debug.CW("Name = " + item._name);
                        }

                        for (int i = 0; i < assignments.Count; ++i)
                        {
                                Constants.Debug.CW("i = " + i + "| name =  " + assignments[i]._name + " | " +
                                                "state =" + assignments[i]._state + " | " +
                                                "shodone = " + Preferences.GetShowDone());
                                if (assignments[i]._state == States.DONE && Preferences.GetShowDone())
                                {
                                        finalAssignments.Add(assignments[i]);
                                        Constants.Debug.CW("Removing this item");
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

                        Constants.Debug.CW("After the sort");

                        foreach (AdvancedTask item in finalAssignments)
                        {
                                Constants.Debug.CW(item._name);
                        }

                        return finalAssignments;

                }//SortTrainings()


        }//class Sorter()
}//ns
