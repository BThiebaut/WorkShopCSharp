using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopWpf.Views;
using WorkShop.Entities;
using WorkShopERP.WorkShop.Utils;
using System.Windows;
using System.Windows.Threading;
using WorkShopERP.WorkShop.API;
using WorkShopERP.WorkShop.DataBase;
using WorkShopERP.WorkShop.Enums;
using WorkShopERP.WorkShop.Logger;

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
            Logger logger = new Logger();
            logger.Log("Application started");
        }
        #endregion

        #region Methods
       
        /// <summary>
        /// Load items if db contains it
        /// </summary>
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

        /// <summary>
        /// Loard item from Db
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private Task<List<Workshop>> LoadListItemsFromDb(MySQLManager<Workshop> db)
        {
            Func<List<Workshop>> dbResult = new Func<List<Workshop>>(() =>
            {
                List<Workshop> dbData = db.Get().Result as List<Workshop>;

                return dbData;
            });

            return Task.Run(dbResult);
        }

        /// <summary>
        /// Load item from api
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check if fixture exist
        /// </summary>
        /// <returns></returns>
        public Boolean checkIsGenerated()
        {
            MySQLManager<Workshop> db = new MySQLManager<Workshop>(DataConnectionResource.LOCALMYQSL);
            List<Workshop> dbData = LoadListItemsFromDb(db).Result;

            if (dbData.Count() > 0)
            {
                return true;
            }
            Logger logger = new Logger();
            logger.Log("Database generated");
            return false;
        }

        #endregion
    }
}
