using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicProjects.View.Theme
{
        public abstract class Theme
        {


                public static string _background { get; set; }
                public static string  _accent { get; set; }
                public static string _validate{ get; set; }
                public static string _hover { get; set; }

                public static string _popUpBackground { get; set; }


                public static void Initialize()
                {

                }

                #region UselessNow

                public abstract SolidColorBrush GetBackground();

                public abstract SolidColorBrush GetAccentColor();

                public abstract FontFamily GetTitleFont();

                public abstract  FontFamily GetTextFont();

                public abstract uint GetFontSize();

                #endregion
        }//class Theme
}//ns
