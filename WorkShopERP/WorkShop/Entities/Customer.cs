using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Entities
{
    /// <summary>
    /// Define workshop customers
    /// </summary>
    [Table("customer")]
    public class Customer : EntityBase
    {
        #region Attributs
        private Int32 id;
        private List<Command> commands;
        private Int32 wallet;
        private HumainDefinition humain;
        private Int32 humainId;
        #endregion
        #region Properties

        /// <summary>
        /// Customer Id
        /// </summary>
        [Key]
        [Column("id")]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                this.OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// List of all commands of the customer
        /// </summary>
        [Column("commands")]
        public List<Command> Commands
        {
            get
            {
                return commands;
            }

            set
            {
                commands = value;
                this.OnPropertyChanged("Commands");
            }
        }

        /// <summary>
        /// Buying POWER of the customer
        /// </summary>
        [Column("wallet")]
        public int Wallet
        {
            get
            {
                return wallet;
            }

            set
            {
                wallet = value;
                this.OnPropertyChanged("Wallet");
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

        #endregion
        #region Constructors
        /// <summary>
        /// Customer constructor, initialise the list
        /// </summary>
        public Customer()
        {
            this.commands = new List<Command>();
        }
        #endregion
        #region Methods

        public override string ToString()
        {
            return this.Humain.FirstName + " " + this.Humain.LastName;
        }

        public new List<Customer> LoadMultipleItems()
        {
            List<Customer> result = new List<Customer>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }


        public new Customer LoadSingleItem()
        {
            Address adr = new Address();

            Customer result = new Customer();
            result.Humain = new HumainDefinition().LoadSingleItem();
            result.Wallet = Faker.Number.RandomNumber();

            return result;
        }

        #endregion
    }
}
