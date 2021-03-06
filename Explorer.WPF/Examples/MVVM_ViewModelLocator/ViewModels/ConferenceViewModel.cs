﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Explorer.WPF.Examples.MVVM_ViewModelLocator.Messages;
using Explorer.WPF.Examples.MVVM_ViewModelLocator.Models;
using GalaSoft.MvvmLight;

namespace Explorer.WPF.Examples.MVVM_ViewModelLocator.ViewModels
{
    public class ConferenceViewModel : ViewModelBase
    {
        private readonly IConferenceService _conferenceService;
        private ObservableCollection<SessionHeaderViewModel> _sessions = new ObservableCollection<SessionHeaderViewModel>();
        private SessionHeaderViewModel _selectedSession = null;

        public ConferenceViewModel(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;

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

                MessengerInstance.Send(new SessionSelected
                {
                    SessionId = value.Id
                });
            }
        }
    }
}
