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
using Ermes.Dataclasses;
using Ermes.API;
using Ermes.Properties;

namespace Ermes.MainPages
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        User user;

        public ChatPage()
        {
            InitializeComponent();

            user = MainWindow.User;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
