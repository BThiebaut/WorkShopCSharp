using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Entities
{
    /// <summary>
    /// Command between workshop and client or workshop and provider
    /// </summary>
    public class Command : EntityBase
    {
        #region Attributs
        private Int32 Id;
        private HumainDefinition humain;
        private WorkShop workshop;
        private Double amount;
        private List<Product> products;
        private DateTime dateAdd;
        private DateTime datePaid;



        // TODO : IHM (vues) + class end
        // Doc + region maintenant
        #endregion
        #region Properties
        /// <summary>
        /// Command Id
        /// </summary>
        public int Id1
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
                this.OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Customer / Provider entity
        /// </summary>
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
            }
        }

        /// <summary>
        /// Concerned workshop
        /// </summary>
        public WorkShop Workshop
        {
            get
            {
                return workshop;
            }

            set
            {
                workshop = value;
                this.OnPropertyChanged("Workshop");
            }
        }

        /// <summary>
        /// Amount of the bill
        /// </summary>
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
        public List<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
                this.OnPropertyChanged("Products");
            }
        }

        /// <summary>
        /// Creation date of the command
        /// </summary>
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
        #endregion
        #region Constructors

        #endregion
        /// <summary>
        /// default constructor
        /// </summary>
        public Command()
        {

        }
        #region Methods

        #endregion
    }
}
