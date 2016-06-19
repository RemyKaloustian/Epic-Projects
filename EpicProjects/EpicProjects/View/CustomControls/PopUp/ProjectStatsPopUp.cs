using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        class ProjectStatsPopUp:PopUp
        {
                public Separator _separator { get; set; }

                public ProjectStatsPopUp(double width, double height, string content, string project)
                        : base(width, height, content)
                {
                        _separator = new Separator();
                        _separator.Width = this.Width * 0.6;
                        _separator.Background = Palette2.GetColor(Palette2.THIN_GRAY);

                        _container.Children.Add(_separator);
                }
        }//class ProjectsStatsPopUp
}//ns
