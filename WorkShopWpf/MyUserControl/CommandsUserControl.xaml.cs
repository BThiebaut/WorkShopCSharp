using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkShop.Entities;
using WorkShopERP.WorkShop.Utils;
using WorkShopWpf.MyUserControl.Base;

namespace WorkShopWpf.MyUserControl
{
    /// <summary>
    /// Logique d'interaction pour commandsUserControl.xaml
    /// </summary>
    public partial class CommandsUserControl : BaseUserControl
    {
        #region attributs
        private List<Command> commands;

        #endregion

        #region properties
        public List<Command> Commands
        {
            get
            {
                return this.commands;
            }

            set
            {
                this.commands = value;
                base.OnPropertyChanged("commands");
            }
        }


        public ObservableCollection<Command> Obs { get; set; }
        

        #endregion

        #region constructor
        public CommandsUserControl()
        {
            this.InitializeComponent();
            this.commands = this.Commands;
            Obs = new ObservableCollection<Command>();
            
            this.itemsList.ItemsSource = Obs;
            this.DataContext = this;

        }
        #endregion

        #region methods
        /// <summary>
        /// Set command list to display
        /// </summary>
        public object LoadItem(object items)
        {
            this.Obs.Clear();
            foreach (var item in (List<Command>)items)
            {
                this.Obs.Add(item);
            }
            return null;
        }

        #endregion
    }
}

