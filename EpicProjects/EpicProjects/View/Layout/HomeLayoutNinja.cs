using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using EpicProjects.View.Theme;

namespace EpicProjects.View.Layout
{
        public class HomeLayoutNinja : LayoutNinja
        {
                public Theme.Theme _theme { get; set; }

                public StackPanel _mainPanel { get; set; }
                public StackPanel _containerPanel { get; set; }

                public HomeLayoutNinja()
                {
                        _theme = new CustomTheme();
                        _mainPanel = new StackPanel();
                        _containerPanel = new StackPanel();


                        _mainPanel.Background = _theme.GetBackground();
                }
                public override StackPanel GetLayout()
                {
                        return _mainPanel;
                }
        }//class HomeLayoutNinja
}//ns
