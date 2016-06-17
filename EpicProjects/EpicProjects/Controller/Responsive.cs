using EpicProjects.Constants;
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

                public static int GetSideMenuTextSize()
                {
                        int size = 12;
                        if (Dimensions.GetWidth() >= 1900)
                        {
                                size = 20;
                        }

                        else if (Dimensions.GetWidth() < 1900 && Dimensions.GetWidth() > 1200)
                        {
                                size = 15;
                        }

                        return size;
                }//GetSideMenuTextSize()


                public static int GetTaskDetailsSize()
                {
                        int size = 15;
                        if (Dimensions.GetWidth() >= 1900)
                        {
                                size = 28;
                        }

                        else if (Dimensions.GetWidth() < 1900 && Dimensions.GetWidth() > 1200)
                        {
                                size = 20;
                        }

                        return size;
                }//GetTaskDetailsSize()


                public static int GetPriorityAndStateSize()
                {
                        int size = 12;
                        if (Dimensions.GetWidth() >= 1900)
                        {
                                size = 22;
                        }

                        else if (Dimensions.GetWidth() < 1900 && Dimensions.GetWidth() > 1200)
                        {
                                size = 16;
                        }

                        return size;
                }//GetPriorityAndStateSize()

                public static int GetTaskDescriptionSize()
                {
                        int size = 11;
                        if (Dimensions.GetWidth() >= 1900)
                        {
                                size = 15;
                        }

                        else if (Dimensions.GetWidth() < 1900 && Dimensions.GetWidth() > 1200)
                        {
                                size = 12;
                        }

                        return size;
                }//GetTaskDescriptionSize()


                public static int GetComboSize()
                {
                        int size = 12;
                        if (Dimensions.GetWidth() >= 1900)
                        {
                                size = 18;
                        }

                        return size;
                }


        }//class Responsive
}//ns
