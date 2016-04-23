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

                public Theme()
                {
                        _accent = "#0050ef";
                        _popUpBackground = "#bdbdbd";
                }

                public Theme(string accent)
                {
                        _accent = accent;
                }


                public abstract SolidColorBrush GetBackground();

                public abstract SolidColorBrush GetAccentColor();

                public abstract SolidColorBrush GetValidateColor();

                public abstract SolidColorBrush GetHoverColor();

                public abstract SolidColorBrush GetPopUpBackground();

                public abstract SolidColorBrush GetHighlightColor();

                public abstract SolidColorBrush GetButtonColor();

                public abstract SolidColorBrush GetButtonContentColor();

                public abstract SolidColorBrush GetAlertColor();

                public abstract SolidColorBrush GetContentBackground();
               

                public SolidColorBrush GetColor(string color)
                {

                        Constants.Debug.CW("In GetColor, color = " + color);
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                }

                public abstract FontFamily GetTitleFont();

                public abstract  FontFamily GetTextFont();

                public abstract uint GetFontSize();


                
        }//class Theme
}//ns
