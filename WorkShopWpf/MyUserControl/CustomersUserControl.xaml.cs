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
    public partial class CustomersUserControl : BaseUserControl
    {
        #region attributs
        private List<Customer> customers;
        #endregion

        #region properties
        public List<Customer> Customer
        {
            get
            {
                return this.customers;
            }

            set
            {
                this.customers = value;
                base.OnPropertyChanged("Customer");
            }
        }
        #endregion

        #region constructor
        public CustomersUserControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region methods

        #endregion
    }
}

