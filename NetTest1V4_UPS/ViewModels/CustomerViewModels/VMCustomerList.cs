using System.Collections.Generic;
using NetTest1V4_UPS.BaseClasses;
using NetTest1V4_UPS.DataServices.Employees;
using NetTest1V4_UPS.Models;

namespace NetTest1V4_UPS.ViewModels.CustomerViewModels
{
    #region VMCustomerList
    public class VMCustomerList : ListFormBase<Employee>
    {
        #region constructors

        public VMCustomerList(IApplicationController appController, ICustomerListView view, IEmployeeService employeeService)
            : base(appController, view, employeeService)
        {

        }

        #endregion

        #region properties

        public string Title
        {
            get { return "Customers Logic Goes Here"; }
        }

        #endregion

        #region overrided methods

        protected override void getListData()
        {

        }

        protected override void addDataToGridList(List<Employee> dataList)
        {
            throw new System.NotImplementedException();
        }

        protected override void exportExecute(string selectedPath)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region VMServiceList
    public class VMServiceList : ListFormBase<Employee>
    {
        #region constructors

        public VMServiceList(IApplicationController appController, IServiceListView view, IEmployeeService employeeService)
            : base(appController, view, employeeService)
        {

        }

        #endregion

        #region properties

        public string Title
        {
            get { return "Services Logic Goes Here"; }
        }

        #endregion

        #region overrided methods

        protected override void getListData()
        {

        }

        protected override void addDataToGridList(List<Employee> dataList)
        {
            throw new System.NotImplementedException();
        }

        protected override void exportExecute(string selectedPath)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region ICustomerListView
    public interface ICustomerListView : IListView
    {
    }
    #endregion

    #region IServiceListView
    public interface IServiceListView : IListView
    {
    }
    #endregion
}
