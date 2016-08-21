using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using testwpf3.Repository;
using testwpf3.ViewModel.BaseClass;

namespace testwpf3 {

    class ProductViewModel : INotifyPropertyChanged {

        #region Command Property
        public ICommand FormOnLoadCommand { private set; get; }
        public ICommand DebugProductCommand { private set; get; }
        public ICommand AddProductCommand { private set; get; }
        public ICommand ListFirstCommand { private set; get; }
        public ICommand ListNextCommand { private set; get; }
        public ICommand ListPrevCommand { private set; get; }
        public ICommand ListLastCommand { private set; get; }
        public ICommand ListOnChangedCommand { private set; get; }
        #endregion

        #region Public Property for View
        public List<int> ListSize { private set; get; }
        public Product NewProduct {
            get {
                return newProduct;
            }
            set {
                this.newProduct = value;
                NotifyPropertyChanged();
            }
        }
        public PageableCollection<Product> ListProduct {
            get {
                return listProduct;
            }
            set {
                this.listProduct = value;
                NotifyPropertyChanged();
            }
        }
        public Product SelectedProduct {
            get {
                return selectedProduct;
            }
            set {
                this.selectedProduct = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Private Property 
        private ProductRepository repo;
        private Product newProduct;
        private PageableCollection<Product> listProduct;
        private Product selectedProduct;
        #endregion

        #region Contructor
        public ProductViewModel ( ) {
            repo = new ProductRepository();
            NewProduct = new Product();
            ListSize = new List<int>() { 5, 10, 20 };

            DebugProductCommand = new RelayCommand(ExecuteDebugProductCommand);
            FormOnLoadCommand = new RelayCommand(ExecuteFormOnLoadCommand);
            AddProductCommand = new RelayCommand(ExecuteAddProductCommand);

            ListFirstCommand = new RelayCommand(ExecuteListFirstCommand);
            ListNextCommand = new RelayCommand(ExecuteListNextCommand);
            ListPrevCommand = new RelayCommand(ExecuteListPrevCommand);
            ListLastCommand = new RelayCommand(ExecuteListLastCommand);
            ListOnChangedCommand = new RelayCommand(ExecuteListOnChangedCommand);
        }
        #endregion

        #region ICommand Pagination
        private void ExecuteFormOnLoadCommand ( object param ) {
            int size = ListSize.First();
            ListProduct = new PageableCollection<Product>(
                repo.listProductPagination(1, size),
                size,
                repo.CountProduct());
        }
        private void ExecuteListFirstCommand ( object param ) {
            ListProduct.GoToFirstPage();
            ListProduct.CurrentPageItems = new ObservableCollection<Product>(
                repo.listProductPagination(ListProduct.CurrentPageNumber, ListProduct.PageSize));
            Helper.Show(ListProduct.CurrentPageNumber);
        }
        private void ExecuteListPrevCommand ( object param ) {
            ListProduct.GoToPreviousPage();
            ListProduct.CurrentPageItems = new ObservableCollection<Product>(
                repo.listProductPagination(ListProduct.CurrentPageNumber, ListProduct.PageSize));
            Helper.Show(ListProduct.CurrentPageNumber);
        }
        private void ExecuteListNextCommand ( object param ) {
            ListProduct.GoToNextPage();
            ListProduct.CurrentPageItems = new ObservableCollection<Product>(
                repo.listProductPagination(ListProduct.CurrentPageNumber, ListProduct.PageSize));
            Helper.Show(ListProduct.CurrentPageNumber);
        }
        private void ExecuteListLastCommand ( object param ) {
            ListProduct.TotalItemSize = repo.CountProduct();
            ListProduct.GoToLastPage();
            ListProduct.CurrentPageItems = new ObservableCollection<Product>(
                repo.listProductPagination(ListProduct.CurrentPageNumber, ListProduct.PageSize));
            Helper.Show(ListProduct.CurrentPageNumber);
        }

        private void ExecuteListOnChangedCommand ( object param ) {
            this.ExecuteListFirstCommand(param);
        }
        #endregion

        #region ICommand Method
        private void ExecuteDebugProductCommand ( object param ) {
            repo.listProductPagination(1, 1);
        }
        private void ExecuteAddProductCommand ( object param ) {
            repo.AddProductAsync(NewProduct);
            this.ExecuteListLastCommand(param);
        }        
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged ( [CallerMemberName] String propertyName = "" ) {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        #endregion

    }
}
