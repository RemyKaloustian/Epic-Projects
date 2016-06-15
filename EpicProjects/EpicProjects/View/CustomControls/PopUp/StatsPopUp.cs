using EpicProjects.Constants;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class StatsPopUp : PopUp
        {
                public CancelButton _closeButton { get; set; }

                public StatsPopUp(double width, double height, string content)
                        : base(width, height, content)
                {
                        this.Background = ThemeSelector.GetPopUpBackground();
                        _closeButton = new CancelButton(ControlsValues.CLOSE, this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 14, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);

                        _closeButton.MouseDown += _closeButton_MouseDown;

                        _container.Children.Add(_closeButton);
                }

                void _closeButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }
        }
}
