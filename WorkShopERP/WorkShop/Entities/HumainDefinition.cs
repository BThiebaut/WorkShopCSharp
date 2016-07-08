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
    /// Define all default content for humain entity
    /// </summary>
    [Table("humaindefinitions")]
    public class HumainDefinition : EntityBase
    {
        #region Attributs

        private Int32 id;
        private String firstName;
        private String lastName;
        private Address address;
        private Int32 addressId;



        #endregion
        #region Properties
        /// <summary>
        /// Id of an humain representation
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
        /// FirstName of the representation
        /// </summary>
        [Column("firstname")]
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Lastname of the representation
        /// </summary>
        [Column("lastname")]
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Address of the representation
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
        #endregion
        #region Constructors
        /// <summary>
        /// Default constructor (unusable)
        /// </summary>
        public HumainDefinition()
        {

        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.Address;
        }

        public new List<HumainDefinition> LoadMultipleItems()
        {
            List<HumainDefinition> result = new List<HumainDefinition>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }


        public new HumainDefinition LoadSingleItem()
        {
            Address adr = new Address();

            HumainDefinition result = new HumainDefinition();
            result.FirstName = Faker.Name.FirstName();
            result.LastName = Faker.Name.LastName();
            result.Address = adr.LoadSingleItem();

            return result;
        }

        #endregion
    }
}
