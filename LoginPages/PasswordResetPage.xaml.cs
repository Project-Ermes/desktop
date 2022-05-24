using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media;
using Ermes.Dataclasses;
using Ermes.API;

namespace Ermes.LoginPages
{
    /// <summary>
    /// Interaction logic for PasswordResetPage.xaml
    /// </summary>
    public partial class PasswordResetPage : Page
    {
        User user;

        public PasswordResetPage(User u)
        {
            InitializeComponent();
            user = u;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (ValidPassword())
            {
                user.password = Password.Password;
                UserController.PostUser(user);

                MainWindow mainWindow = new MainWindow(UserController.FindUserByUsername(user.username));
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                Window.GetWindow(this).Close();
            }
        }

        public bool ValidPassword()
        {
            bool valid = true;

            if (Password.Password.Length < 8)
            {
                Password.BorderBrush = Brushes.Red;
                PasswordEllipse.Visibility = Visibility.Visible;
                PasswordTtTitle.Text = "Password is too short";
                PasswordTtDescription.Text = "Must be 8 characters or longer";
                valid = false;
            }
            if (ConfirmPassword.Password != Password.Password)
            {
                ConfirmPassword.BorderBrush = Brushes.Red;
                ConfirmPasswordEllipse.Visibility = Visibility.Visible;
                ConfirmPasswordTtTitle.Text = "Password is too short";
                ConfirmPasswordTtDescription.Text = "Must be 8 characters or longer";
                valid = false;
            }

            return valid;
        }
    }
}
