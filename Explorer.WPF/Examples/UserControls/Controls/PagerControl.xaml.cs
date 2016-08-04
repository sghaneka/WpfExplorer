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
    /// Interaction logic for PagerControl.xaml
    /// </summary>
    public partial class PagerControl : UserControl
    {
        public PagerControl()
        {
            InitializeComponent();
        }

        public int Current
        {
            get { return (int) GetValue(CurrentProperty); }
            set
            {
                if (value <= Total
                    && value >= 0)
                {
                    SetValue(CurrentProperty, value);
                }
            }
        }

        public static readonly DependencyProperty CurrentProperty =
            DependencyProperty.Register("Current",
                                        typeof (int),
                                        typeof (PagerControl),
                                        new PropertyMetadata(0));

        public int Total
        {
            get { return (int) GetValue(TotalProperty); }
            set
            {
                if (value >= Current
                    && value >= 0)
                {
                    SetValue(TotalProperty, value);
                }
            }

        }

        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total",
                                        typeof (int),
                                        typeof (PagerControl),
                                        new PropertyMetadata(0));
    }
}
