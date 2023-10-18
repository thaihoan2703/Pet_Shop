using Pet_Shop.Model;
using Pet_Shop.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pet_Shop.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        public ICommand SearchCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand MinusCommand { get; set; }
        public ICommand BonusCommand { get; set; }



        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _MoreInfo;
        public string MoreInfo { get => MoreInfo; set { MoreInfo = value; OnPropertyChanged(); } }

        public string SearchText { get; set; }

        private ObservableCollection<Customer> _List;
        public ObservableCollection<Customer> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        

        private Customer _SelectedItem;
        public Customer SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                  
                }
            }
        }
        public MainViewModel()
        {
            List = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);

            BonusCommand = new RelayCommand<object>((p) => {

                return true;
            }, (p) =>
            {
                MessageBox.Show("Ok");
            });







            SearchCommand = new RelayCommand<object>((p) => {
                
                return true;
            }, (p) =>
            {
                string searchText = SearchText;
                if (searchText != null)
                {
                    List<Model.Customer> filteredCustomers = DataProvider.Ins.DB.Customers.Where(c => c.DisplayName.Contains(searchText)).ToList();
                    List = new ObservableCollection<Model.Customer>(filteredCustomers);

                }
                else
                {
                    List = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
                }
            });

            

            AddCommand = new RelayCommand<Window>((p) => {
                return true;
            }, (p) =>
            {
                // Mở AddCustomerWindow
                var window = new AddCustomerWindow();
                window.ShowDialog();
                List = new ObservableCollection<Model.Customer>(DataProvider.Ins.DB.Customers);
            });

            EditCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                {
                    return false;
                }

                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id);

                if (displayList != null)
                {
                    return true;
                }

                return true;
            }, (p) =>
            {
                var obj = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                updateCustomerWindow uWindow = new updateCustomerWindow(obj);
                uWindow.ShowDialog();

                DataProvider.Ins.DB.SaveChanges();

            });

            DeleteCommand = new RelayCommand<object>((p) => {
                
                return true;
            }, (p) =>
            {
                // Thêm thông báo xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {   
                    if(SelectedItem!= null)
                    {
                        var cus = DataProvider.Ins.DB.Customers.Where(c => c.Id == SelectedItem.Id).FirstOrDefault();
                        if (cus != null)
                        {
                            DataProvider.Ins.DB.Customers.Remove(cus);
                            DataProvider.Ins.DB.SaveChanges();

                        }
                    }
                    
                }
                List = new ObservableCollection<Model.Customer>(DataProvider.Ins.DB.Customers);
            });
        }
    


        /* void LoadTonKhoData()
         {
             TonKhoList = new ObservableCollection<TonKho>();
             var objectList = DataProvider.Ins.DB.Products;

             int i = 1;
             foreach (var item in objectList)
             {
                 var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdInput == item.Id);
                 var outputList = DataProvider.Ins.DB.OutputInfoes.Where(p => p.IdObject == item.Id);

                 int sumInput = 0; int sumOutput = 0;
                 if (inputList != null && inputList.Count() > 0)
                 {
                     sumInput = (int)inputList.Sum(p => p.Count);
                 }
                 if (outputList != null && outputList.Count() > 0)
                 {
                     sumOutput = (int)outputList.Sum(p => p.Count);
                 }

                 TonKho tonKho = new TonKho();
                 tonKho.STT = i;
                 tonKho.Count = sumInput - sumOutput;
                 tonKho.Product = item;

                 TonKhoList.Add(tonKho);


                 i++;
             }
         }*/


    }
}
