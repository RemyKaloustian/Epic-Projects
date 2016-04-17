using EpicProjects.Constants;
using EpicProjects.Constants.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicProjects.View.Theme
{
        public class CustomTheme : Theme
        {
                

                public override SolidColorBrush GetBackground()
                {
                        return GetColor(_accent);
                }

                public override SolidColorBrush GetAccentColor()
                {
                        return GetColor("#f5f5f5");
                }

                public SolidColorBrush GetPopUpBackground()
                {
                        return GetColor(_accent);
                }

                public override FontFamily GetTitleFont()
                {
                        return new FontFamily("Segoe UI");
                }

                public override FontFamily GetTextFont()
                {
                        return new FontFamily("Lato Light");
                }

                public override uint GetFontSize()
                {
                        throw new NotImplementedException();
                }



                public override SolidColorBrush GetValidateColor()
                {
                        return GetBackground();
                }

                public override SolidColorBrush GetHoverColor()
                {
                        return GetAccentColor();
                }
        }//class CustomTheme
}//ns
