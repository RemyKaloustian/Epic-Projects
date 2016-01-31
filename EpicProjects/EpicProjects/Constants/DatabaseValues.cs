using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Constants
{

        /// <summary>
        /// This class contains the constants variables corresponding to the database management
        /// </summary>
        static class DatabaseValues
        {
                public static readonly string CONNECTIONSTRING = "EpicProjects.Properties.Settings.EpicProjectsDataBaseConnectionString";

                //Tables fields
                public static readonly string ID = "id";
                public static readonly string PROJECT = "project";
                public static readonly string STARTDATE = "startdate";
                public static readonly string ENDDATE = "enddate";


                //Attributes fields
                public static readonly string NAME = "name";
        }//class Database
}//ns
