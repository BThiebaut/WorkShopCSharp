using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Entities
{
    /// <summary>
    /// Define all default content for humain entity
    /// </summary>
    public abstract class HumainDefinition : EntityBase
    {
        #region Attributs

        private Int32 id;
        private String firstName;
        private String lastName;
        private Address address;



        #endregion
        #region Properties
        /// <summary>
        /// Id of an humain representation
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
        /// FirstName of the representation
        /// </summary>
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
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Default constructor
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
        #endregion
    }
}
