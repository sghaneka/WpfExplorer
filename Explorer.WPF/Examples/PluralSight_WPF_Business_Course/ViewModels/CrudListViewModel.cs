using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Explorer.DataLayer.AdventureWorks;
using Explorer.WPF.Examples.PluralSight_WPF_Business_Course.Messages;
using Explorer.WPF.Examples.PluralSight_WPF_Business_Course.Models;
using Explorer.WPF.Examples.PluralSight_WPF_Business_Course.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Explorer.WPF.Examples.PluralSight_WPF_Business_Course.ViewModels
{
    public class CrudListViewModel : ViewModelBase
    {
        private readonly CrudListDataService _crudListDataService;
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;

        public CrudListViewModel()
        {
            _crudListDataService = new CrudListDataService();
            _customers = new ObservableCollection<Customer>(_crudListDataService.GetCustomers());
            AddCustomerCommand = new RelayCommand(() =>
            {
                //var dialogService = ViewModelLocator.Instance.GetInstance<IDialogService>();
                Messenger.Default.Send(new NotificationMessage("AddCustomer"));

            }, () => true);

            MessengerInstance.Register<CustomerAdded>(this, message => _customers.Add(new Customer
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                CompanyName = message.CompanyName,
                EmailAddress = message.EmailAddress
            }));

        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                if (value != _customers)
                {
                    _customers = value;
                    RaisePropertyChanged(() => this.Customers);
                }
            }
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (value != _selectedCustomer)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged(() => this.SelectedCustomer);
                }
            }
        }

        public RelayCommand AddCustomerCommand { get; private set; }
    }
}
