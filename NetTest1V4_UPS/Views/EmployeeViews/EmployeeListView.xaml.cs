using System.Windows.Controls;
using NetTest1V4_UPS.BaseClasses;
using NetTest1V4_UPS.ViewModels.EmployeeViewModels;

namespace NetTest1V4_UPS.Views.EmployeeViews
{
    /// <summary>
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeListView : UserControl, IEmployeeListView
    {
        public EmployeeListView()
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
