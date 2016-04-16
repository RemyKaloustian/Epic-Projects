using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class ReportBug : PopUp
        {
                public TextBlock _mail { get; set; }
                public TextBlock _detailsBlock { get; set; }
                public ValidateButton _sendButton { get; set; }

                public ReportBug(double width, double height, string content)
                        : base(width, height, content)
                {
                        //System.Diagnostics.Process.Start("http://google.com");

                        _mail = new TextBlock();
                        _mail.Text = "Send an email to remy.kaloustian@protonmail.com";
                        _mail.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _mail.FontFamily = FontProvider._lato;
                        _mail.FontSize = 20;
                        _mail.Margin = new System.Windows.Thickness(0, 30, 0, 0);


                        _detailsBlock = new TextBlock();
                        _detailsBlock.Text = "Please be specific and precise when describing the bug you encountered. Just saying \"Your app bugs\" won't help. Make sure to specify the window you were on, the section you were on, what you did, what happened, and what you think should have happened.";
                        _detailsBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _detailsBlock.FontFamily = FontProvider._lato;
                        _detailsBlock.Width = this.Width * 0.6;
                        _detailsBlock.FontSize = 16;
                        _detailsBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                        _detailsBlock.TextWrapping = System.Windows.TextWrapping.Wrap;


                        _sendButton = new ValidateButton("Send this mail right now", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 20, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());
                        _sendButton.MouseDown += _sendButton_MouseDown;

                        _container.Children.Add(_mail);
                        _container.Children.Add(_detailsBlock);
                        _container.Children.Add(_sendButton);
                }

                void _sendButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                        System.Diagnostics.Process.Start("http://google.com");
                }
        }//class ReportBug
}//ns
