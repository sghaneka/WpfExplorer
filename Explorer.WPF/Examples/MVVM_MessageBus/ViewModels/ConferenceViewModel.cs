using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Explorer.WPF.Examples.MVVM_MessageBus.Messages;
using Explorer.WPF.Examples.MVVM_MessageBus.Models;
using GalaSoft.MvvmLight;

namespace Explorer.WPF.Examples.MVVM_MessageBus.ViewModels
{
    public class ConferenceViewModel : ViewModelBase
    {
        private readonly ConferenceService _conferenceService;
        private ObservableCollection<SessionHeaderViewModel> _sessions = new ObservableCollection<SessionHeaderViewModel>();
        private SessionHeaderViewModel _selectedSession = null;

        public ConferenceViewModel()
        {
            _conferenceService = new ConferenceService();

            foreach (var session in _conferenceService.GetSessions())
                _sessions.Add(new SessionHeaderViewModel
                {
                    Id = session.Id,
                    Title = session.Title
                });
        }

        public IEnumerable<SessionHeaderViewModel> Sessions
        {
            get { return _sessions; }
        }

        public SessionHeaderViewModel SelectedSession
        {
            get { return _selectedSession; }

            set
            {
                if (_selectedSession == value)
                    return;

                RaisePropertyChanging(() => this.SelectedSession);
                _selectedSession = value;
                RaisePropertyChanged(() => this.SelectedSession);

                //
                // XAML Patterns (4.5):
                //
                // Send a SessionSelected message to anybody listening.
                //
                MessengerInstance.Send(new SessionSelected
                {
                    SessionId = value.Id
                });
            }
        }
    }
}
