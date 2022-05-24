using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ermes.API;
using Ermes.Dataclasses;

namespace Ermes.LoginPages
{
    /// <summary>
    /// Interaction logic for PasswordRecoveryPage.xaml
    /// </summary>
    public partial class PasswordRecoveryPage : Page
    {
        User user;
        string resetCode;

        public PasswordRecoveryPage()
        {
            InitializeComponent();
        }

        private void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Generates random code
             */
            resetCode = new Random().Next(99999999).ToString();

            try
            {
                user = UserController.FindUserByEmail(Email.Text.Trim());

                if (user.email == Email.Text)
                {
                    MailAddress from = new MailAddress("ermesmailservice@gmail.com");
                    MailAddress to = new MailAddress(user.email);

                    /*
                     * SMTP client setup
                     */
                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("ermesmailservice@gmail.com", "mailService101"),
                        Timeout = 16000
                    };

                    /*
                     * Mail content generation
                     */
                    using (MailMessage message = new MailMessage(from, to)
                    {
                        Subject = "Ermes password reset code",
                        IsBodyHtml = true,
                        Body = "<h1><b style='color:green';>Ermes password reset code</b></h1>" +
                               "<p>Hello " + user.username + "!</p>" +
                               "<p>Your password reset code is the following: <b>" + resetCode + "</b></p>" +
                               "<p>If you did not request a password reset, someone may be trying to access your account.</p>" +
                               "<p>Thanks," + "<br/>" + 
                               "Ermes Account Administration</p>"                 
                    })
                    {
                        try
                        {
                            smtp.Send(message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mail Service Failed");
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something when wrong:\n" + ex.Message);
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Code.Text.Trim() == resetCode)
            {
                PasswordResetPage passwordResetPage = new PasswordResetPage(user);
                NavigationService.Navigate(passwordResetPage);
            }
        }
    }
}
