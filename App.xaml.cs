using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ermes.API;
using Ermes.Properties;

namespace Ermes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Settings.Default.Upgrade();

            if (Settings.Default.StayLoggedIn)
            {
                MainWindow mainWindow = new MainWindow(UserController.GetUser(Settings.Default.LastUser));
                mainWindow.Show();
            }
            else
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }

    }
}
