using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.DataLayer;
using Explorer.WPF.Examples.PluralSight_WPF_Business_Course.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Explorer.WPF.Examples.PluralSight_WPF_Business_Course.ViewModels
{
    public class AddCustomerViewModel : ViewModelBase
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    RaisePropertyChanged(() => FirstName);
                }
            }
        }

        private string _lastName;

        public string LastName  
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    RaisePropertyChanged(() => LastName);
                }
            }
        }

        private string _companyName;

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (value != _companyName)
                {
                    _companyName = value;
                    RaisePropertyChanged(() => CompanyName);
                }
            }
        }

        private string _emailAddress;

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                if (value != _emailAddress)
                {
                    _emailAddress = value;
                    RaisePropertyChanged(() => EmailAddress);
                }
            }
        }
        


        public AddCustomerViewModel()
        {
            OkCommand = new RelayCommand(AddCustomer, OkToAddCustomer);
        }

        public RelayCommand OkCommand { get; private set; }

        public bool OkToAddCustomer()
        {
            return !String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName) &&
                   !String.IsNullOrEmpty(CompanyName)
                   && !String.IsNullOrEmpty(EmailAddress);
        }

        public void AddCustomer()
        {
            Messenger.Default.Send(new NotificationMessage("Close"));
            MessengerInstance.Send(new CustomerAdded
            {
                FirstName = FirstName,
                LastName = LastName,
                CompanyName = CompanyName,
                EmailAddress = EmailAddress
            });
            // Close the current View
            // Send a Message of AddCustomer with new customer
            // That's it.
        }


    }
}
