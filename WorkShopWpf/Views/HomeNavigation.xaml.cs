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
    /// Logique d'interaction pour HomeNavigation.xaml
    /// </summary>
    public partial class HomeNavigation : Page
    {
        #region attributs
        private WorkShopsViewModel workShopsViewModel;
        #endregion

        #region properties
        public WorkShopsUserControl WorkShopsUserControl { get; set; }
        #endregion
        #region Constructor
        public HomeNavigation()
        {
            this.InitializeComponent();
            this.WorkShopsUserControl = this.UCWorkShops;
            this.workShopsViewModel = new WorkShopsViewModel(this);
        }
        #endregion
        #region Methods

        private void navProducts_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new ProductsView();
        }

        private void navCustomers_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new CustomersView();
        }
        #endregion
    }
}
