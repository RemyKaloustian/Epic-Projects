using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.View.Theme
{
        public   class LightTheme : Theme
        {

                public LightTheme(string accent): base (accent)
                {

                }
                public override System.Windows.Media.SolidColorBrush GetBackground()
                {
                        return this.GetColor("#f5f5f5");
                }

                public override System.Windows.Media.SolidColorBrush GetAccentColor()
                {
                        return GetColor(_accent);
                }

                public override System.Windows.Media.SolidColorBrush GetValidateColor()
                {
                        return GetAccentColor();
                }

                public override System.Windows.Media.SolidColorBrush GetHoverColor()
                {
                        return GetColor(Palette2.SILVER);
                }

                public override System.Windows.Media.SolidColorBrush GetPopUpBackground()
                {
                        return GetColor(Palette2.CONCRETE);
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
        }
}
