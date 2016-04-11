using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//*
// *  @Author : Rémy Kaloustian
// * 
// * /

namespace EpicProjects.Constants
{

        /// <summary>
        /// This class contains the constants variables corresponding to the database management
        /// </summary>
        static class DatabaseValues
        {
               
                //Tables fields
                
                public static readonly string PROJECT = "Project";               
                public static readonly string TASK = "task";

                public static readonly string BRAINSTORMING = "Brainstorming";
                public static readonly string TRAINING = "Training";
                public static readonly string ASSIGNMENT = "Assignment";
                public static readonly string MAINTENANCE = "Maintenance";

              

                //Attributes fields
                public static readonly string ID = "id";
                public static readonly string NAME = "name";
                public static readonly string DETAILS = "details";
                public static readonly string PRIORITY = "priority";
                public static readonly string STATE = "state";
                public static readonly string PROJECT_LINK = "project";

                public static readonly string STARTDATE = "startdate";
                public static readonly string ENDDATE = "enddate";
                public static readonly string TYPE = "type";

                //XML used fields 

               
                public static readonly string BRAINSTORMINGS = "Brainstormings";
                public static readonly string TRAININGS = "Trainings";
                public static readonly string ASSIGNMENTS = "Assignments";
                public static readonly string MAINTENANCES="Maintenances";

                //Paths in XML
                public static readonly string PROJECT_PATH = "/Projects/Project";
                public static readonly string BRAINSTORMINGS_PATH = "Brainstormings/Brainstorming";
                public static readonly string TRAININGS_PATH = "Trainings/Training";
                public static readonly string ASSIGNMENTS_PATH = "Assignments/Assignment";
                public static readonly string MAINTENANCES_PATH = "Maintenances/Maintenance";



                 

        }//class Database
}//ns
