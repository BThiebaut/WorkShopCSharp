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


    public class ProductsViewModel
    {
        #region attributs
        private ProductsView productsView;
        private Product selectedCustomer;
        #endregion

        #region properties

        #endregion

        #region constructor
        public ProductsViewModel(ProductsView productsView)
        {
            this.productsView = productsView;
            LoadItems();
            LinkItems();
        }
        #endregion

        #region Methods

        private void LoadItems()
        {
            Product chair = new Chair();
            chair.Designation = "ma Chaise";
            chair.Price = 42.01;
            chair.Vat = 5.0;

            this.productsView.ProductsUserControl.Product = chair;
        }

        private void LinkItems()
        {

        }

        #endregion

    }

}