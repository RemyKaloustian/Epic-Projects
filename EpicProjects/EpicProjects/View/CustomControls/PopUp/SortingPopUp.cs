using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class SortingPopUp : PopUp
        {

                public ValidateButton _sortImportanceButton { get; set; }
                public ValidateButton _sortStateButton{ get; set; }
                public ValidateButton  _sortCreationButton{ get; set; }


                public SortingPopUp(double width, double height, string content)
                        : base(width, height, content)
                {
                        this.Background = ThemeSelector.GetPopUpBackground();

                        _sortImportanceButton = new ValidateButton("Sort by importance", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _sortImportanceButton.MouseDown += _sortButton_MouseDown;

                        _sortStateButton = new ValidateButton("Sort by state", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _sortStateButton.MouseDown += _sortButton_MouseDown;

                        _sortCreationButton = new ValidateButton("Sort by creation date", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _sortCreationButton.MouseDown += _sortButton_MouseDown;
                               


                        _container.Children.Add(_sortImportanceButton);
                        _container.Children.Add(_sortStateButton);
                        _container.Children.Add(_sortCreationButton);
                }

                void _sortButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Hide();
                }


        }//class SortingPopUp
}//ns
