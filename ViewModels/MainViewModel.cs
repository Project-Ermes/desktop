using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ermes.Dataclasses;
using Ermes.Models;
using Ermes.API;

namespace Ermes.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Chats { get; set; }
        public ObservableCollection<ContactModel> Groups { get; set; }

        public MainViewModel(User user)
        {
            Messages = new ObservableCollection<MessageModel>();
            Chats = new ObservableCollection<ContactModel>();
            Groups = new ObservableCollection<ContactModel>();
            /*
            foreach (Message message in user.chats)
            {

            }

            foreach (Group group in user.groups)
            {
                Groups.Add(new ContactModel(

                ));
            }*/
        }
    }
}
