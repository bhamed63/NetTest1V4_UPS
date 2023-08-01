namespace NetTest1V4_UPS.IoCCore
{

    public sealed class IoCFactory
    {
        private static readonly IoCFactory instance;

        private IContainer _CurrentContainer;

        public static IoCFactory Instance
        {
            get
            {
                return IoCFactory.instance;
            }
        }

        public IContainer CurrentContainer
        {
            get
            {
                return this._CurrentContainer;
            }
            set
            {
                this._CurrentContainer = value;
            }
        }

        static IoCFactory()
        {
            IoCFactory.instance = new IoCFactory();
        }

        private IoCFactory()
        {
        }
    }

}
