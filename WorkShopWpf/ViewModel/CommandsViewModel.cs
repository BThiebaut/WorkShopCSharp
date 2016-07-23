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


    public class CommandsViewModel
    {
        #region attributs
        private CommandsView CommandsView;
        private Command selectedCommand;
        #endregion

        #region properties

        #endregion

        #region constructor
        public CommandsViewModel(CommandsView CommandsView)
        {
            this.CommandsView = CommandsView;
            LoadItems();
            LinkItems();
        }
        #endregion

        #region Methods

        private void LoadItems()
        {
            Command c = new Command();
            Utils utils = new Utils();

            MySQLManager<Command> db = new MySQLManager<Command>(DataConnectionResource.LOCALMYQSL);
            Task.Factory.StartNew(() =>
            {
                List<Command> dbData = LoadListItemsFromDb(db).Result;

                if (dbData.Count() > 0)
                {

                    Application appl = System.Windows.Application.Current;
                    appl.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                        new DispatcherOperationCallback(this.CommandsView.CommandsUserControl.LoadItem), dbData);

                }

            });

        }



        public void UpdateList(List<Command> newList)
        {

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                this.CommandsView.CommandsUserControl.Commands = newList;
            }));
        }


        private Task<List<Command>> LoadListItemsFromDb(MySQLManager<Command> db)
        {
            Func<List<Command>> dbResult = new Func<List<Command>>(() =>
            {

                List<Command> dbData = db.Get().Result as List<Command>;

                MySQLManager<HumainDefinition> dbH = new MySQLManager<HumainDefinition>(DataConnectionResource.LOCALMYQSL);
                MySQLManager<Address> dbA = new MySQLManager<Address>(DataConnectionResource.LOCALMYQSL);

                foreach (var item in dbData)
                {
                    item.Humain = dbH.Get(item.HumainId).Result;
                    item.Humain.Address = dbA.Get(item.Humain.AddressId).Result;
                    if (item.ProductsId != "")
                    {
                        String banana = item.ProductsId;
                        String[] ids = banana.Split(';');
                        MySQLManager<Product> dbP = new MySQLManager<Product>(DataConnectionResource.LOCALMYQSL);
                        foreach (var id in ids)
                        {
                            if (id != "")
                            {
                                Product p = dbP.Get(Int32.Parse(id)).Result;
                                p.SetCategoryClassName();
                                item.Products.Add(p);
                                item.ProductsToString = p.Designation;
                            }
                            
                        }
                    }
                    
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

        public void ValidateCommand(object sender, RoutedEventArgs e)
        {
            var commands = this.CommandsView.CommandsUserControl.itemsList.SelectedItems;
            foreach (var item in commands)
            {
                Command c = item as Command;
                if (c.DatePaid == null || c.DatePaid == new DateTime())
                {
                    c.DatePaid = DateTime.Now;
                    Task.Factory.StartNew(() =>
                    {
                        MySQLManager<Command> manager = new MySQLManager<Command>(DataConnectionResource.LOCALMYQSL);
                        manager.Update(c);
                    });
                }
                
            }
        }

        #endregion

    }

}