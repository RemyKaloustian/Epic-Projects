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

                public string _project{ get; set; }
                public ValidateButton _overallButton { get; set; }

                public ValidateButton _projectStatsButton{ get; set; }

                public CancelButton _closeButton { get; set; }

                public StatsPopUp(double width, double height, string content, string project)
                        : base(width, height, content)
                {
                        this.Background = ThemeSelector.GetPopUpBackground();

                        _project = project;
                        _overallButton = new ValidateButton("Overall stats", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 14, 0, 3), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _overallButton.MouseDown += _overallButton_MouseDown;

                        _projectStatsButton = new ValidateButton(project + " statistics", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 2, 0, 3), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _projectStatsButton.MouseDown += _projectStatsButton_MouseDown;

                        _closeButton = new CancelButton(ControlsValues.CLOSE, this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 2, 0, 3), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);

                        _closeButton.MouseDown += _closeButton_MouseDown;


                        _container.Children.Add(_overallButton);
                        _container.Children.Add(_projectStatsButton);
                        _container.Children.Add(_closeButton);
                }

                void _projectStatsButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                        ProjectStatsPopUp psp = new ProjectStatsPopUp(Dimensions.GetWidth() * 0.5, Dimensions.GetHeight() * 0.8, _project + " statictics", _project);
                }

                void _overallButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                        OverallStatsPopUp osp = new OverallStatsPopUp(Dimensions.GetWidth() * 0.5, Dimensions.GetHeight() * 0.8, "Overall Statistics");
                }//ctor()

                void _closeButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }
        }
}
