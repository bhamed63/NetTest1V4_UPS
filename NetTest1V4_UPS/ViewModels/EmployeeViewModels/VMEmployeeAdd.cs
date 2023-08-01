using NetTest1V4_UPS.BaseClasses;
using NetTest1V4_UPS.DataServices.Employees;
using NetTest1V4_UPS.Models;

namespace NetTest1V4_UPS.ViewModels.EmployeeViewModels
{
    public class VMEmployeeAdd : AddForm<Employee>
    {
        #region private members

        bool _isActive = true;
        bool _isMale = true;

        #endregion

        #region private methods

        private void updateStatusFromIsActive()
        {
            this.Model.Status = _isActive ? "active" : "inactive";
        }

        private void updateGenderFromIsMale()
        {
            this.Model.Gender = _isMale ? "male" : "female";
        }

        #endregion

        #region constructors

        public VMEmployeeAdd(IApplicationController appController, IEmployeeAddView view, IEmployeeService employeeService)
            : base(appController, view, employeeService)
        {
            this.Model = new Employee();
            this.updateStatusFromIsActive();
            this.updateGenderFromIsMale();
        }

        #endregion

        #region properties

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                this.updateStatusFromIsActive();
                this.NotifyPropertyChanged("IsActive");
            }
        }

        public bool IsMale
        {
            get { return _isMale; }
            set
            {
                _isMale = value;
                this.updateGenderFromIsMale();
                this.NotifyPropertyChanged("IsMale");
            }
        }

        #endregion

        #region command methods

        protected override void onSuccessfulSave()
        {
            this.AppController.RefereshEmployeesList();
        }

        #endregion

    }
}
