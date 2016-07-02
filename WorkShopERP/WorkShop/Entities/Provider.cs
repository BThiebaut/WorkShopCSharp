using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Entities
{
    /// <summary>
    /// Define providers of the workshop
    /// </summary>
    public class Provider : HumainDefinition
    {
        #region Attributs
        private List<Command> commands;

        #endregion
        #region Properties
        /// <summary>
        /// List of all commands of from the workshop to the provider
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
        #endregion
        #region Constructors
        /// <summary>
        /// Customer constructor, initialise the list
        /// </summary>
        public Provider()
        {
            this.commands = new List<Command>();
        }
        #endregion
        #region Methods

        #endregion
    }
}
