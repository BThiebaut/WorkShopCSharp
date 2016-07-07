using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopERP.WorkShop.Utils.IFaker;

namespace WorkShop.Entities
{
    public class EntityBase : INotifyPropertyChanged, IFakerLoader<EntityBase>
    {

        #region Attributs
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Properties
       
        #endregion
        #region Constructor

        #endregion
        #region Methods
        public List<EntityBase> LoadMultipleItems()
        {
            List<EntityBase> result = new List<EntityBase>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(this.LoadSingleItem());
            }

            return result;
        }

        public EntityBase LoadSingleItem()
        {
            EntityBase result = new EntityBase();
           
            return result;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        

        

        

        
    }
}
