using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Entities
{
    /// <summary>
    /// WorkShop definition
    /// </summary>
    public class WorkShop
    {
        #region Attributs

        private Int32 id;
        private String name;
        private Address address;
        private Int32 turnover;

        #endregion
        #region Properties
        /// <summary>
        /// Id of the workshop
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
            }
        }

        /// <summary>
        /// Physical address of the workshop
        /// </summary>
        internal Address Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
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
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Workshop default constructor
        /// </summary>
        public WorkShop()
        {

        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return this.Name + " " + this.Address + " " + this.Turnover;
        }
        #endregion
    }
}
