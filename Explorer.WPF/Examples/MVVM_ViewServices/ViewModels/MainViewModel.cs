using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Explorer.WPF.Examples.MVVM_ViewServices.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Explorer.WPF.Examples.MVVM_ViewServices.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private int _count;

        public int Count
        {
            get { return _count; }
            set
            {
                if (value == _count)
                    return;

                RaisePropertyChanging(() => this.Count);
                _count = value;
                RaisePropertyChanged(() => this.Count);
            }
        }

        public ICommand Increment
        {
            get
            {
                return new RelayCommand(delegate
                {
                    //
                    // XAML Patterns (4.9):
                    //
                    // Get the dialog service from the IoC container through
                    // the view model locator.
                    //
                    var dialogService = ViewModelLocator.Current.GetInstance<IDialogService>();

                    if (dialogService.Prompt("Increment?"))
                    {
                        Count++;
                    }
                });
            }
        }
    }
}
