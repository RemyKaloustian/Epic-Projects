﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicProjects.Constants
{
        public class Palette2
        {
                public static SolidColorBrush GetColor(string color)
                {
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                }//GetColor()

                public static readonly string TURQUOISE = "#1abc9c";
                public static readonly string EMERALD = "#2ecc71";
                public static readonly string PETER_RIVER = "#3498db";
                public static readonly string AMETHYST = "#9b59b6";
                public static readonly string WET_ASPHALT = "#34495e";
                public static readonly string GREEN_SEA = "#16a085";
                public static readonly string NEPHRITIS = "#27ae60";
                public static readonly string BELIZE_HOLE = "#2980b9";
                public static readonly string WISTERIA = "#8e44ad";
                public static readonly string MIDNIGHT_BLUE = "#2c3e50";
                public static readonly string SUN_FLOWER = "#f1c40f";
                public static readonly string CARROT = "#e67e22";
                public static readonly string ALIZARIN = "#e74c3c";
                public static readonly string CONCRETE = "#95a5a6";
                public static readonly string ORANGE = "#f39c12";
                public static readonly string PUMPKIN = "#d35400";
                public static readonly string POMEGRANATE = "#c0392b";
                public static readonly string SILVER = "#bdc3c7";
                public static readonly string ASBESTOS = "#7f8c8d";

                public static readonly string VALIDATE = "#2CC990";
                public static readonly string VALIDATE_HOVER = "#64DDBB";


                public static readonly string CANCEL = "#E01931";
                public static readonly string CANCEL_HOVER = "#C82647";

                public static readonly string ALTERNATIVE = "#8870FF";
                public static readonly string ALTERNATIVE_HOVER = "#5659C9";

                public static readonly string DEFAULT_HOVER = "#19B5FE";

                public static readonly string THIN_GRAY = "#f5f5f5";


                public static readonly string LIGHT_GRAY = "#cfd8dc";
        }
}
