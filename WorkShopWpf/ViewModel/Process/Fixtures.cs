using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Entities;
using WorkShop.Entities.Categories;
using WorkShopERP.WorkShop.DataBase;
using WorkShopERP.WorkShop.Enums;

namespace WorkShopWpf.ViewModel.Process
{
    class Fixtures
    {


        #region Attributs
        private Boolean isFix;
        #endregion

        #region properties
        public bool IsFix
        {
            get
            {
                return isFix;
            }

            set
            {
                isFix = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Launch fixtures generation of all datas
        /// </summary>
        public Fixtures()
        {

            

            Task.Factory.StartNew(() =>
            {
                // WorkShop generation
                Workshop wList = new Workshop().LoadSingleItem();
                MySQLManager<Workshop> managerW = new MySQLManager<Workshop>(DataConnectionResource.LOCALMYQSL);
                managerW.Insert(wList);
             

                // Customers generation
                List<Customer> cList = new Customer().LoadMultipleItems();
                MySQLManager<Customer> managerC = new MySQLManager<Customer>(DataConnectionResource.LOCALMYQSL);
                managerC.Insert(cList);

                // Products generation
                List<Product> pList = new Chair().LoadMultipleItems();
                MySQLManager<Product> managerP = new MySQLManager<Product>(DataConnectionResource.LOCALMYQSL);
                managerP.Insert(pList);
                List<Product> dbProd = LoadListProductsFromDb(managerP).Result as List<Product>;

                // Commands generation
                List<Command> coList = new Command().LoadMultipleItems();
                int p = 0;
                int max = dbProd.Count;
                // Add product to Command. Id product required to be set by DB before
                foreach (var item in coList)
                {
                    List<Product> tmp = new List<Product>();
                    for (int i = 0; i < 2; i++)
                    {
                        if (p >= max) p = 0;
                        tmp.Add(dbProd[p++]);
                        
                    }
                    item.Products = tmp;
                }
                MySQLManager<Command> managerCo = new MySQLManager<Command>(DataConnectionResource.LOCALMYQSL);
                managerCo.Insert(coList);


                GC.Collect();

            }).ContinueWith(CallBackFixt);

            
        }

        
        #endregion

        #region Methods
        public void CallBackFixt(Task obj)
        {
            this.IsFix = true;
        }
        /// <summary>
        /// get products list for command setting from DB
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
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

        #endregion

    }
}
