using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Entities.Categories;
using WorkShopERP.WorkShop.Enums;
using WorkShopERP.WorkShop.Interfaces;
using WorkShopERP.WorkShop.Utils;

namespace WorkShop.Entities
{
    public abstract class Product : EntityBase
    {
        #region Attributs
        private Int32 id;
        private String designation;
        private Double price;
        private Double vat;
        private WorkShopERP.WorkShop.Enums.Categories category;
        private String categoryClass;


        #endregion
        #region Properties

        /// <summary>
        /// Entity Id
        /// </summary>
        [Key]
        [Column("id")]
        public Int32 Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Creation name
        /// </summary>
        [Column("designation")]
        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                designation = value;
                this.OnPropertyChanged("Designation");
            }
        }
        /// <summary>
        /// Creation price with comma
        /// </summary>
        [Column("price")]
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
                this.OnPropertyChanged("Price");
            }
        }
        /// <summary>
        /// Applicable VAT in percent with comma
        /// </summary>
        [Column("vat")]
        public double Vat
        {
            get
            {
                return vat;
            }

            set
            {
                vat = value;
                this.OnPropertyChanged("Vat");
            }

        }
        
        /// <summary>
        /// Applicable VAT in percent with comma
        /// </summary>
        [Column("category")]
        public WorkShopERP.WorkShop.Enums.Categories Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
                this.OnPropertyChanged("Category");
            }
        }

        /// <summary>
        /// Display name for Category, 
        /// Filled by Category enumeration
        /// </summary>
        [NotMapped]
        public string CategoryClass
        {
            get
            {
                return categoryClass;
            }

            set
            {
                categoryClass = value;
                this.OnPropertyChanged("CategoryClass");
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// default constructor
        /// </summary>
        public Product()
        {
            this.SetCategoryClassName();
        }
        #endregion
        #region Methods
        public new List<Product> LoadMultipleItems()
        {
            List<Product> result = new List<Product>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }

        public new Product LoadSingleItem()
        {
            Utils utils = new Utils();
            Product result = utils.getRandomCategoriesItem();
            result.Designation = Faker.Lorem.Sentence();
            result.Price = Faker.Number.Double();
            result.Vat = Faker.Number.Double();
            result.Category = (result as CategoryInterface).CategoryId; 

            return result;
        }

        public void SetCategoryClassName()
        {
            if (this.Category != WorkShopERP.WorkShop.Enums.Categories.NULL)
            {
                try
                {
                    this.CategoryClass = EnumString.GetStringValue(this.Category);
                }
                catch (Exception)
                {
                    this.CategoryClass = "ERROR";                    
                }
                
            }
        }

        #endregion
    }
}
