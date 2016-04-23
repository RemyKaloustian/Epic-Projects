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

                }

                public CustomTheme(string accent) : base(accent)
                {   
                        _background = accent;

                        _accent = "#f5f5f5";
                        _hover = "#f5f5f5";
                        _popUpBackground = "#bdbdbd";
                        _validate = "#2ecc71";
                }

                public override SolidColorBrush GetBackground()
                {
                        return GetColor(_background);
                }

                public override SolidColorBrush GetAccentColor()
                {
                        return GetColor(_accent);
                }

                public  override SolidColorBrush GetPopUpBackground()
                {
                        return GetColor(_popUpBackground);
                }

                public override SolidColorBrush GetValidateColor()
                {
                        return GetColor(_validate);
                }

                public override SolidColorBrush GetHoverColor()
                {
                        return GetColor(_hover);
                }




                public override FontFamily GetTitleFont()
                {
                        throw new NotImplementedException();
                }

                public override FontFamily GetTextFont()
                {
                        throw new NotImplementedException();
                }

                public override uint GetFontSize()
                {
                        throw new NotImplementedException();
                }

                public override SolidColorBrush GetHighlightColor()
                {
                        return GetColor(Palette2.MIDNIGHT_BLUE);
                }

                public override SolidColorBrush GetButtonColor()
                {
                        return GetAccentColor();
                }

                public override SolidColorBrush GetButtonContentColor()
                {
                        return GetBackground();
                }

                public override SolidColorBrush GetAlertColor()
                {
                        return GetBackground();
                }

                public override SolidColorBrush GetContentBackground()
                {
                        return GetColor("#e0e0e0");
                }

                public override Brush GetButtonHoverColor()
                {
                        return GetBackground();
                }
        }//class CustomTheme
}//ns
