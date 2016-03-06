using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using EpicProjects.View.Theme;
using EpicProjects.Constants;
using System.Windows.Media;

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
                        SetUpMainAndContainer();
                }

                private void SetUpMainAndContainer()
                {
                        _mainPanel = new StackPanel();
                        _containerPanel = new StackPanel();
                        _containerPanel.Height = Dimensions.GetHeight();
                        _containerPanel.Width = Dimensions.GetWidth() * 0.8;
                        _containerPanel.Background = new SolidColorBrush(Colors.Bisque);


                        _mainPanel.Children.Add(_containerPanel);
                        _mainPanel.Background = _theme.GetBackground();
                }
                public override StackPanel GetLayout()
                {
                        return _mainPanel;
                }
        }//class HomeLayoutNinja
}//ns
