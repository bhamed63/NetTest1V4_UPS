using NetTest1V4_UPS.BaseClasses;
using System.Windows.Input;

namespace NetTest1V4_UPS.ViewModels
{
    public class VMMain : ViewModelBase
    {
        #region members

        ICommand _employeesListCommand;
        ICommand _customersListCommand;
        ICommand _servicesListCommand;

        IApplicationController _applicationController;

        #endregion

        #region constructors

        public VMMain(IApplicationController applicationController)
        {
            _applicationController = applicationController;
        }

        #endregion

        #region properties

        public string PageTitle
        {
            get { return "It is an example application provided for UPS. "; }
        }

        public string Description
        {
            get { return "Create, remove, view items list, search, pagination and export functionalities are implemented."; }
        }

        #endregion

        #region commands

        public ICommand EmployeesListCommand
        {
            get
            {
                if (_employeesListCommand == null)
                    _employeesListCommand = new DelegateCommand(employeesListExecute);
                return _employeesListCommand;
            }
        }

        public ICommand CustomersListCommand
        {
            get
            {
                if (_customersListCommand == null)
                    _customersListCommand = new DelegateCommand(customersListExecute);
                return _customersListCommand;
            }
        }

        public ICommand ServicesListCommand
        {
            get
            {
                if (_servicesListCommand == null)
                    _servicesListCommand = new DelegateCommand(servicesListExecute);
                return _servicesListCommand;
            }
        }

        #endregion

        #region command methods

        private void employeesListExecute()
        {
            _applicationController.ShowEmployeesList();
        }

        private void customersListExecute()
        {
            _applicationController.ShowCustomersList();
        }

        private void servicesListExecute()
        {
            _applicationController.ShowServicesList();
        }

        #endregion
    }
}
