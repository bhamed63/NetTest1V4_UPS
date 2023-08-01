using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using NetTest1V4_UPS.DataServices.Base;
using NetTest1V4_UPS.Models;

namespace NetTest1V4_UPS.BaseClasses
{
    public abstract class ListFormBase<T> : BaseFrom<T> where T : Entity
    {
        #region private members

        ICommand _addCommand;
        ICommand _editCommand;
        ICommand _deleteCommand;
        ICommand _exportCommand;
        ICommand _searchCommand;

        ICommand _nextPageCommand;
        ICommand _prevPageCommand;

        int _pageNumber = 1;
        int _maxPage;
        int _totalItems;

        #endregion

        #region private methods

        private async System.Threading.Tasks.Task<GetDataListResult<T>> fetchData()
        {
            return await DataService.GetDataListAsync(PageNumber, this.getFilterParameters());
        }

        private void setPageNumberValue(int value)
        {
            if (value <= 0)
                _pageNumber = 1;
            else if (value > this.MaxPage)
                _pageNumber = this.MaxPage;
            else
                _pageNumber = value;
        }

        private void processRemoveResult(RemoveResult result)
        {
            if (result.IsSuccessful)
            {
                MessageBox.Show("Selected item is successfully deleted.");
                this.Referesh();
            }
            else
                MessageBox.Show(result.GetMessages());
        }

        #endregion

        #region constructors

        public ListFormBase(IApplicationController appController, IListView view, IDataService<T> dataService)
            : base(appController, view, dataService)
        {
            getListData();
        }

        #endregion

        #region protected methods

        protected virtual async void getListData()
        {
            makeFormBusy();
            GetDataListResult<T> result = await fetchData();
            updatePaging(result.Meta.Pagination);
            addDataToGridList(result.Data);
            makeFormIdle();
        }

        protected virtual void updatePaging(Pagination pagination)
        {
            this.MaxPage = pagination.Pages;
            this.TotalItems = pagination.Total;
        }

        protected virtual Dictionary<string, object> getFilterParameters()
        {
            return new Dictionary<string, object>();
        }

        protected abstract void addDataToGridList(List<T> dataList);

        protected virtual async void removeData(int paramId)
        {
            makeFormBusy();
            var result = await this.DataService.Remove(paramId);
            makeFormIdle();
            processRemoveResult(result);
        }

        #endregion

        #region properties

        public int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                setPageNumberValue(value);
                this.getListData();
                this.NotifyPropertyChanged("PageNumber");
            }
        }

        public int MaxPage
        {
            get { return _maxPage; }
            set
            {
                _maxPage = value;
                this.NotifyPropertyChanged("MaxPage");
            }
        }

        public int TotalItems
        {
            get { return _totalItems; }
            private set
            {
                _totalItems = value;
                this.NotifyPropertyChanged("TotalItems");
            }
        }

        #endregion

        #region public methods

        public virtual void Referesh()
        {
            this.getListData();
        }

        #endregion

        #region Commands

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new DelegateCommand(addExecute);
                return _addCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new DelegateCommand<T>(editExecute);
                return _editCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new DelegateCommand<T>(removeExecute);
                return _deleteCommand;
            }
        }

        public ICommand ExportCommand
        {
            get
            {
                if (_exportCommand == null)
                    _exportCommand = new DelegateCommand(exportExecute);
                return _exportCommand;
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new DelegateCommand(searchExecute);
                return _searchCommand;
            }
        }

        public ICommand NextPageCommand
        {
            get
            {
                if (_nextPageCommand == null)
                    _nextPageCommand = new DelegateCommand(nextPageExecute);
                return _nextPageCommand;
            }
        }

        public ICommand PrevPageCommand
        {
            get
            {
                if (_prevPageCommand == null)
                    _prevPageCommand = new DelegateCommand(prevPageExecute);
                return _prevPageCommand;
            }
        }

        #endregion

        #region Command Methods

        protected virtual void addExecute()
        {

        }

        protected virtual void editExecute(T param)
        {

        }

        protected virtual void removeExecute(T param)
        {
            if (param == null)
                MessageBox.Show("Please select the row you want to remove it.");
            else if (MessageBox.Show("Do you realy want to remove the selected data?", "Remove", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                removeData(param.Id);
        }

        protected virtual void exportExecute()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                exportExecute(dialog.SelectedPath);
            }
        }

        protected virtual void searchExecute()
        {
            getListData();
        }

        protected virtual void nextPageExecute()
        {
            PageNumber = PageNumber + 1;
        }

        protected virtual void prevPageExecute()
        {
            PageNumber = PageNumber - 1;
        }

        protected abstract void exportExecute(string selectedPath);

        #endregion
    }
}
