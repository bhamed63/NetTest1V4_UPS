using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using NetTest1V4_UPS.BaseClasses;
using NetTest1V4_UPS.DataServices.Employees;
using NetTest1V4_UPS.IoCCore;
using NetTest1V4_UPS.ViewModels.CustomerViewModels;
using NetTest1V4_UPS.ViewModels.EmployeeViewModels;
using NetTest1V4_UPS.Views.CustomerViews;
using NetTest1V4_UPS.Views.EmployeeViews;

namespace NetTest1V4_UPS.IoC
{
    public sealed class IoCUnityContainer : IContainer
    {
        #region Members

        IDictionary<string, IUnityContainer> _ContainersDictionary;

        const string exception_ContainerNotFound = "exception_ContainerNotFound";

        #endregion

        #region private members

        private void addfakeContainer(IUnityContainer rootContainer)
        {
            IUnityContainer fakeAppContainer = rootContainer.CreateChildContainer();
            _ContainersDictionary.Add("FakeAppContext", fakeAppContainer);
        }

        private void addRealContainer(IUnityContainer rootContainer)
        {
            IUnityContainer realAppContainer = rootContainer.CreateChildContainer();
            _ContainersDictionary.Add("RealAppContext", realAppContainer);
        }

        private IUnityContainer addRootContainer()
        {
            IUnityContainer rootContainer = new UnityContainer();
            _ContainersDictionary.Add("RootContext", rootContainer);
            return rootContainer;
        }

        private void configureRootContainer(IUnityContainer container)
        {
            //Register Application Controller mappings
            container.RegisterType<IApplicationController, ApplicationController>(new ContainerControlledLifetimeManager());

            container.RegisterType<VMEmployeeList>(new ContainerControlledLifetimeManager());

            container.RegisterType<IEmployeeListView, EmployeeListView>();
            container.RegisterType<IEmployeeAddView, EmployeeAddView>();
            container.RegisterType<IEmployeeService, EmployeeService>(new ContainerControlledLifetimeManager());

            container.RegisterType<ICustomerListView, CustomerListView>();
            container.RegisterType<IServiceListView, CustomerListView>();
        }

        #endregion

        #region Constructor

        public IoCUnityContainer()
        {
            _ContainersDictionary = new Dictionary<string, IUnityContainer>();

            IUnityContainer rootContainer = addRootContainer();

            addRealContainer(rootContainer);

            addfakeContainer(rootContainer);

            configureRootContainer(rootContainer);
        }

        #endregion

        #region IServiceFactory Members

        public void Teardown(object o)
        {
            //We use the default container specified in AppSettings
            string containerName = "RealAppContext";

            if (!_ContainersDictionary.ContainsKey(containerName))
                throw new InvalidOperationException(exception_ContainerNotFound);

            IUnityContainer container = _ContainersDictionary[containerName];

            container.Teardown(o);
        }

        public TService Resolve<TService>()
        {
            //We use the default container specified in AppSettings
            string containerName = "RealAppContext";

            if (!_ContainersDictionary.ContainsKey(containerName))
                throw new InvalidOperationException(exception_ContainerNotFound);

            IUnityContainer container = _ContainersDictionary[containerName];

            return container.Resolve<TService>();
        }

        public object Resolve(Type type)
        {
            string containerName = "RealAppContext";

            if (!_ContainersDictionary.ContainsKey(containerName))
                throw new InvalidOperationException(exception_ContainerNotFound);

            IUnityContainer container = _ContainersDictionary[containerName];

            return container.Resolve(type, null);
        }

        public void RegisterType(Type type)
        {
            IUnityContainer container = this._ContainersDictionary["RootContext"];

            if (container != null)
                container.RegisterType(type, new TransientLifetimeManager());
        }

        #endregion
    }
}
