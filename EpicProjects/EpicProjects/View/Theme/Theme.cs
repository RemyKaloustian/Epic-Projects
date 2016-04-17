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


                public  string _background { get; set; }
                public  string  _accent { get; set; }
                public  string _validate{ get; set; }
                public  string _hover { get; set; }
                public  string _popUpBackground { get; set; }

                public Theme(string accent)
                {
                        _accent = accent;
                }


             

                #region UselessNow

                public abstract SolidColorBrush GetBackground();

                public abstract SolidColorBrush GetAccentColor();

                public abstract SolidColorBrush GetValidateColor();

                public abstract SolidColorBrush GetHoverColor();

                public abstract SolidColorBrush GetPopUpBackground();

                public SolidColorBrush GetColor(string color)
                {
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                }

                public abstract FontFamily GetTitleFont();

                public abstract  FontFamily GetTextFont();

                public abstract uint GetFontSize();

                #endregion
        }//class Theme
}//ns
