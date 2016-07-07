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
    /// Logique d'interaction pour ProductsView.xaml
    /// </summary>
    public sealed partial class ProductsView : Page
    {
        #region attributs
        private ProductsViewModel productsViewModel;
        #endregion

        #region properties
        public ProductsUserControl ProductsUserControl { get; set; }
        public Button AddProductButton { get; set; }


        #endregion

        #region constructor
        public ProductsView()
        {
            this.InitializeComponent();
            this.ProductsUserControl = this.UCProducts;
            this.AddProductButton = this.btnNewProduct;
            this.productsViewModel = new ProductsViewModel(this);
        }
        #endregion

        #region methods

        #endregion

        private void btnNavHome_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new HomeNavigation();
        }
    }
}
