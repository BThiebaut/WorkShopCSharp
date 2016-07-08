using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    

    public class CustomersViewModel
    {
        #region attributs
        private CustomersView customersView;
        private Customer selectedCustomer;
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
            Customer c = new Customer();
            Utils utils = new Utils();
            
            MySQLManager<Customer> db = new MySQLManager<Customer>(DataConnectionResource.LOCALMYQSL);
            Task.Factory.StartNew(() =>
            {
                List<Customer> dbData = LoadListItemsFromDb(db).Result;

                if (dbData.Count() > 0)
                {
           
                    Application appl = System.Windows.Application.Current;
                        appl.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                            new DispatcherOperationCallback(this.customersView.CustomersUserControl.LoadItem), dbData);

                }
                else
                {
                
                
                        List<Customer> cList = c.LoadMultipleItems();
                        MySQLManager<Customer> managerCustomer = new MySQLManager<Customer>(DataConnectionResource.LOCALMYQSL);
                        managerCustomer.Insert(cList);
                        this.LoadItems();
                

                }
            });

        }

        

        public void UpdateList(List<Customer> newList)
        {
            
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                this.customersView.CustomersUserControl.Customers = newList;
            }));
        }


        private Task<List<Customer>> LoadListItemsFromDb(MySQLManager<Customer> db)
        {
            Func<List<Customer>> dbResult = new Func<List<Customer>>( () =>
            {

                List<Customer> dbData = db.Get().Result as List<Customer>;

                MySQLManager<HumainDefinition> dbH = new MySQLManager<HumainDefinition>(DataConnectionResource.LOCALMYQSL);
                MySQLManager<Address> dbA = new MySQLManager<Address>(DataConnectionResource.LOCALMYQSL);

                foreach (var item in dbData)
                {
                    item.Humain = dbH.Get(item.HumainId).Result;
                    item.Humain.Address = dbA.Get(item.Humain.AddressId).Result;
                }
                return dbData;

            });

            return Task.Run(dbResult);
        }

        private Task<List<Customer>> LoadListItemsApi(WebServiceManager<Customer> api)
        {
            Func<List<Customer>> apiResult = new Func<List<Customer>>(() =>
            {
                
                List<Customer> apiData = api.Get().Result as List<Customer>;
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