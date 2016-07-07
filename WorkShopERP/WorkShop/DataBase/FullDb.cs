using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Entities;
using WorkShopERP.WorkShop.Enums;

namespace WorkShopERP.WorkShop.DataBase
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    class FullDb : DbContext
    {
        /*
        #region Singleton
        private static volatile FullDb instance;
        private static object syncRoot = new Object();

        private FullDb() { }

        public static FullDb Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new FullDb();
                    }
                }

                return instance;
            }
        }
        #endregion
        */
        #region Properties
        public DbSet<Address> DbSetAddress { get; set; }
        public DbSet<Command> DbSetCommand { get; set; }
        public DbSet<Contact> DbSetContact { get; set; }
        public DbSet<Product> DbSetProduct { get; set; }
        public DbSet<Customer> DbSetCustomer{ get; set; }
        public DbSet<HumainDefinition> DbSetHumainDefinition { get; set; }
        public DbSet<Owner> DbSetOwner { get; set; }
        public DbSet<Provider> DbSetProvider { get; set; }
        public DbSet<Workshop> DbSetWorkShop { get; set; }
        #endregion

        #region Constructor
        public FullDb (DataConnectionResource dataConnectionResource)
                : base(EnumString.GetStringValue(dataConnectionResource))
        {
             
            this.Database.CreateIfNotExists();
        }
        #endregion

       


    }
}
