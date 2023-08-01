using Microsoft.Practices.Unity;
using NetTest1V4_UPS.DataServices.Employees;
using NetTest1V4_UPS.IoCCore;
using System;
using System.Collections.Generic;

namespace NetTest1V4_UPS.DataServices.Tests
{
    public sealed class IoCUnityTestContainer : IContainer
    {
        #region Members

        IDictionary<string, IUnityContainer> _ContainersDictionary;

        const string exception_DefaultIOCSettings = "exception_DefaultIOCSettings";
        const string exception_ContainerNotFound = "exception_ContainerNotFound";

        #endregion

        #region Constructor

        public IoCUnityTestContainer()
        {
            _ContainersDictionary = new Dictionary<string, IUnityContainer>();

            //Create root container
            IUnityContainer rootContainer = new UnityContainer();
            _ContainersDictionary.Add("RootContext", rootContainer);

            //Create container for real context, child of root container
            IUnityContainer realAppContainer = rootContainer.CreateChildContainer();
            _ContainersDictionary.Add("RealAppContext", realAppContainer);


            //Create container for testing, child of root container
            IUnityContainer fakeAppContainer = rootContainer.CreateChildContainer();
            _ContainersDictionary.Add("FakeAppContext", fakeAppContainer);



            ConfigureRootContainer(rootContainer);
        }

        #endregion

        #region Private Methods

        void ConfigureRootContainer(IUnityContainer container)
        {
            //Register Application Controller mappings
            container.RegisterType<IEmployeeService, EmployeeService>(new ContainerControlledLifetimeManager());
        }

        #endregion

        #region IServiceFactory Members

        public void Teardown(object o)
        {
            //We use the default container specified in AppSettings
            string containerName = "RealAppContext";

            if (String.IsNullOrEmpty(containerName)
                ||
                String.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException(exception_DefaultIOCSettings);
            }

            if (!_ContainersDictionary.ContainsKey(containerName))
                throw new InvalidOperationException(exception_ContainerNotFound);

            IUnityContainer container = _ContainersDictionary[containerName];

            container.Teardown(o);
        }

        public TService Resolve<TService>()
        {
            //We use the default container specified in AppSettings
            string containerName = "RealAppContext";

            if (String.IsNullOrEmpty(containerName)
                ||
                String.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException(exception_DefaultIOCSettings);
            }

            if (!_ContainersDictionary.ContainsKey(containerName))
                throw new InvalidOperationException(exception_ContainerNotFound);

            IUnityContainer container = _ContainersDictionary[containerName];

            return container.Resolve<TService>();
        }

        public object Resolve(Type type)
        {
            //We use the default container specified in AppSettings
            string containerName = "RealAppContext";

            if (String.IsNullOrEmpty(containerName)
                ||
                String.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException(exception_DefaultIOCSettings);
            }

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
