using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopERP.WorkShop.Interfaces;

namespace WorkShop.Entities.Categories
{
    public class Wood : Sculpture, CategoryInterface
    {
        #region Attributs
        private WorkShopERP.WorkShop.Enums.Categories categoryId;
        #endregion
        #region Properties
        /// <summary>
        /// Enum category Id
        /// </summary>
        public WorkShopERP.WorkShop.Enums.Categories CategoryId
        {
            get
            {
                return categoryId;
            }

            set
            {
                categoryId = value;
                this.OnPropertyChanged("Category");
            }
        }
        #endregion
        #region Constructors
        public Wood()
        {
            this.CategoryId = WorkShopERP.WorkShop.Enums.Categories.WOOD;
        }
        #endregion
        #region Methods

        #endregion
    }
}
