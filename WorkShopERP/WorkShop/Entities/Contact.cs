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
    /// Contact class, use only for potential newsletter system
    /// Default HumainDefinitions are only used
    /// </summary>
    public class Contact : HumainDefinition
    {
        #region Attributs
        private Int32 id;
        private HumainDefinition humain;
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
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Contact Default constructor
        /// </summary>
        public Contact()
        {

        }
        #endregion
        #region Methods
        public new List<Contact> LoadMultipleItems()
        {
            List<Contact> result = new List<Contact>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }


        public new Contact LoadSingleItem()
        {
            Address adr = new Address();

            Contact result = new Contact();
            result.Humain = new HumainDefinition().LoadSingleItem();

            return result;
        }
        #endregion
    }
}
