using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using NetTest1V4_UPS.BaseClasses;
using NetTest1V4_UPS.DataServices.Employees;
using NetTest1V4_UPS.Models;
using NetTest1V4_UPS.Tools;

namespace NetTest1V4_UPS.ViewModels.EmployeeViewModels
{
    public class VMEmployeeList : ListFormBase<Employee>
    {
        #region private members

        ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        Employee _selectedEmployee;

        string _nameSearchKeyWord;

        #endregion private members

        #region constructors

        public VMEmployeeList(IApplicationController appController, IEmployeeListView view, IEmployeeService employeeService)
            : base(appController, view, employeeService)
        {
        }

        #endregion

        #region properties

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                this.NotifyPropertyChanged("Employees");
            }
        }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                this.NotifyPropertyChanged("SelectedEmployee");
            }
        }

        public string NameSearchKeyWord
        {
            get { return _nameSearchKeyWord; }
            set
            {
                _nameSearchKeyWord = value;
                this.NotifyPropertyChanged("NameSearchKeyWord");
            }
        }

        #endregion

        #region command methods

        protected override void addExecute()
        {
            AppController.ShowEmployeeAdd();
        }

        #endregion

        #region overrided methods

        protected override Dictionary<string, object> getFilterParameters()
        {
            Dictionary<string, object> filterParameters = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(_nameSearchKeyWord) && !string.IsNullOrWhiteSpace(_nameSearchKeyWord))
                filterParameters.Add("name", _nameSearchKeyWord);
            return filterParameters;
        }

        protected override void addDataToGridList(List<Employee> dataList)
        {
            this.Employees = new ObservableCollection<Employee>();
            foreach (var item in dataList)
            {
                this.Employees.Add(item);
            }
        }

        protected override void exportExecute(string selectedPath)
        {
            CSVCreator.CreateCSVFile(selectedPath + "\\Employees.csv", this.Employees);
            MessageBox.Show("Employee data has been successfully saved as employees.csv at the selected path.");
        }

        #endregion
    }
}