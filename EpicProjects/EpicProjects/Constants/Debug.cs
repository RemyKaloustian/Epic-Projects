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
        /// This class exists because typing System.Diagnostics.Debug.Writeline() makes my hands bleed
        /// </summary>
        public static class Debug
        {
                //Writes display on the output
                public static void CW(string display)
                {
                        System.Diagnostics.Debug.WriteLine("\n --------------------------------------------------\n  "+display + "\n--------------------------------------------------------\n");
                }//CW

        }//class Debug
}//ns
