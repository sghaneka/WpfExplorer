using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Explorer.WPF.Examples.Templates
{
    /// <summary>
    /// Interaction logic for DataTemplateExample.xaml
    /// </summary>
    public partial class DataTemplateExample : Window
    {
        private ObservableCollection<Person> _personList = new ObservableCollection<Person>();

        public DataTemplateExample()
        {
            InitializeComponent();
            this.Loaded += (o, e) =>
                               {
                                   Person person1 = new Person()
                                                        {
                                                            FirstName = "John",
                                                            LastName = "Doe"
                                                        };

                                   _personList.Add(person1);

                                   Person person2 = new Person()
                                                        {
                                                            FirstName = "Jane",
                                                            LastName = "Doe"
                                                        };

                                   _personList.Add(person2);

                                   PersonList.ItemsSource = _personList;
                               };
        }
    }
}
