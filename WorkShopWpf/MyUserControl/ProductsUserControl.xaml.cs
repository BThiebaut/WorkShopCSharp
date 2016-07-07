using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WorkShop.Entities;
using WorkShopERP.WorkShop.Utils;
using WorkShopWpf.MyUserControl.Base;

namespace WorkShopWpf.MyUserControl
{
    /// <summary>
    /// Logique d'interaction pour CustomersUserControl.xaml
    /// </summary>
    public partial class ProductsUserControl : BaseUserControl
    {
        #region attributs
        private List<Product> products;
        #endregion

        #region properties
        public List<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
                base.OnPropertyChanged("Product");
            }
        }

        public ObservableCollection<Product> Obs { get; set; }
        #endregion

        #region constructor
        public ProductsUserControl()
        {
            this.InitializeComponent();
            this.Products = this.products;
            Obs = new ObservableCollection<Product>();
            this.itemsList.ItemsSource = Obs;
            this.DataContext = this;
        }
        #endregion

        #region methods
        /// <summary>
        /// Set Producs list to display
        /// </summary>
        public object LoadItem(object items)
        {
            this.Obs.Clear();
            foreach (var item in (List<Product>)items)
            {
                this.Obs.Add(item);
            }
            return null;
        }
            #endregion
     }
}

