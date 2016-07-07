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
            */

        }

        private void LinkItems()
        {

        }

        #endregion
    }
}
