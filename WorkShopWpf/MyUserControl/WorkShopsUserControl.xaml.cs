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
    /// Logique d'interaction pour WorkShopsUserControl.xaml
    /// </summary>
    public partial class WorkShopsUserControl : BaseUserControl
    {
        #region attributs
        private ObservableCollection<Workshop> workshops;
        private Address address;
        private List<Owner> owners;
        #endregion

        #region properties
        public ObservableCollection<Workshop> Workshops
        {
            get
            {
                return this.workshops;
            }

            set
            {
                this.workshops = value;
                base.OnPropertyChanged("WorkShops");
            }
        }

        public Address Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
                base.OnPropertyChanged("Address");
            }
        }

        public List<Owner> Owners
        {
            get
            {
                return this.owners;
            }

            set
            {
                this.owners = value;
                base.OnPropertyChanged("Owners");
            }
        }
        public ObservableCollection<Workshop> Obs { get; set; }
        #endregion

        #region constructor
        public WorkShopsUserControl()
        {
            this.InitializeComponent();
            this.Workshops = this.workshops;
            Obs = new ObservableCollection<Workshop>();
            this.itemsList.ItemsSource = Obs;
            this.DataContext = this;
        }
        #endregion

        #region methods
        /// <summary>
        /// Set Workshops list to display
        /// </summary>
        public object LoadItem(object items)
        {
            this.Obs.Clear();
            foreach (var item in (List<Workshop>)items)
            {
                this.Obs.Add(item);
            }
            return null;
        }
        #endregion
    }
}
