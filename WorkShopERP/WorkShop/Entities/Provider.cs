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
    /// Define providers of the workshop
    /// </summary>
    public class Provider : EntityBase
    {
        #region Attributs
        private Int32 id;
        private List<Command> commands;
        private List<Workshop> workshops;
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
        /// List of all commands of from the workshop to the provider
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

        /// <summary>
        /// Provider workshops
        /// </summary>
        [Column("workshop")]
        public List<Workshop> Workshops
        {
            get
            {
                return workshops;
            }

            set
            {
                workshops = value;
                this.OnPropertyChanged("Workshops");
            }
        }

        #endregion
        #region Constructors
        /// <summary>
        /// Customer constructor, initialise the list
        /// </summary>
        public Provider()
        {
            this.commands = new List<Command>();
            this.Workshops = new List<Workshop>();
        }
        #endregion
        #region Methods
        public new List<Provider> LoadMultipleItems()
        {
            List<Provider> result = new List<Provider>();

            for (int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }

            return result;
        }


        public new Provider LoadSingleItem()
        {
            Command com = new Command();
            Workshop wo = new Workshop();

            Provider result = new Provider();
            result.Humain = new HumainDefinition().LoadSingleItem();
            result.Commands = com.LoadMultipleItems();

            return result;
        }
        #endregion
    }
}
