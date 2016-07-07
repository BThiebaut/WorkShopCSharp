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
    /// Define all address fields
    /// </summary>
    [Table("address")]
    public class Address : EntityBase
    {
        #region Attributs
        private Int32 id;
        private String address1;
        private String postCode;
        private String city;
        private String country;
        private String phoneNumber;
        private String email;

        private Utils utils;

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
        /// Address lines
        /// </summary>
        [Column("address1")]
        public string Address1
        {
            get
            {
                return address1;
            }

            set
            {
                address1 = value;
                this.OnPropertyChanged("Address1");
            }
        }

        /// <summary>
        /// Address postCode
        /// </summary>
        [Column("postcode")]
        public string PostCode
        {
            get
            {
                return postCode;
            }

            set
            {
                postCode = value;
                this.OnPropertyChanged("PostCode");
            }
        }

        /// <summary>
        /// Address city
        /// </summary>
        [Column("city")]
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
                this.OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// Address country
        /// </summary>
        [Column("country")]
        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
                this.OnPropertyChanged("Country");
            }
        }

        /// <summary>
        /// Address contact Phone (not required)
        /// </summary>
        [Column("phonenumber")]
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
                this.OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Address email (not required)
        /// </summary>
        [Column("email")]
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                this.OnPropertyChanged("Email");
            }
        }
        #endregion
        #region Constructors

        #endregion
        /// <summary>
        /// Address default constructor
        /// </summary>
        public Address()
        {
            this.utils = new Utils();
        }


        #region Methods


        public new List<Address> LoadMultipleItems()
        {
            List<Address> result = new List<Address>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }

        public new Address LoadSingleItem()
        {
            Address result = new Address();
            result.Id = Faker.Number.RandomNumber();
            result.Address1 = Faker.Address.StreetName();
            result.PostCode = Faker.Address.USZipCode();
            result.City = Faker.Address.USCity();
            result.Country = Faker.Address.USCounty();
            result.PhoneNumber = this.utils.GenFrenchPhoneNumber();
            result.Email = Faker.User.Email();
            return result;
        }

        #endregion
    }
}
