using System.Windows;
using NetTest1V4_UPS.IoC;
using NetTest1V4_UPS.IoCCore;
using NetTest1V4_UPS.Models;
using NetTest1V4_UPS.ViewModels.CustomerViewModels;
using NetTest1V4_UPS.ViewModels.EmployeeViewModels;

namespace NetTest1V4_UPS.BaseClasses
{
    public class ApplicationController : IApplicationController
    {
        #region private methods

        private void showListViewOnMainContent(IView view)
        {
            (Application.Current.MainWindow as MainWindow).contentPlaceHolder.Content = view;
        }

        private void showViewModal(IView addForm)
        {
            (addForm as Window).ShowDialog();
            (addForm as Window).Owner = Application.Current.MainWindow;
        }

        private object createObject<T>()
        {
            return IoCFactory.Instance.CurrentContainer.Resolve<T>();
        }

        #endregion

        #region constructions

        public ApplicationController()
        {

        }

        #endregion

        #region public methods

        #region Employee methods

        public void ShowEmployeesList()
        {
            var vmEmployeeList = createObject<VMEmployeeList>() as VMEmployeeList;
            showListViewOnMainContent(vmEmployeeList.View);
        }

        public void ShowEmployeeAdd()
        {
            var vmEmployeeAdd = createObject<VMEmployeeAdd>() as VMEmployeeAdd;
            showViewModal(vmEmployeeAdd.View);
        }

        public void ShowEmployeeEdit(Employee employee)
        {

        }

        public void RefereshEmployeesList()
        {
            var vmEmployeeList = createObject<VMEmployeeList>() as VMEmployeeList;
            vmEmployeeList.Referesh();
        }

        #endregion

        #region Customer methods

        public void ShowCustomersList()
        {
            var vmCustomerList = createObject<VMCustomerList>() as VMCustomerList;
            showListViewOnMainContent(vmCustomerList.View);
        }

        #endregion

        #region Service methods

        public void ShowServicesList()
        {
            var vmServiceList = createObject<VMServiceList>() as VMServiceList; ;
            showListViewOnMainContent(vmServiceList.View);
        }

        #endregion

        #region Shared methods

        public void Close<T>(AddForm<T> addForm) where T : Entity
        {
            (addForm.View as Window).Close();
        }

        #endregion

        #endregion
    }
}
