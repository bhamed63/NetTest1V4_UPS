using NetTest1V4_UPS.BaseClasses;
using NetTest1V4_UPS.ViewModels.CustomerViewModels;
using System.Windows.Controls;

namespace NetTest1V4_UPS.Views.CustomerViews
{
    /// <summary>
    /// Interaction logic for CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : UserControl, ICustomerListView, IServiceListView
    {
        public CustomerListView()
        {
            InitializeComponent();
        }

        private ViewModelBase _viewModel;

        public ViewModelBase ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                this.DataContext = this._viewModel;
            }
        }
    }
}
