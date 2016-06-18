using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Entities
{
    public abstract class Product
    {
        #region Attributs
        private Int32 id;
        private String designation;
        private Double price;
        private Double vat;


        #endregion
        #region Properties
        /// <summary>
        /// Creation Id
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
        /// Creation name
        /// </summary>
        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                designation = value;
            }
        }
        /// <summary>
        /// Creation price with comma
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        /// <summary>
        /// Applicable VAT in percent with comma
        /// </summary>
        public double Vat
        {
            get
            {
                return vat;
            }

            set
            {
                vat = value;
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// default constructor
        /// </summary>
        public Product()
        {

        }
        #endregion
        #region Methods

        #endregion
    }
}
