using NetTest1V4_UPS.DataServices.Employees;
using NetTest1V4_UPS.Models;

namespace NetTest1V4_UPS.BaseClasses
{
    public interface IApplicationController
    {
        #region Employee methods

        void ShowEmployeesList();
        void ShowEmployeeAdd();
        void ShowEmployeeEdit(Employee employee);
        void RefereshEmployeesList();

        #endregion

        #region Customer methods

        void ShowCustomersList();

        #endregion

        #region Service methods

        void ShowServicesList();

        #endregion

        #region Shared methods

        void Close<T>(AddForm<T> addForm) where T : Entity;

        #endregion
    }
}
