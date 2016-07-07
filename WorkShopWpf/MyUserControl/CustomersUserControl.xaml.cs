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
    public partial class CustomersUserControl : BaseUserControl
    {
        #region attributs
        private List<Customer> customers;
        #endregion

        #region properties
        public List<Customer> Customers
        {
            get
            {
                return this.customers;
            }

            set
            {
                this.customers = value;
                base.OnPropertyChanged("Customers");
            }
        }

        
        public ObservableCollection<Customer> Obs { get; set; }

        #endregion

        #region constructor
        public CustomersUserControl()
        {
            this.InitializeComponent();
            this.Customers = this.customers;
            Obs = new ObservableCollection<Customer>();
            this.itemsList.ItemsSource = Obs;
            this.DataContext = this;
            
        }
        #endregion

        #region methods
        /// <summary>
        /// Set Customer list to display
        /// </summary>
        public object LoadItem(object items)
        {
            this.Obs.Clear();
            foreach (var item in (List<Customer>)items)
            {
                this.Obs.Add(item);
            }
            return null;
        }

        #endregion
    }
}

