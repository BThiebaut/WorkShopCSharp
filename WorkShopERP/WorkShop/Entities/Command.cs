using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopERP.WorkShop.Utils;

namespace WorkShop.Entities
{
    /// <summary>
    /// Command between workshop and client or workshop and provider
    /// </summary>
    [Table("command")]
    public class Command : EntityBase
    {
        #region Attributs
        private Int32 id;
        private HumainDefinition humain;
        private Int32 humainId;
        private Workshop workshop;
        private Int32 workshopId;
        private Double amount;
        private List<Product> products;
        private String productsId;
        private DateTime dateAdd;
        private DateTime datePaid;
        private String productsToString;



        // TODO : IHM (vues) + class end
        // Doc + region maintenant
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
        /// Humain definition for database link
        /// </summary>
        [Column("humain")]
        public HumainDefinition Humain
        {
            get
            {
                return humain;
            }

            set
            {
                humain = value;
                this.OnPropertyChanged("Humain");
                this.HumainId = value.Id;
            }
        }

        /// <summary>
        /// Humain Id
        /// </summary>
        [Column("humainid")]
        public int HumainId
        {
            get
            {
                return humainId;
            }

            set
            {
                humainId = value;
            }
        }

        /// <summary>
        /// Concerned workshop
        /// </summary>
        [Column("workshop")]
        public Workshop Workshop
        {
            get
            {
                return workshop;
            }

            set
            {
                workshop = value;
                this.OnPropertyChanged("Workshop");
                this.WorkshopId = value.Id;
            }
        }

        /// <summary>
        /// Workshop Id
        /// </summary>
        [Column("workshop_id")]
        public int WorkshopId
        {
            get
            {
                return workshopId;
            }

            set
            {
                workshopId = value;
            }
        }

        /// <summary>
        /// Amount of the bill
        /// </summary>
        [Column("amount")]
        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
                this.OnPropertyChanged("Amount");
            }
        }

        /// <summary>
        /// Product list 
        /// </summary>
        [Column("products")]
        public List<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
                foreach (var item in products)
                {
                    if (item.Id != 0)
                    {
                        this.ProductsId = item.Id.ToString();
                    }

                }
                this.OnPropertyChanged("Products");
            }
        }

        /// <summary>
        /// Creation date of the command
        /// </summary>
        [Column("dateadd")]
        public DateTime DateAdd
        {
            get
            {
                return dateAdd;
            }

            set
            {
                dateAdd = value;
                this.OnPropertyChanged("dateAdd");
            }
        }

        /// <summary>
        /// Paid date of the command
        /// </summary>
        [Column("datepaid")]
        public DateTime DatePaid
        {
            get
            {
                return datePaid;
            }

            set
            {
                datePaid = value;
                this.OnPropertyChanged("datePaid");
            }
        }

        /// <summary>
        /// Products Id list for retrievering
        /// </summary>
        [Column("productsidserial")]
        public String ProductsId
        {
            get
            {
                return productsId;
            }

            set
            {
                if (productsId.Contains(";"))
                {
                    productsId += value;
                }else
                {
                    productsId += value + ";";
                }
                
                this.OnPropertyChanged("ProductsId");
            }
        }

        /// <summary>
        /// Products List to string format for list display
        /// </summary>
        [NotMapped]
        public string ProductsToString
        {
            get
            {
                return productsToString;
            }

            set
            {
                productsToString += ", " + value;
            }
        }


        #endregion
        #region Constructors

        #endregion
        /// <summary>
        /// default constructor
        /// </summary>
        public Command()
        {
            this.products = new List<Product>();
            this.productsId = "";
        }
        #region Methods

        public new List<Command> LoadMultipleItems()
        {
            List<Command> result = new List<Command>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }

        public new Command LoadSingleItem()
        {
            Utils utils = new Utils();
            Command result = new Command();
            Customer cu = new Customer();
            Workshop wo = new Workshop();
            Product prod = utils.getRandomCategoriesItem();

            result.Id = Faker.Number.RandomNumber();
            result.Humain = cu.LoadSingleItem().Humain;
            result.Workshop = wo.LoadSingleItem();
            result.Amount = Faker.Number.Double();
            result.Products = prod.LoadMultipleItems();
            result.DateAdd = Faker.Date.Birthday();
            result.datePaid = Faker.Date.Birthday();

            return result;
        }

        #endregion
    }
}
