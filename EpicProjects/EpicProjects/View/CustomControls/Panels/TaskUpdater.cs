using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class TaskUpdater : StackPanel
        {
                public TextBlock _nameBlock { get; set; }
                public TextBox _nameBox { get; set; }

                public TextBlock _detailsBlock { get; set; }
                public TextBox _detailsBox { get; set; }

                public ValidateButton _applyButton { get; set; }
                public CancelButton _nopeButton { get; set; }


                public TaskUpdater(string name, string details)
                {
                        this.Orientation = Orientation.Vertical;

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = "Name";

                        _nameBox = new TextBox();
                        _nameBox.Text = name;
                        _nameBox.TextWrapping = System.Windows.TextWrapping.Wrap;

                        _detailsBlock = new TextBlock();
                        _detailsBlock.Text = "Details";

                        _detailsBox = new TextBox();
                        _detailsBox.Text = details;
                        _detailsBox.TextWrapping = System.Windows.TextWrapping.Wrap;


                        _applyButton = new ValidateButton(ControlsValues.APPLY, this.Width * 0.6, this.Height * 0.05, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _nopeButton = new CancelButton(ControlsValues.NOPE, this.Width * 0.6, this.Height * 0.05, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());


                        this.Children.Add(_nameBlock);
                        this.Children.Add(_nameBox);
                        this.Children.Add(_detailsBlock);
                        this.Children.Add(_detailsBox);

                        this.Children.Add(_applyButton);
                        this.Children.Add(_nopeButton);
                }



        }//class TaskUpdater
}//ns
