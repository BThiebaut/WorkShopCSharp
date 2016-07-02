using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Entities
{
    /// <summary>
    /// Define workshop customers
    /// </summary>
    public class Customer : HumainDefinition
    {
        #region Attributs
        private List<Command> commands;
        private Int32 wallet;
        #endregion
        #region Properties
        /// <summary>
        /// List of all commands of the customer
        /// </summary>
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
        /// Buying POWER of the customer
        /// </summary>
        public int Wallet
        {
            get
            {
                return wallet;
            }

            set
            {
                wallet = value;
                this.OnPropertyChanged("Wallet");
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Customer constructor, initialise the list
        /// </summary>
        public Customer()
        {
            this.commands = new List<Command>();
        }
        #endregion
        #region Methods

        #endregion
    }
}
