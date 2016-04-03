using EpicProjects.Constants;
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
                       _centralPanel = new CentralPanel();
                       _centralPanel.Background = Palette2.GetColor(Palette2.EMERALD);

                       StackPanel container = new StackPanel();
                       container.Orientation = Orientation.Horizontal;
                       container.Children.Add(_menuPanel);
                       container.Children.Add(_centralPanel);

                       return container;
                }
        }//class ProjectLayoutNinja
}//ns
