﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Constants
{
        public static class Debug
        {
                public static void CW(string display)
                {
                        System.Diagnostics.Debug.WriteLine("\n --------------------------------------------------\n  "+display + "\n--------------------------------------------------------\n");
                }//CW
        }//class Debug
}//ns
