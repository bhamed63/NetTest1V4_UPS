using System;

namespace NetTest1V4_UPS.IoCCore
{
    public interface IContainer
    {
        void RegisterType(Type type);
        TService Resolve<TService>();
        object Resolve(Type type);
        void Teardown(object o);
    }
}
