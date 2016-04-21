using EpicProjects.Constants;
using EpicProjects.Constants.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Items
{
        public class ColorItem : StackPanel
        {
                public string _accent { get; set; }
                public ColorItem(string accent)
                {
                        _accent = accent;
                        this.Width = 100;
                        this.Height = 100;
                        this.Background = Palette2.GetColor(accent);
                        this.Margin = new System.Windows.Thickness(0, 0, 9, 0);
                }
        }//class StackPanel
}//ns
