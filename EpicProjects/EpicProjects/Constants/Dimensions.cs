using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EpicProjects.Constants
{
        /// <summary>
        /// This class allows to get the dimensions of the screen
        /// </summary>
        public class Dimensions
        {
                public static double GetHeight()
                {
                        return System.Windows.SystemParameters.PrimaryScreenHeight;
                }

                public static double GetWidth()
                {
                        return System.Windows.SystemParameters.PrimaryScreenWidth;
                }
        }//class Dimensions
}//ns
