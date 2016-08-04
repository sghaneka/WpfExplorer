using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Explorer.WPF.Examples.PluralSight_WPF_Business_Course.ViewModels
{
    public class ViewModelLocator : ViewModelBase
    {
        private SimpleIoc _container = new SimpleIoc();
        private static ViewModelLocator _instance;
        private static readonly object mutex = new object();

        private ViewModelLocator()
        {
            _container.Register<CrudListViewModel>();
            _container.Register<AddCustomerViewModel>();
        }

        public static ViewModelLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (mutex)
                    {
                        if (_instance == null)
                        {
                            _instance = new ViewModelLocator();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Register<T>(T component)
            where T : class
        {
            _container.Register<T>(() => component);
        }

        public void Unregister<T>()
            where T : class
        {
            _container.Unregister<T>();
        }

        public T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }

        public CrudListViewModel Main
        {
            get { return _container.GetInstance<CrudListViewModel>(); }
        }

        public AddCustomerViewModel AddCustomerViewModel
        {
            get { return _container.GetInstance<AddCustomerViewModel>(); }
        }
    }
}
