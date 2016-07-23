using System;
using System.Collections.Generic;
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
using WorkShopWpf.MyUserControl;
using WorkShopWpf.ViewModel;

namespace WorkShopWpf.Views
{
    /// <summary>
    /// Logique d'interaction pour CommandsView.xaml
    /// </summary>
    public sealed partial class CommandsView : Page
    {
        #region attributs
        private CommandsViewModel CommandsViewModel;
        #endregion

        #region properties
        public CommandsUserControl CommandsUserControl { get; set; }
        public Button AddCommandButton { get; set; }


        #endregion

        #region constructor
        public CommandsView()
        {
            this.InitializeComponent();
            this.CommandsUserControl = this.UCCommands;
            this.AddCommandButton = this.btnNewCommand;
            this.CommandsViewModel = new CommandsViewModel(this);
        }
        #endregion

        #region methods

        #endregion

        private void btnNavHome_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new HomeNavigation();
        }

        private void UCCommands_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewCommand_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new CommandFormView();
        }

        private void btnConfirmCommand_Click(object sender, RoutedEventArgs e)
        {
            this.CommandsViewModel.ValidateCommand(sender, e);
        }
    }
}
