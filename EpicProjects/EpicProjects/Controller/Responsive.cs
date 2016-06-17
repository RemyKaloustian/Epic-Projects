﻿using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Controller
{
        public static class Responsive
        {
                public static int GetPopUpTextSize()
                {
                        int size = 10;
                        if(Dimensions.GetWidth() >= 1900)
                        {
                                size = 19;
                        }

                        else if(Dimensions.GetWidth() < 1900)
                        {
                                size = 14;
                        }

                        return size;
                }//GetPopUpTextSize()


                public static int GetButtonTextSize()
                {
                        int size = 14;
                        if (Dimensions.GetWidth() >= 1900)
                        {
                                size = 25;
                        }

                        else if (Dimensions.GetWidth() < 1900 && Dimensions.GetWidth() > 1200)
                        {
                                size = 19;
                        }

                        return size;
                }//GetPopUpTextSize()


        }//class Responsive
}//ns
