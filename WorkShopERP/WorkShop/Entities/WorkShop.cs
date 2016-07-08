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
    /// WorkShop definition
    /// </summary>
    public class Workshop : EntityBase
    {
        #region Attributs
        private Int32 id;
        private String name;
        private Address address;
        private Int32 turnover;
        private Int32 addressId;

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
        /// Name of the workshop
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Address of the workshop
        /// </summary>
        [Column("address")]
        public Address Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
                this.OnPropertyChanged("Address");
                this.AddressId = value.Id;
            }
        }

        /// <summary>
        /// Address Id
        /// </summary>
        [Column("addressid")]
        public int AddressId
        {
            get
            {
                return addressId;
            }

            set
            {
                addressId = value;
                this.OnPropertyChanged("AddressId");
            }
        }

        /// <summary>
        /// actual Turnover of the workshop
        /// </summary>
        public int Turnover
        {
            get
            {
                return turnover;
            }

            set
            {
                turnover = value;
                this.OnPropertyChanged("Turnover");
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Workshop default constructor
        /// </summary>
        public Workshop()
        {

        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return this.Name + " " + this.Address + " " + this.Turnover;
        }

        public new List<Workshop> LoadMultipleItems()
        {
            List<Workshop> result = new List<Workshop>();

            for (int i = 0; i < Faker.Number.RandomNumber(1, 5); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }

        public new Workshop LoadSingleItem()
        {
            Address adr = new Address();
            Workshop result = new Workshop();
            result.Name = Faker.Name.FullName();
            result.Address = adr.LoadSingleItem();
            result.Turnover = Faker.Number.RandomNumber();

            return result;
        }

        #endregion
    }
}
