using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Explorer.WPF.Examples.UserControls.Controls
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }

        public static RoutedEvent SearchChangedEvent =
                    EventManager.RegisterRoutedEvent(
                        "SearchChanged",
                        RoutingStrategy.Bubble,
                        typeof(EventHandler<SearchChangedEventArgs>),
                        typeof(SearchControl));
        /// <summary>
        /// The SearchChanged event that can be handled
        /// by the consuming control.
        /// </summary>
        public event EventHandler<SearchChangedEventArgs> SearchChanged
        {
            add
            {
                AddHandler(SearchChangedEvent, value);
            }
            remove
            {
                RemoveHandler(SearchChangedEvent, value);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            OnSearchChanged();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                OnSearchChanged();
        }

        private void OnSearchChanged()
        {
            var args = new SearchChangedEventArgs(txtSearch.Text) {RoutedEvent = SearchChangedEvent};
            RaiseEvent(args);
        }

        public class SearchChangedEventArgs
            : RoutedEventArgs
        {
            private readonly string searchText;
            public SearchChangedEventArgs(
                string searchText)
            {
                this.searchText = searchText;
            }
            public string SearchText
            {
                get
                {
                    return searchText;
                }
            }
        }



    }
}
