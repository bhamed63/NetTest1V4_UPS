using NetTest1V4_UPS.BaseClasses;
using NetTest1V4_UPS.ViewModels.EmployeeViewModels;
using System.Windows;

namespace NetTest1V4_UPS.Views.EmployeeViews
{
    /// <summary>
    /// Interaction logic for EmployeeAddView.xaml
    /// </summary>
    public partial class EmployeeAddView : Window, IEmployeeAddView 
    {
        public EmployeeAddView()
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
