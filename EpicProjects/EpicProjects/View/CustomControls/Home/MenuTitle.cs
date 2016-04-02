using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Home
{
        public class MenuTitle : TextBlock
        {
                public MenuTitle(string content, int fontSize)
                {
                        this.Text = content;
                        this.FontSize = fontSize;
                        this.FontFamily = FontProvider._proxima;

                        this.Foreground = new Theme.CustomTheme().GetAccentColor();
                }

        }//class MenuTitle
}//ns
