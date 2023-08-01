using NetTest1V4_UPS.DataServices.Base;
using NetTest1V4_UPS.Models;

namespace NetTest1V4_UPS.BaseClasses
{
    public class BaseFrom<T> : ViewModelBase where T : Entity
    {
        #region private members

        IApplicationController _appController;

        IDataService<T> _dataService;

        IView _view;

        bool _isBusy = false;

        #endregion

        #region protected methods

        protected void makeFormIdle()
        {
            this.IsBusy = false;
        }

        protected void makeFormBusy()
        {
            this.IsBusy = true;
        }

        #endregion

        #region constructors

        public BaseFrom(IApplicationController appController, IView view, IDataService<T> dataService)
        {
            this._appController = appController;
            this._view = view;
            this._view.ViewModel = this;
            this._dataService = dataService;
        }

        #endregion

        #region properties

        public IDataService<T> DataService
        {
            get { return _dataService; }
        }

        protected IApplicationController AppController
        {
            get { return _appController; }
        }

        public IView View
        {
            get { return _view; }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            private set
            {
                _isBusy = value;
                this.NotifyPropertyChanged("IsBusy");
            }
        }

        #endregion
    }
}
