using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class AlreadyExistingProject : PopUp
        {

                public ValidateButton _validateButton { get; set; }

                public AlreadyExistingProject(double width, double height, string content) : base ( width,  height, content)
                {
                        _validateButton = new ValidateButton(ControlsValues.NO_PROBLEMO, this.Width * 0.75, this.Width / 6, new Thickness(0, this.Width / 20, 0, 0), new Thickness(0, this.Width / 30, 0, 0), HorizontalAlignment.Center);
                        _validateButton.MouseDown += _validateButton_MouseDown;

                        _container.Children.Add(_validateButton);
                }

                void _validateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }
        }
}
