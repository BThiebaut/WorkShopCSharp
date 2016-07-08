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
        #endregion

        #region Constructor
        public MySQLManager(DataConnectionResource dataConnectionResource)
                : base(EnumString.GetStringValue(dataConnectionResource))
        {
            FullDb fullDB = new FullDb(dataConnectionResource);
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
