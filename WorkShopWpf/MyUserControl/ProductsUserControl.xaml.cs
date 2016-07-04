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
using WorkShop.Entities;
using WorkShopWpf.MyUserControl.Base;

namespace WorkShopWpf.MyUserControl
{
    /// <summary>
    /// Logique d'interaction pour CustomersUserControl.xaml
    /// </summary>
    public partial class ProductsUserControl : BaseUserControl
    {
        #region attributs
        private Product product;
        #endregion

        #region properties
        public Product Product
        {
            get
            {
                return this.product;
            }

            set
            {
                this.product = value;
                base.OnPropertyChanged("Product");
            }
        }
        #endregion

        #region constructor
        public ProductsUserControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region methods

        #endregion
    }
}

