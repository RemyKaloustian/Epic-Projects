using EpicProjects.Constants;
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
                public ValidateButton _sendButton { get; set; }

                public ReportBug(double width, double height, string content)
                        : base(width, height, content)
                {
                        this.Background = Palette2.GetColor(Palette2.SILVER);
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


                        _sendButton = new ValidateButton("Send this mail right now", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 20, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _sendButton.MouseDown += _sendButton_MouseDown;

                        _container.Children.Add(_mail);
                        _container.Children.Add(_detailsBlock);
                        _container.Children.Add(_sendButton);
                }

                void _sendButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                       ///////////////////TEST 1 
                        //  MailMessage message = new MailMessage();
                        //message.Subject = "EPIC PROJECTS - BUG REPORT";
                        //message.From = new MailAddress("remy.kaloustian@gmail.com");
                        //message.Body ="THER S A BUG MATE";
                        //message.To.Add("remy.kaloustian@gmail.com");

                        //SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        //smtp.Credentials = new NetworkCredential("remy.kaloustian", "9y2svy18");
                        //smtp.EnableSsl = true;
                        //smtp.Port = 587;
                        //smtp.Send(message);


                          ///////////////////TEST 2

                        //MailMessage mail = new MailMessage();
                        //SmtpClient Smtpclient = new SmtpClient("smtp.gmail.com");

                        //mail.From = new MailAddress("remy.kaloustian@gmail.com");
                        //mail.To.Add("remy.kaloustian@gmail.com");
                        //mail.Subject = "Test Mail";
                        //mail.Body = "This is for testing SMTP mail from GMAIL";

                        //Smtpclient.Port = 587;
                        //Smtpclient.Credentials = new System.Net.NetworkCredential("remy.kaloustian@gmail.com", "9y2svy18");
                        //Smtpclient.EnableSsl = true;
                        //Smtpclient.UseDefaultCredentials = false;

                        //Smtpclient.Send(mail);
                        //MessageBox.Show("mail Send");

                        /////TEST 3
                        //MailMessage mail = new MailMessage("remy.kaloustian@gmail.com", "remy.kaloustian@gmail.com");
                        //SmtpClient client = new SmtpClient();
                        //client.Port = 25;
                        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //client.UseDefaultCredentials = false;
                        //client.Host = "smtp.google.com";
                        //mail.Subject = "this is a test email.";
                        //mail.Body = "this is my test email body";
                        //client.Send(mail);

                        ///////TEST 4 
                        using (MailMessage mail = new MailMessage())
                        {
                                mail.From = new MailAddress("email@gmail.com");
                                mail.To.Add("remy.kaloustian@gmail.com");
                                mail.Subject = "Hello World";
                                mail.Body = "<h1>Hello</h1>";
                                mail.IsBodyHtml = true;

                                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                                {
                                        smtp.Credentials = new NetworkCredential("remy.kaloustian@gmail.com", "9y2svy18");
                                        smtp.EnableSsl = true;
                                        smtp.Send(mail);
                                }
                        }

                }


                
        }//class ReportBug
}//ns
