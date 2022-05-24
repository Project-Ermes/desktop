using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Ermes.Properties;
using Ermes.Dataclasses;
using Ermes.API;
using System.Text.RegularExpressions;

namespace Ermes.LoginPages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        User user;

        public LoginPage()
        {
            InitializeComponent();

            /*
             * If user clicked the "Remember me" checkbox,
             * the following code will generate the username 
             * in the username textbox
             */
            if (Settings.Default.LastUser != "")
            {
                Username.Text = UserController.GetUser(Properties.Settings.Default.LastUser).username;
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            SignInPage signInPage = new SignInPage();
            NavigationService.Navigate(signInPage);
        }

        private void RecoverPassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordRecoveryPage passwordRecoveryPage = new PasswordRecoveryPage();
            NavigationService.Navigate(passwordRecoveryPage);
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*
                 * User validation and network exception handler
                 */
                user = UserController.FindUserByUsername(this.Username.Text);

                if (ValidLogin(user))
                {
                    /*
                     * Change user settings
                     * if boxes are checked
                     */
                    if (RememberUser.IsChecked == true)
                    {
                        Settings.Default.Properties["LastUser"].DefaultValue = user._id;
                        Settings.Default.Save();
                    }
                    if (StayLoggedIn.IsChecked == true)
                    {
                        Settings.Default.Properties["StayLoggedIn"].DefaultValue = true;
                        Settings.Default.Save();
                    }


                    Settings.Default.Properties["CurrentUser"].DefaultValue = user._id;
                    Settings.Default.Save();

                    //MessageBox.Show(Settings.Default.CurrentUser);
                    //MessageBox.Show(Settings.Default.LastUser);
                    //MessageBox.Show(Settings.Default.StayLoggedIn.ToString());

                    MainWindow mainWindow = new MainWindow(user);
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

        public bool ValidLogin(User user)
        {
            bool valid = true;

            if (user == null)
            {
                valid = false;
            }
            else if (user.password != Password.Password)
            {
                valid = false;
            }
            return valid;
        }

    }
}
