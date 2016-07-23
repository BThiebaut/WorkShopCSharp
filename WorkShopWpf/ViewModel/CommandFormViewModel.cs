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


    public class CommandFormViewModel
    {
        #region attributs
        private CommandFormView CommandFormView;
        
        #endregion

        #region properties

        #endregion

        #region constructor
        public CommandFormViewModel(CommandFormView CommandFormView)
        {
            this.CommandFormView = CommandFormView;
            LoadItems();
            LinkItems();
        }
        #endregion

        #region Methods

        private void LoadItems()
        {
            Command c = new Command();
            Utils utils = new Utils();

            MySQLManager<Product> dbP = new MySQLManager<Product>(DataConnectionResource.LOCALMYQSL);
            Task.Factory.StartNew(() =>
            {
                List<Product> dbData = LoadListProductsFromDb(dbP).Result;

                if (dbData.Count() > 0)
                {

                    Application appl = System.Windows.Application.Current;
                    appl.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                        new DispatcherOperationCallback(this.CommandFormView.CommandFormUserControl.LoadItemProduct), dbData);

                }

            });

            MySQLManager<Customer> dbH = new MySQLManager<Customer>(DataConnectionResource.LOCALMYQSL);
            Task.Factory.StartNew(() =>
            {
                List<Customer> dbData = LoadListHumainsFromDb(dbH).Result;

                if (dbData.Count() > 0)
                {

                    Application appl = System.Windows.Application.Current;
                    appl.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                        new DispatcherOperationCallback(this.CommandFormView.CommandFormUserControl.LoadItemHumain), dbData);

                }

            });

        }
        
        private Task<List<Product>> LoadListProductsFromDb(MySQLManager<Product> db)
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

        private Task<List<Customer>> LoadListHumainsFromDb(MySQLManager<Customer> db)
        {
            Func<List<Customer>> dbResult = new Func<List<Customer>>(() =>
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

        private Task<List<Command>> LoadListItemsApi(WebServiceManager<Command> api)
        {
            Func<List<Command>> apiResult = new Func<List<Command>>(() =>
            {
                List<Command> apiData = api.Get().Result as List<Command>;
                return apiData;
            });

            return Task.Run(apiResult);
        }

        private void LinkItems()
        {

        }

        public bool btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customer selectedHumain =  this.CommandFormView.CommandFormUserControl.itemsListHumain.SelectedItem as Customer;
            var selectedProducts = this.CommandFormView.CommandFormUserControl.itemsListProducts.SelectedItems;
            MySQLManager<Workshop> dbW = new MySQLManager<Workshop>(DataConnectionResource.LOCALMYQSL);
            Workshop workshop = dbW.Get(1).Result;
            

            MySQLManager<HumainDefinition> dbH = new MySQLManager<HumainDefinition>(DataConnectionResource.LOCALMYQSL);
            HumainDefinition humain = dbH.Get(selectedHumain.HumainId).Result;

            Command command = new Command();
            command.Humain = humain;

            Double totalPrice = 0;
            String serialId = "";
            MySQLManager<Product> dbP = new MySQLManager<Product>(DataConnectionResource.LOCALMYQSL);
            foreach (var item in selectedProducts)
            {
                Product prod = item as Product;
                Product vProd = dbP.Get(prod.Id).Result;
                command.Products.Add(vProd);
                totalPrice += vProd.Price;
                serialId += ";" + vProd.Id;
                // TODO : TROUVER POURQUOI CE TRUC MARCHE PAS !!!!!
                
            }
            serialId.Replace(",", "");
            command.ProductsToString = serialId;
            command.Amount = totalPrice;
            command.DateAdd = DateTime.Now;
            command.Workshop = workshop;

            if (selectedHumain.Wallet >= totalPrice)
            {
                Task.Factory.StartNew(() =>
                {
                    MySQLManager<Command> manager = new MySQLManager<Command>(DataConnectionResource.LOCALMYQSL);
                    manager.Insert(command);
                });
                return true;
            }else
            {
                return false;
            }
        }

        #endregion

    }

}