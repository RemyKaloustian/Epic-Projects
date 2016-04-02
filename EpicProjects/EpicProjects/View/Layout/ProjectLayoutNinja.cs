using EpicProjects.View.CustomControls.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.Layout
{
        public class ProjectLayoutNinja :LayoutNinja
        {
                public StackPanel _menuPanel { get; set; }
                public StackPanel _centralPanel { get; set; }

                public override System.Windows.Controls.StackPanel GetLayout()
                {
                       _menuPanel = new SideMenuPanel();

                       StackPanel container = new StackPanel();
                       container.Orientation = Orientation.Horizontal;
                       container.Children.Add(_menuPanel);

                       return container;
                }
        }//class ProjectLayoutNinja
}//ns
