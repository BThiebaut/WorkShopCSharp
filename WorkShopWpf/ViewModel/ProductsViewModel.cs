using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WorkShop.Entities;
using WorkShop.Entities.Categories;
using WorkShopERP.WorkShop.API;
using WorkShopERP.WorkShop.DataBase;
using WorkShopERP.WorkShop.Enums;
using WorkShopERP.WorkShop.Utils;
using WorkShopWpf.ViewModel;
using WorkShopWpf.Views;

namespace WorkShopWpf.ViewModel
{


    public class ProductsViewModel
    {
        #region attributs
        private ProductsView productsView;
        private Product selectedProducts;
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
            Product c = new Chair().LoadSingleItem();
            Utils utils = new Utils();

            MySQLManager<Product> db = new MySQLManager<Product>(DataConnectionResource.LOCALMYQSL);
            Task.Factory.StartNew(() =>
            {
                List<Product> dbData = LoadListItemsFromDb(db).Result;

                if (dbData.Count() > 0)
                {

                    Application appl = System.Windows.Application.Current;
                    appl.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                        new DispatcherOperationCallback(this.productsView.ProductsUserControl.LoadItem), dbData);

                }
                else
                {

                
                        List<Product> cList = c.LoadMultipleItems();
                        MySQLManager<Product> manager = new MySQLManager<Product>(DataConnectionResource.LOCALMYQSL);
                        manager.Insert(cList);
                        this.LoadItems();
               

                }
            });
        }

        private Task<List<Product>> LoadListItemsFromDb(MySQLManager<Product> db)
        {
            Func<List<Product>> dbResult = new Func<List<Product>>(() =>
            {
                List<Product> dbData = db.Get().Result as List<Product>;

                foreach (var item in dbData)
                {
                    item.SetCategoryClassName();
                }

                return dbData;
            });

            return Task.Run(dbResult);
        }

        private Task<List<Product>> LoadListItemsApi(WebServiceManager<Product> api)
        {
            Func<List<Product>> apiResult = new Func<List<Product>>(() =>
            {

                List<Product> apiData = api.Get().Result as List<Product>;
                return apiData;
            });

            return Task.Run(apiResult);
        }

        private void LinkItems()
        {

        }

        #endregion

    }

}