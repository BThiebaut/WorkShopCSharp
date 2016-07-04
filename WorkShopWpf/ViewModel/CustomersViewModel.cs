using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Entities;
using WorkShop.Entities.Categories;
using WorkShopWpf.ViewModel;
using WorkShopWpf.Views;

namespace WorkShopWpf.ViewModel
{
    

    public class CustomersViewModel
    {
        #region attributs
        private CustomersView customersView;
        private Product selectedCustomer;
        #endregion

        #region properties

        #endregion

        #region constructor
        public CustomersViewModel(CustomersView customersView)
        {
            this.customersView = customersView;
            LoadItems();
            LinkItems();
        }
        #endregion

        #region Methods

        private void LoadItems()
        {
            List<Customer> customers = new List<Customer>();
            Customer c1 = new Customer();
            c1.FirstName = "Emile";
            c1.LastName = "Louis";
            c1.Wallet = 42;

            Customer c2 = new Customer();
            c2.FirstName = "Jean-Louis";
            c2.LastName = "Aubert";
            c2.Wallet = 50000;

            customers.Add(c1);
            customers.Add(c2);

            this.customersView.CustomersUserControl.Customer = customers;
        }

        private void LinkItems()
        {

        }
        
        #endregion

    }

}