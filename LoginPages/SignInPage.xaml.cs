using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.Net.Mail;
using Ermes.Dataclasses;
using Ermes.API;

namespace Ermes.LoginPages
{
    /// <summary>
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        User user;

        public SignInPage()
        {
            InitializeComponent();

            Birthdate.Text = "Select a date";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Username.Text = "";
            Password.Password = "";
            Email.Text = "";
            Name.Text = "";
            Surname.Text = "";
            Birthdate.Text = "Select a date";
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidSignIn())
                {
                    user = new User(Username.Text.Trim(), Password.Password.Trim(), Email.Text.Trim(),
                        Name.Text.Trim(), Surname.Text.Trim(), Birthdate.SelectedDate.Value);

                    UserController.PostUser(user);

                    Properties.Settings.Default.CurrentUser = user.username;
                    Properties.Settings.Default.Save();

                    MainWindow mainWindow = new MainWindow(UserController.FindUserByUsername(user.username));
                    Application.Current.MainWindow = mainWindow;
                    mainWindow.Show();
                    Window.GetWindow(this).Close();
                }

            } 
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Check your network connection and try again later: \n" + ex,
                    "User validation Error"
                );
            }
        }

        public bool ValidSignIn()
        {
            bool valid = true;

            if (!new Regex(@"^([a-zA-Z0-9 _-]{3,25})$").IsMatch(Username.Text.Trim()))
            {
                Username.BorderBrush = Brushes.Red;
                UsernameEllipse.Visibility = Visibility.Visible;
                UsernameTtTitle.Text = "Incorrect Format";
                UsernameTtDescription.Text = "Can only contain letters, numbers, dashes underscores and spaces. Must be 3-25 characters.";
                valid = false;
            }
            else if (UserController.FindUserByUsername(Username.Text.Trim()) != null)
            {
                Username.BorderBrush = Brushes.Red;
                UsernameEllipse.Visibility = Visibility.Visible;
                UsernameTtTitle.Text = "Username in use";
                UsernameTtDescription.Text = "This username is taken, please choose another one";
                valid = false;
            }
            if (Password.Password.Trim().Length < 8)
            {
                Password.BorderBrush = Brushes.Red;
                PasswordEllipse.Visibility = Visibility.Visible;
                PasswordTtTitle.Text = "Password is too short";
                PasswordTtDescription.Text = "Must be 8 characters or longer";
                valid = false;
            }
            try { Email.Text = new MailAddress(Email.Text.Trim()).Address; } catch (FormatException)
            {
                Email.BorderBrush = Brushes.Red;
                EmailEllipse.Visibility = Visibility.Visible;
                EmailTtTitle.Text = "Email is invalid";
                EmailTtDescription.Text = "Email format is incorrect";
                valid = false;
            }
            if (valid == true && UserController.FindUserByEmail(Email.Text.Trim()) != null)
            {
                Email.BorderBrush = Brushes.Red;
                EmailEllipse.Visibility = Visibility.Visible;
                EmailTtTitle.Text = "Email is taken";
                EmailTtDescription.Text = "This email is already associated with an account";
                valid = false;
            }
            if (!new Regex(@"^([a-zA-Z]{1,25})$").IsMatch(Name.Text.Trim()))
            {
                Name.BorderBrush = Brushes.Red;
                FullNameEllipse.Visibility = Visibility.Visible;
                FullNameTtTitle.Text = "Incorrect Format";
                FullNameTtDescription.Text = "Name must have 1-25 characters, with no numbers or special characters";
                valid = false;
            }
            else if (!new Regex(@"^([a-zA-Z]{1,25})$").IsMatch(Surname.Text.Trim()))
            {
                Surname.BorderBrush = Brushes.Red;
                FullNameEllipse.Visibility = Visibility.Visible;
                FullNameTtTitle.Text = "Incorrect Format";
                FullNameTtDescription.Text = "Surname must have 1-25 characters, with no numbers or special characters";
                valid = false;
            }
            return valid;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BorderBrush = Brushes.Gray;
        }
    }
}
