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
                public CustomTheme()
                {

                }//CustomTheme()

                public override SolidColorBrush GetBackground()
                {
                        return Palette2.GetColor(WindowsPhonePalette.YELLOW);
                }

                public override SolidColorBrush GetAccentColor()
                {
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom("#ececec"));
                }

                public SolidColorBrush GetPopUpBackground()
                {
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom("#b0bec5"));

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


        }//class CustomTheme
}//ns
