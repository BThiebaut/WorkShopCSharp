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
    /// Logique d'interaction pour CommandFormUserControl.xaml
    /// </summary>
    public partial class CommandFormUserControl : BaseUserControl
    {
        #region attributs
        private Command command;

        #endregion

        #region properties
        public Command Command
        {
            get
            {
                return this.command;
            }

            set
            {
                this.command = value;
                base.OnPropertyChanged("Command");
            }
        }


        public ObservableCollection<Product> ObsP { get; set; }
        public ObservableCollection<Customer> ObsH { get; set; }


        #endregion

        #region constructor
        public CommandFormUserControl()
        {
            this.InitializeComponent();
            this.command = this.Command;
            ObsP = new ObservableCollection<Product>();
            ObsH = new ObservableCollection<Customer>();
            this.itemsListProducts.ItemsSource = ObsP;
            this.itemsListHumain.ItemsSource = ObsH;
            this.DataContext = this;

        }
        #endregion

        #region methods
        /// <summary>
        /// Set Product list to display
        /// </summary>
        public object LoadItemProduct(object items)
        {
            this.ObsP.Clear();
            foreach (var item in (List<Product>)items)
            {
                this.ObsP.Add(item);
            }
            return null;
        }

        /// <summary>
        /// Set Humain list to display
        /// </summary>
        public object LoadItemHumain(object items)
        {
            this.ObsH.Clear();
            foreach (var item in (List<Customer>)items)
            {
                this.ObsH.Add(item);
            }
            return null;
        }

        

        #endregion
    }
}

