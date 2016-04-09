using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class NewTaskPopUp : PopUp
        {
                public TextBlock _nameBlock { get; set; }
                public TextBox _nameBox { get; set; }

                public TextBlock _alertBlock { get; set; }

                public TextBlock _detailsBlock { get; set; }
                public TextBox _detailsBox { get; set; }

                public ValidateButton _validateButton { get; set; }
                public CancelButton _cancelButton { get; set; }

                public NewTaskPopUp(double width, double height, string content)
                        : base(width,  height,  content)
                {
                        this.Background = new Theme.CustomTheme().GetPopUpBackground();

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = "Name : ";

                        _nameBox = new TextBox();

                        _alertBlock = new TextBlock();

                        _detailsBlock = new TextBlock();
                        _detailsBlock.Text = "Description";

                        _detailsBox = new TextBox();

                        _validateButton = new ValidateButton( "Create",this.Width*0.5,this.Height*0.05,new System.Windows.Thickness(0,0,0,0),new System.Windows.Thickness(5,5,5,5), System.Windows.HorizontalAlignment.Center,new Theme.CustomTheme());

                        _cancelButton = new CancelButton("Cancel", this.Width * 0.5, this.Height * 0.05, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _cancelButton.MouseDown += _cancelButton_MouseDown;

                        _container.Children.Add(_nameBlock);
                        _container.Children.Add(_nameBox);
                        _container.Children.Add(_alertBlock);
                        _container.Children.Add(_detailsBlock);
                        _container.Children.Add(_detailsBox);
                        _container.Children.Add(_validateButton);
                        _container.Children.Add(_cancelButton);



                }

                void _cancelButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }
        }
}
