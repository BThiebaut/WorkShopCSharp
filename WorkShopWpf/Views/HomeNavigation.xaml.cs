using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using WorkShopWpf.MyUserControl;
using WorkShopWpf.ViewModel;
using WorkShopWpf.ViewModel.Process;

namespace WorkShopWpf.Views
{
    /// <summary>
    /// Logique d'interaction pour HomeNavigation.xaml
    /// </summary>
    public partial class HomeNavigation : Page
    {
        #region attributs
        private WorkShopsViewModel workShopsViewModel;
        #endregion

        #region properties
        public WorkShopsUserControl WorkShopsUserControl { get; set; }
        #endregion
        #region Constructor
        public HomeNavigation()
        {
            this.InitializeComponent();
            this.WorkShopsUserControl = this.UCWorkShops;
            this.workShopsViewModel = new WorkShopsViewModel(this);

            if (!this.workShopsViewModel.checkIsGenerated())
            {
                this.GenDataBase();
            }
        }
        #endregion
        #region Methods

        private void navProducts_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new ProductsView();
        }

        private void navCustomers_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new CustomersView();
        }

        private void navCommands_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new CommandsView();
        }
        /// <summary>
        /// Generate database at start of the program
        /// </summary>
        private void GenDataBase()
        {
            this.isGenLabel.Content = "Db Generation in Process...";
            Fixtures fix = new Fixtures();
            Task.Factory.StartNew(() =>
            {
                while (!fix.IsFix)
                {
                    Thread.Sleep(2000);
                }

            }).ContinueWith((Task obj) =>
            {

                Application appl = System.Windows.Application.Current;
                appl.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                    new DispatcherOperationCallback(this.SetOkMessage), null);
                
            });

        }

        /// <summary>
        /// Display a Ok message
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object SetOkMessage(object o)
        {
            this.isGenLabel.Content = "Generation OK";
         
            return null;
        }
        #endregion


    }
}
