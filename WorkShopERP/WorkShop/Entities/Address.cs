using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Entities
{
    /// <summary>
    /// Define all address fields
    /// </summary>
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



        #endregion
        #region Properties
        /// <summary>
        /// Address Id
        /// </summary>
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
        /// Address lines
        /// </summary>
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

        }

        #region Methods

        #endregion
    }
}
