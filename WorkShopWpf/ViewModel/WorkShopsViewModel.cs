using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopWpf.Views;
using WorkShop.Entities;
using WorkShopERP.WorkShop.Utils;
using WorkShopERP.WorkShop.JSON;
using WorkShopERP.WorkShop.AsyncTask;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;
using System.Threading;
using WorkShopERP.WorkShop.API;
using WorkShopERP.WorkShop.DataBase;
using WorkShopERP.WorkShop.Enums;

namespace WorkShopWpf.ViewModel
{
    class WorkShopsViewModel
    {
        #region Attributs
        private HomeNavigation homeNavigation;
        #endregion

        #region properties

        #endregion

        #region Constructor
        public WorkShopsViewModel(HomeNavigation homeNavigation)
        {
            this.homeNavigation = homeNavigation;
            LoadItems();
            LinkItems();
        }
        #endregion

        #region Methods
        /*
        private void LoadItems()
        {
            Utils utils = new Utils();
            WorkShop.Entities.Workshop c = new WorkShop.Entities.Workshop();
            this.homeNavigation.WorkShopsUserControl.WorkShops = utils.ConvertListToObservableCollection<WorkShop.Entities.Workshop>(c.LoadMultipleItems());
            

            // Tests EOM
            /*
            Task.Factory.StartNew(() => 
            {
                this.homeNavigation.WorkShopsUserControl.WorkShops = utils.ConvertListToObservableCollection < WorkShop.Entities.WorkShop > (new WorkShop.Entities.WorkShop().LoadMultipleItems());

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, 
                    new ThreadStart(delegate
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            Random rand = new Random();
                            Task.Delay(TimeSpan.FromSeconds(0.1)).Wait();
                            this.homeNavigation.Background = new SolidColorBrush(Color.FromRgb(
                                Byte.Parse(rand.Next(0, 255).ToString()),
                                Byte.Parse(rand.Next(0, 255).ToString()),
                                Byte.Parse(rand.Next(0, 255).ToString())
                                ));
                        }
                    }));

                
            });
            int a = 0;
            a++;
            */
        /*AsyncFactory fact = new AsyncFactory();
        fact.TestIt(); */
        /*
        WebServiceManager<Address> wsm = new WebServiceManager<Address>(WorkShopERP.WorkShop.Enums.DataConnectionResource.LOCALAPI);
        Address adr = new Address().LoadSingleItem();
        Address apiResult;

        adr = await wsm.Post(adr);

        apiResult = await wsm.Get(adr.Id);


    }
    */

        private void LoadItems()
        {
            Workshop c = new Workshop().LoadSingleItem();
            Utils utils = new Utils();

            MySQLManager<Workshop> db = new MySQLManager<Workshop>(DataConnectionResource.LOCALMYQSL);
            Task.Factory.StartNew(() =>
            {
                List<Workshop> dbData = LoadListItemsFromDb(db).Result;

                if (dbData.Count() > 0)
                {

                    Application appl = System.Windows.Application.Current;
                    appl.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                        new DispatcherOperationCallback(this.homeNavigation.WorkShopsUserControl.LoadItem), dbData);

                }
              
            });
        }

        private Task<List<Workshop>> LoadListItemsFromDb(MySQLManager<Workshop> db)
        {
            Func<List<Workshop>> dbResult = new Func<List<Workshop>>(() =>
            {
                List<Workshop> dbData = db.Get().Result as List<Workshop>;

                return dbData;
            });

            return Task.Run(dbResult);
        }

        private Task<List<Workshop>> LoadListItemsApi(WebServiceManager<Workshop> api)
        {
            Func<List<Workshop>> apiResult = new Func<List<Workshop>>(() =>
            {

                List<Workshop> apiData = api.Get().Result as List<Workshop>;
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
