using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace testwpf3.ViewModel.BaseClass {
    class PageableCollection<T> : INotifyPropertyChanged {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged ( [CallerMemberName] String propertyName = "" ) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region contructor
        protected PageableCollection ( ) {}
        public PageableCollection ( IEnumerable<T> currentPageItems, int pageSize, int totalItemSize ) {
            CurrentPageItems = new ObservableCollection<T>(currentPageItems);
            PageSize = pageSize;
            TotalItemSize = totalItemSize;
        }
        #endregion

        #region private properties
        private int pageSize;
        private int currentPageNumber = 1;
        private int totalItemSize;
        private ObservableCollection<T> currentPageItems;
        #endregion


        #region public properties
        public int PageSize {
            get { return pageSize; }
            set {
                this.pageSize = value;
                this.NotifyPropertyChanged();
            }
        }
        public int CurrentPageNumber {
            get { return currentPageNumber; }
            set {
                this.currentPageNumber = value;
                this.NotifyPropertyChanged();
            }
        }
        public int TotalItemSize {
            get { return totalItemSize; }
            set {
                this.totalItemSize = value;
                this.NotifyPropertyChanged();
            }
        }
        public int TotalPagesNumber {
            get { return (TotalItemSize / pageSize) + 1; }
        }
        public ObservableCollection<T> CurrentPageItems {
            get {
                return currentPageItems;
            }
            set {
                this.currentPageItems = value;
                this.NotifyPropertyChanged();
            }
        }
        #endregion


        #region Public Methods
        public void GoToFirstPage ( ) {
            CurrentPageNumber = 1;
        }

        public void GoToNextPage ( ) {
            if (CurrentPageNumber != TotalPagesNumber) {
                CurrentPageNumber++;
            }
        }

        public void GoToPreviousPage ( ) {
            if (CurrentPageNumber > 1) {
                CurrentPageNumber--;
            }
        }

        public void GoToLastPage ( ) {
            CurrentPageNumber = TotalPagesNumber;
        }
        #endregion
    }
}
