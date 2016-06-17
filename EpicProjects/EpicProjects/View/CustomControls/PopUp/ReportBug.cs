using EpicProjects.Constants;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class ReportBug : PopUp
        {
                public TextBlock _mail { get; set; }
                public TextBlock _detailsBlock { get; set; }
                public TextBox _mailBox { get; set; }
                public TextBox _bugBox { get; set; }

                public TextBlock _mailSendingBlock { get; set; }
                public ValidateButton _sendButton { get; set; }
                public CancelButton _closeButton { get; set; }

                public FailSendingPopUp _mailSendingPopUp { get; set; }

                public ReportBug(double width, double height, string content)
                        : base(width, height, content)
                {
                        this.Background = ThemeSelector.GetPopUpBackground();
                        _mail = new TextBlock();
                        _mail.Text = "Send an email to remy.kaloustian@protonmail.com";
                        _mail.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _mail.FontFamily = FontProvider._lato;
                        _mail.FontSize = 20;
                        _mail.Margin = new System.Windows.Thickness(0, 30, 0, 0);


                        _detailsBlock = new TextBlock();
                        _detailsBlock.Text = "Please be specific and precise when describing the bug you encountered. Just saying \"Your app bugs\" won't help. Make sure to specify the window you were on, the section you were on, what you did, what happened, and what you think should have happened. \n\n \t Please type in your mail address so that we can answer  you.";
                        _detailsBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _detailsBlock.FontFamily = FontProvider._lato;
                        _detailsBlock.Width = this.Width * 0.6;
                        _detailsBlock.FontSize = 19;
                        _detailsBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                        _detailsBlock.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _detailsBlock.TextAlignment = TextAlignment.Justify;



                        _mailBox = new TextBox();
                        _mailBox.Width = this.Width * 0.5;
                        _mailBox.Height = this.Height * 0.03;
                        _mailBox.FontFamily = FontProvider._lato;
                        _mailBox.FontSize = 15;
                        _mailBox.TextWrapping = TextWrapping.Wrap;
                        _mailBox.Margin = new Thickness(0, 20, 0, 0);
                        _mailBox.TextChanged += _mailBox_TextChanged;


                        _bugBox = new TextBox();
                        _bugBox.Width = this.Width * 0.5;
                        _bugBox.Height = this.Height * 0.1;
                        _bugBox.FontFamily = FontProvider._lato;
                        _bugBox.FontSize = 15;
                        _bugBox.TextWrapping = TextWrapping.Wrap;
                        _bugBox.Margin = new Thickness(0, 20, 0, 0);

                        _bugBox.TextChanged += _bugBox_TextChanged;


                        _mailSendingBlock = new TextBlock();
                        _mailSendingBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _mailSendingBlock.FontFamily = FontProvider._lato;
                        _mailSendingBlock.FontSize = 25;
                        _mailSendingBlock.Margin = new System.Windows.Thickness(0, 5, 0, 0);
                        _mailSendingBlock.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _mailSendingBlock.Foreground = ThemeSelector.GetButtonContentColor();
                        _mailSendingBlock.Text = "Sending the mail might take a few seconds.";

                        _sendButton = new ValidateButton("Send this mail right now", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _sendButton.IsEnabled = false;
                        _sendButton.MouseDown += _sendButton_MouseDown;

                        _closeButton = new CancelButton("I am debugging this myself", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 10, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);

                        _closeButton.MouseDown += _closeButton_MouseDown;

                        //_container.Children.Add(_mail);
                        _container.Children.Add(_detailsBlock);
                        _container.Children.Add(_mailBox);
                        _container.Children.Add(_bugBox);
                        _container.Children.Add(_mailSendingBlock);
                        _container.Children.Add(_sendButton);
                        _container.Children.Add(_closeButton);
                }

                void _mailBox_TextChanged(object sender, TextChangedEventArgs e)
                {
                        if (_bugBox.Text.Trim() != "" && _mailBox.Text.Trim() != "")
                        {
                                _sendButton.IsEnabled = true;
                        }
                        else
                        {
                                _sendButton.IsEnabled = false;

                        }
                }

                void _closeButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }

                void _bugBox_TextChanged(object sender, TextChangedEventArgs e)
                {
                        if (_bugBox.Text.Trim() != "" && _mailBox.Text.Trim() != "")
                        {
                                _sendButton.IsEnabled = true;

                        }
                        else
                        {
                                _sendButton.IsEnabled = false;

                        }
                }

                void _sendButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        //_mailSendingPopUp = new MailSendingPopUp(this.Width * 0.5, this.Height * 0.5, "Sending mail, hold tight");
                        //_mailSendingPopUp.Show();
                        try
                        {
                                using (MailMessage mail = new MailMessage())
                                {
                                        mail.From = new MailAddress("email@gmail.com");
                                        mail.To.Add("remy.kaloustian@gmail.com");
                                        mail.Subject = "EPIC PROJECTS - BUG REPORT";
                                        mail.Body = _mailBox.Text + "\n" + _bugBox.Text + "</h6>";
                                        mail.IsBodyHtml = true;


                                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                                        {
                                                smtp.Credentials = new NetworkCredential("remy.kaloustian@gmail.com", "9y2svy18");
                                                smtp.EnableSsl = true;
                                                smtp.Send(mail);
                                        }
                                }

                                // _mailSendingPopUp.Close();
                                this.Close();
                        }
                        catch (System.Exception)
                        {
                                FailSendingPopUp p = new FailSendingPopUp(Dimensions.GetWidth()*0.5, Dimensions.GetHeight()*0.4,"Oops...");
                                p.Show();
                                this.Close();
                        }
                      

                }//_sendButton_MouseDown()



        }//class ReportBug
}//ns
