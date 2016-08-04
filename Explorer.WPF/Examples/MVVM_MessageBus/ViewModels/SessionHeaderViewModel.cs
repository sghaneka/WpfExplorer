using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Explorer.WPF.Examples.MVVM_MessageBus.Messages;
using GalaSoft.MvvmLight;

namespace Explorer.WPF.Examples.MVVM_MessageBus.ViewModels
{
    public class SessionHeaderViewModel : ViewModelBase
    {
        private string _name;

        public SessionHeaderViewModel()
        {
            //
            // XAML Patterns (4.5):
            //
            // When a SessionTitleChanged message is received, update the title.
            //
            MessengerInstance.Register<SessionTitleChanged>(this, message =>
            {
                if (Id == message.SessionId)
                    Title = message.NewTitle;
            });
        }

        public int Id { get; set; }

        public string Title
        {
            get { return _name; }
            set
            {
                if (value == _name)
                    return;

                RaisePropertyChanging(() => this.Title);
                _name = value;
                RaisePropertyChanged(() => this.Title);
            }
        }
    }
}
