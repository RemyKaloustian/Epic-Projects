using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


using EpicProjects.Database;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class RenamePopUp : PopUp
        {
                public ValidateButton _validateButton { get; set; }
                public CancelButton _cancelButton { get; set; }
                public TextBox _nameBox { get; set; }


                public RenamePopUp(double width, double height, string content) : base ( width,  height,  content)
                {
                        _block.Text = "Renaming " + _block.Text + " To ";

                        _nameBox = new TextBox();
                        _nameBox.Width = width * 0.7;
                        _nameBox.Height = height / 10;
                        _nameBox.FontFamily = FontProvider._lato;
                        _nameBox.FontSize = 15;
                        _nameBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _validateButton = new ValidateButton(ControlsValues.COOL, this.Width * 0.75, this.Width / 6, new Thickness(0, this.Width / 20, 0, 0), new Thickness(0, this.Width / 30, 0, 0), HorizontalAlignment.Center, _theme);
                        _validateButton.MouseDown += _validateButton_MouseDown;

                         _cancelButton = new CancelButton(ControlsValues.NEVER_MIND, this.Width * 0.75, this.Width / 6, new Thickness(0, this.Width / 20, 0, 0), new Thickness(0, this.Width / 30, 0, 0), HorizontalAlignment.Center, _theme);
                         _cancelButton.MouseDown += _cancelButton_MouseDown;

                         _container.Children.Add(_nameBox);
                         _container.Children.Add(_validateButton);
                         _container.Children.Add(_cancelButton);
                }

                void _validateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                        DatabaseGuru guru = new DatabaseGuru( Paths.PROJECTSSAVE);
                        guru._propUpdater.UpdateProject(_block.Text, DatabaseValues.NAME, _nameBox.Text);
                        this.Close();
                }

                void _cancelButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }





        }//class RenamePopUp
}//ns
