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
    /// Define workshop owner's
    /// </summary>
    public class Owner : EntityBase
    {
        #region Attributs
        private Int32 id;
        private List<Workshop> workShops;
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
        /// List of all workshops of the owner
        /// </summary>
        [Column("workshops")]
        public List<Workshop> WorkShops
        {
            get
            {
                return workShops;
            }

            set
            {
                workShops = value;
                this.OnPropertyChanged("WorkShops");
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
        /// Default construtor
        /// </summary>
        public Owner()
        {
            this.workShops = new List<Workshop>();
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return base.ToString();
        }

        public new List<Owner> LoadMultipleItems()
        {
            List<Owner> result = new List<Owner>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }


        public new Owner LoadSingleItem()
        {
            Workshop wo = new Workshop();

            Owner result = new Owner();
            result.Humain = new HumainDefinition().LoadSingleItem();
            result.WorkShops = wo.LoadMultipleItems();

            return result;
        }

        #endregion
    }
}
