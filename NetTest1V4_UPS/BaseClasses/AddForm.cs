using NetTest1V4_UPS.DataServices.Base;
using NetTest1V4_UPS.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace NetTest1V4_UPS.BaseClasses
{
    public class AddForm<T> : BaseFrom<T> where T : Entity
    {
        #region private members

        T _model;

        ICommand _saveCommand;
        ICommand _cancelCommand;

        #endregion

        #region constructors

        public AddForm(IApplicationController appController, IAddFormView view, IDataService<T> dataService)
            : base(appController, view, dataService)
        {
        }

        #endregion

        #region properties

        public T Model
        {
            get { return _model; }
            set { _model = value; }
        }

        #endregion

        #region Commands

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new DelegateCommand(saveExecute);
                return _saveCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new DelegateCommand(cancelExecute);
                return _cancelCommand;
            }
        }

        #endregion

        #region Command Methods

        protected virtual async void saveExecute()
        {
            makeFormBusy();
            var result = await this.DataService.Create(Model);
            makeFormIdle();
            if (result.IsSuccessful)
            {
                this.AppController.Close(this);
                this.onSuccessfulSave();
            }
            else
                MessageBox.Show(result.GetMessages());
        }

        protected virtual void cancelExecute()
        {
            this.AppController.Close(this);
        }

        protected virtual void onSuccessfulSave()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
