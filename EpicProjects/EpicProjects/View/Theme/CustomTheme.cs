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
                        _popUpBackground = "#2c3e50";
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
        }//class CustomTheme
}//ns
