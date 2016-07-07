using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Entities;
using WorkShopERP.WorkShop.Enums;

namespace WorkShopERP.WorkShop.DataBase
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLManager<TEntity> : DbContext where TEntity : class
    {
        #region Properties
        public DbSet<TEntity> DbSetT { get; set; }
        public String connexionSting { get; set; }
        #endregion

        #region Constructor
        public MySQLManager(DataConnectionResource dataConnectionResource)
                : base(EnumString.GetStringValue(dataConnectionResource))
        {
            FullDb fullDB = new FullDb(dataConnectionResource);
            this.connexionSting = EnumString.GetStringValue(dataConnectionResource);
        }
        #endregion

        #region Methods
        public async Task<TEntity> Insert(TEntity item)
        {
            this.DbSetT.Add(item);
            await this.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                this.DbSetT.Add(item);
            }
            await this.SaveChangesAsync();
            return items;
        }
        public async Task<TEntity> Update(TEntity item)
        {
            this.Entry<TEntity>(item);
            await this.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                this.Entry<TEntity>(item);
            }
            await this.SaveChangesAsync();
            return items;
        }
        public async Task<TEntity> Get(Int32 id)
        {
            return await this.DbSetT.FindAsync(id) as TEntity;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            DbSet<TEntity> temp = default(DbSet<TEntity>);
            List<TEntity> result = new List<TEntity>();

            await Task.Factory.StartNew(() =>
            {
                temp = base.Set<TEntity>();
            });
            result.AddRange(temp);

            return result;
        }
        /// <summary>
        /// Get Full entity with Join 
        /// </summary>
        /// <param name="obj"> Aim class </param>
        /// <param name="where"> Where clause </param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetWithJoin(TEntity item, String where)
        {
            DbSet<TEntity> temp = default(DbSet<TEntity>);
            List<TEntity> result = new List<TEntity>();
            Int32 indexes = 0;
            Int32 lastIndex;
            Boolean hasRecursive = false;
            String table = "";

            var propTable = item.GetType().ToString().Split('.');
            table = propTable[propTable.Count() - 1].ToLower();

            String query = "SELECT * FROM " + table + " AS t" + indexes;
            String joins = "";
            

            var properties = item.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (prop.PropertyType.BaseType.Name == "EntityBase")
                {
                    lastIndex = indexes;
                    indexes++;
                    hasRecursive = true;
                    table = prop.PropertyType.Name.ToLower();

                    joins += "LEFT JOIN " + table + " as t" + indexes + " ON (t" + lastIndex + ".id = t." + indexes + ".id ) ";
                }

            }

            await Task.Factory.StartNew(() =>
            {
                MySqlConnection sqlConnection1 = new MySqlConnection(this.connexionSting);
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;

                cmd.CommandText = query + " " + joins + " " + where;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                

                sqlConnection1.Close();;
            });
            result.AddRange(temp);

            return result;
        }

        private void SetJoinsRef<T>(ref String joins, List<T> properties) where T : EntityBase
        {
           
        }

        public async Task<Int32> Delete(TEntity item)
        {
            await Task.Factory.StartNew(() =>
            {
                this.DbSetT.Attach(item);
                this.DbSetT.Remove(item);
            });
            return await this.SaveChangesAsync();
        }
        public async Task<Int32> Delete(IEnumerable<TEntity> items)
        {
            await Task.Factory.StartNew(() =>
            {
                this.DbSetT.Attach((items as List<TEntity>)[0]);
                this.DbSetT.RemoveRange(items);
                
            });
            return await this.SaveChangesAsync();
        }

        #endregion
    }
}
