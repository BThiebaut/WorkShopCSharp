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
        private ObservableCollection<Workshop> workShops;
        private Address address;
        #endregion

        #region properties
        public ObservableCollection<Workshop> WorkShops
        {
            get
            {
                return this.workShops;
            }

            set
            {
                this.workShops = value;
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
        
        #endregion

        #region constructor
        public WorkShopsUserControl()
        {
            this.InitializeComponent();


            Utils utils = new Utils();
            Workshop c = new Workshop();

            this.WorkShops = utils.ConvertListToObservableCollection<Workshop>(c.LoadMultipleItems());
            this.itemsList.ItemsSource = this.WorkShops;
            this.DataContext = this;
        }
        #endregion

        #region methods

        #endregion
    }
}
