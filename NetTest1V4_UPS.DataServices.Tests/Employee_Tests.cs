using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NetTest1V4_UPS.DataServices.Base;
using NetTest1V4_UPS.DataServices.Employees;
using NetTest1V4_UPS.DataServices.Exceptions;
using NetTest1V4_UPS.IoCCore;
using NetTest1V4_UPS.Models;
using System;
using System.Net.Http;

namespace NetTest1V4_UPS.DataServices.Tests
{
    [TestClass]
    public class Employee_Tests
    {
        #region private members

        private IEmployeeService _employeeService = IoCFactory.Instance.CurrentContainer.Resolve<IEmployeeService>();

        #endregion

        #region helper methods

        private Employee createSample(int id = 0)
        {
            var employee = new Employee();
            employee.Gender = "male";
            employee.Name = "Hamed";
            employee.Email = String.Format("Hamed{0}@gmail.Com", DateTime.Now.Ticks.ToString());
            employee.Status = "active";
            employee.Id = id;
            return employee;
        }

        #endregion

        [ClassInitialize]
        public static void InitialClass(TestContext context)
        {
            IoCFactory.Instance.CurrentContainer = new IoCUnityTestContainer();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGenderException))]
        public void Create_Employee_With_Invalid_Gender_Should_Throw_Exception()
        {
            #region arrange

            var employee = new Employee();

            #endregion

            #region act

            _employeeService.Create(employee);

            #endregion

            #region assert

            #endregion
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGenderException))]
        public void Create_Employee_With_NotValid_Gender_Should_Throw_Exception()
        {
            #region arrange

            var employee = new Employee();
            employee.Gender = "a value other than male and femail";

            #endregion

            #region act

            _employeeService.Create(employee);

            #endregion

            #region assert

            #endregion
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Change_Employee_With_Zero_Id_Should_Throw_Exception()
        {
            #region arrange

            var employee = new Employee();

            #endregion

            #region act

            _employeeService.Edit(employee);

            #endregion

            #region assert

            #endregion
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remove_Employee_With_Zero_Id_Should_Throw_Exception()
        {
            #region arrange

            var employeeId = 0;

            #endregion

            #region act

            _employeeService.Remove(employeeId);

            #endregion

            #region assert

            #endregion
        }

        [TestMethod]
        public void Create_Employee_Via_Original_WebApi_Should_Done_Successfully()
        {
            #region arrange

            var employee = new Employee();
            employee.Gender = "male";
            employee.Name = "Hamed";
            employee.Email = String.Format("Hamed{0}@gmail.Com", DateTime.Now.Ticks.ToString());
            employee.Status = "active";

            #endregion

            #region act

            var employeeId = _employeeService.Create(employee).Result.GetEmployeeId();

            #endregion

            #region assert

            Assert.IsTrue(employeeId > 0);

            #endregion
        }

        [TestMethod]
        public void Create_Employee_Via_Mock_WebApi_Should_Done_Successfully()
        {
            #region arrange

            Employee employee = createSample();

            Mock<ServiceAdapter> serviceAdapter = new Mock<ServiceAdapter>();
            serviceAdapter.Setup(c => c.Create(It.IsAny<String>(), It.IsAny<StringContent>()))
                .ReturnsAsync(NewMethod());

            _employeeService = new EmployeeService(serviceAdapter.Object);

            #endregion

            #region act

            var result = _employeeService.Create(employee).Result;
            var employeeId = result.GetEmployeeId();

            #endregion

            #region assert

            Assert.AreEqual(employeeId, 109);

            #endregion  
        }

        private static CreateResult NewMethod()
        {
            return new CreateResult()
            {
                Code = 201,
                Data = "{\"id\":\"109\"}"
            };
        }

    }
}
