using EpicProjects.Constants;
using EpicProjects.Constants.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.View.Theme
{
        public class DarkTheme : Theme
        {
                public DarkTheme(string accent): base(accent)
                {

                }

                public override System.Windows.Media.SolidColorBrush GetBackground()
                {
                        return GetColor("#2c3e50");
                }

                public override System.Windows.Media.SolidColorBrush GetAccentColor()
                {
                        return GetColor(_accent);
                }

                public override System.Windows.Media.SolidColorBrush GetValidateColor()
                {
                        return this.GetAccentColor() ;
                }

                public override System.Windows.Media.SolidColorBrush GetHoverColor()
                {
                        return GetColor(WindowsPhonePalette.COBALT);
                }

                public override System.Windows.Media.SolidColorBrush GetPopUpBackground()
                {
                        return GetColor(Palette2.SILVER);
                }

                public override System.Windows.Media.FontFamily GetTitleFont()
                {
                        throw new NotImplementedException();
                }

                public override System.Windows.Media.FontFamily GetTextFont()
                {
                        throw new NotImplementedException();
                }

                public override uint GetFontSize()
                {
                        throw new NotImplementedException();
                }

                public override System.Windows.Media.SolidColorBrush GetHighlightColor()
                {
                        if(_accent == WindowsPhonePalette.LIGHT_GREY)
                                return GetColor(WindowsPhonePalette.TEAL);
                        return GetColor(WindowsPhonePalette.LIGHT_GREY);
                }

                public override System.Windows.Media.SolidColorBrush GetButtonColor()
                {
                        return GetColor("#607d8b");
                }

                public override System.Windows.Media.SolidColorBrush GetButtonContentColor()
                {
                        return GetColor("#f5f5f5");
                }

                public override System.Windows.Media.SolidColorBrush GetAlertColor()
                {
                        return GetAccentColor();
                }

                public override System.Windows.Media.SolidColorBrush GetContentBackground()
                {
                        return GetColor("#647687");
                }

                public override System.Windows.Media.Brush GetButtonHoverColor()
                {
                        return GetButtonContentColor();
                }
        }
}
