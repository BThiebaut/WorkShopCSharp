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

namespace WorkShopWpf.Views
{
    /// <summary>
    /// Logique d'interaction pour CommandFormView.xaml
    /// </summary>
    public sealed partial class CommandFormView : Page
    {
        #region attributs
        private CommandFormViewModel CommandFormViewModel;
        #endregion

        #region properties
        public CommandFormUserControl CommandFormUserControl { get; set; }
        public Button SaveButton { get; set; }


        #endregion

        #region constructor
        public CommandFormView()
        {
            this.InitializeComponent();
            this.CommandFormUserControl = this.UCCommandForm;
            this.SaveButton = this.btnSave;
            this.CommandFormViewModel = new CommandFormViewModel(this);
        }
        #endregion

        #region methods

        #endregion

        private void btnNavHome_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as NavigationWindow).Content = new CommandsView();
        }

        private void UCCommandForm_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool canSave = this.CommandFormViewModel.btnSave_Click(sender, e);
            if (canSave)
            {
                
                this.stateLabel.Content = "Command successfully added";
                this.btnSave.Visibility = Visibility.Hidden;
                this.btnNavHome.Content = "Home";

                Task.Factory.StartNew(() =>
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                        new ThreadStart(delegate
                        {
                            this.stateLabel.Foreground = new SolidColorBrush(Color.FromRgb(
                                0, 255, 0
                                ));
                        }));
                });


            }
            else
            {
                this.stateLabel.Content = "Error : Customer is too poor !";

                Task.Factory.StartNew(() =>
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                        new ThreadStart(delegate
                        {
                            this.stateLabel.Foreground = new SolidColorBrush(Color.FromRgb(
                                255, 0, 0
                                ));
                        }));
                });
            }
            
        }
    }
}
