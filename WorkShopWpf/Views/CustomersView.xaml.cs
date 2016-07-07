using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkShopWpf.MyUserControl;
using WorkShopWpf.ViewModel;

namespace WorkShopWpf.Views
{
    /// <summary>
    /// Logique d'interaction pour CustomersView.xaml
    /// </summary>
    public sealed partial class CustomersView : Page
    {
        #region attributs
        private CustomersViewModel customersViewModel;
        #endregion

        #region properties
        public CustomersUserControl CustomersUserControl { get; set; }
        public Button AddCustomerButton { get; set; }
        

        #endregion

        #region constructor
        public CustomersView()
        {
            this.InitializeComponent();
            this.CustomersUserControl = this.UCCustomers;
            this.AddCustomerButton = this.btnNewCustomer;
            this.customersViewModel = new CustomersViewModel(this);
        }
        #endregion

        #region methods

        #endregion

        private void btnNavHome_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new HomeNavigation();
        }

        private void UCCustomers_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
