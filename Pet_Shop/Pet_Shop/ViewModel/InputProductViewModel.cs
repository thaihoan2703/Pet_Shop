using Pet_Shop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Pet_Shop.ViewModel
{
    public class InputProductViewModel:BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand AddItemCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand EditItemCommand { get; set; }


        public ICommand DeleteCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }

        public ICommand SubmitInputItemCommand { get; set; }
        public ICommand InputCommand { get; set; }


        private string _ProductName { get; set; }
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }

        private DateTime? _DateInput { get; set; }
        public DateTime? DateInput { get => _DateInput; set { _DateInput = value; OnPropertyChanged(); } }

        private int? _Quantity { get; set; }
        public int? Quantity { get => _Quantity; set { _Quantity = value; OnPropertyChanged(); } }

        private int? _QuantityItem { get; set; }
        public int? QuantityItem { get => _QuantityItem; set { _QuantityItem = value; OnPropertyChanged(); } }

        private double? _InputPrice { get; set; }
        public double? InputPrice { get => _InputPrice; set { _InputPrice = value; OnPropertyChanged(); } }

        private double? _InputPriceItem { get; set; }
        public double? InputPriceItem { get => _InputPriceItem; set { _InputPriceItem = value; OnPropertyChanged(); } }
        private double? _OutputPrice { get; set; }
        public double? OutputPrice { get => _OutputPrice; set { _OutputPrice = value; OnPropertyChanged(); } }
        private double? _OutputPriceItem { get; set; }
        public double? OutputPriceItem { get => _OutputPriceItem; set { _OutputPriceItem = value; OnPropertyChanged(); } }
        private string _Status { get; set; }
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private ObservableCollection<Input> _List;
        public ObservableCollection<Input> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<InputInfo> _InputInfoList;
        public ObservableCollection<InputInfo> InputInfoList { get => _InputInfoList; set { _InputInfoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> _ProductList;
        public ObservableCollection<Product> ProductList { get => _ProductList; set { _ProductList = value; OnPropertyChanged(); } }

        private ObservableCollection<InputInfo> _inputInfoListItem;
        public ObservableCollection<InputInfo> inputInfoListItem { get => _inputInfoListItem; set { _inputInfoListItem = value; OnPropertyChanged(); } }


        private Input _SelectedItem;
        public Input SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                
            }
        }

        private InputInfo _SelectedInfoItem;
        public InputInfo SelectedInfoItem
        {
            get => _SelectedInfoItem;
            set
            {
                _SelectedInfoItem = value;
                OnPropertyChanged();
                if (SelectedInfoItem != null)
                {
                    
                    ProductName = SelectedInfoItem.Product.DisplayName;
                    

                    SelectedItem = SelectedInfoItem.Input;
                    DateInput = SelectedItem.DateInput;

                    InputPrice = SelectedInfoItem.InputPrice;
                    OutputPrice = SelectedInfoItem.OutputPrice;
                   
                    Quantity = SelectedInfoItem.Count;
                    Status = SelectedInfoItem.Status;
                }
            }
        }


        private InputInfo _SelectedInfoItemSM;
        public InputInfo SelectedInfoItemSM
        {
            get => _SelectedInfoItemSM;
            set
            {
                _SelectedInfoItemSM = value;
                OnPropertyChanged();
                if (SelectedInfoItemSM != null)
                {

                    SelectedProductItem = SelectedInfoItemSM.Product;

                    InputPriceItem = SelectedInfoItemSM.InputPrice;
                    OutputPriceItem = SelectedInfoItemSM.OutputPrice;
                    QuantityItem = SelectedInfoItemSM.Count;

                }
            }
        }

        private Product _SelectedProductItem;
        public Product SelectedProductItem
        {
            get => _SelectedProductItem;
            set
            {
                _SelectedProductItem = value;
                OnPropertyChanged();
                
            }
        }

        public InputProductViewModel()
        {
            List = new ObservableCollection<Input>(DataProvider.Ins.DB.Inputs);
            InputInfoList = new ObservableCollection<InputInfo>(DataProvider.Ins.DB.InputInfoes);
            ProductList = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);
            

            InputCommand = new RelayCommand<object>((p) => {
                
                return true;
            }, (p) =>
            {
                InputWindow inputWindow = new InputWindow();
                inputInfoListItem = new ObservableCollection<InputInfo>();
                inputWindow.ShowDialog();
            });

            EditCommand = new RelayCommand<object>((p) => {
                if (SelectedInfoItem == null)
                {
                    return false;
                }

                var displayList = DataProvider.Ins.DB.InputInfoes.Where(x => x.IdProduct == SelectedInfoItem.Product.Id);

                if (displayList == null && displayList.Count() == 0)
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                var obj = DataProvider.Ins.DB.InputInfoes.Where(x => x.IdProduct == SelectedInfoItem.Product.Id).SingleOrDefault();
                obj.OutputPrice = OutputPrice;
                obj.Status = Status; 

                DataProvider.Ins.DB.SaveChanges();
               
                MessageBox.Show("Ban da sua thanh cong!");


            });

            DeleteCommand = new RelayCommand<object>((p) => {
                if(SelectedInfoItem == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                // Thêm thông báo xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (SelectedInfoItem != null)
                    {
                        var pro = DataProvider.Ins.DB.InputInfoes.Where(c => c.IdProduct == SelectedInfoItem.Product.Id).FirstOrDefault();
                        if (pro != null)
                        {
                            DataProvider.Ins.DB.InputInfoes.Remove(pro);
                            DataProvider.Ins.DB.SaveChanges();

                        }
                    }

                }
                InputInfoList = new ObservableCollection<InputInfo>(DataProvider.Ins.DB.InputInfoes);


            });


            // xử lý trong Inputindow
            inputInfoListItem = new ObservableCollection<InputInfo>();
            AddItemCommand = new RelayCommand<object>((p) => {
                if (SelectedProductItem == null)
                {
                    return false;
                }
                if (inputInfoListItem.Where(i => i.IdProduct == SelectedProductItem.Id).Count() > 0) {
                    return false;
                }
                return true;
            }, (p) =>
            {

                InputInfo inputInfoObj = new InputInfo() { IdProduct = SelectedProductItem.Id, Product = SelectedProductItem, Count = QuantityItem, InputPrice = InputPriceItem, OutputPrice = OutputPriceItem };
                inputInfoListItem.Add(inputInfoObj);

                QuantityItem = 0;
                InputPriceItem = 0;
                MessageBox.Show("Thêm mới thành công!");
            });
            EditItemCommand = new RelayCommand<object>((p) => {
                if(SelectedInfoItemSM == null)
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                var obj = inputInfoListItem.Where(x => x.IdProduct == SelectedInfoItemSM.IdProduct).SingleOrDefault();
                obj.InputPrice = InputPriceItem;
                obj.Count = QuantityItem;

                QuantityItem = 0;
                InputPriceItem = 0;
                MessageBox.Show("Ban da sua thanh cong!");


            });


            DeleteItemCommand = new RelayCommand<object>((p) => {
                if (SelectedInfoItemSM == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                // Thêm thông báo xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (SelectedInfoItemSM != null)
                    {
                        var pro = inputInfoListItem.Where(c => c.IdProduct == SelectedInfoItemSM.Product.Id).FirstOrDefault();
                        if (pro != null)
                        {
                            inputInfoListItem.Remove(pro);

                        }
                    }

                }

                QuantityItem = 0;
                InputPriceItem = 0;

            });

            SubmitInputItemCommand = new RelayCommand<Window>((p) => {
                if(inputInfoListItem.Count() == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                // Thêm thông báo xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn nhập những sản phẩm này không?", "Xác nhận nhập", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var input = new Input() { DateInput = DateTime.Now };

                    foreach (var item in inputInfoListItem)
                    {
                        item.Input = input;
                        item.IdInput = input.Id;
                        DataProvider.Ins.DB.InputInfoes.Add(item);
                        DataProvider.Ins.DB.Products.Where(x => x.Id == item.IdProduct).FirstOrDefault().Price = (double)item.OutputPrice;
                        InputInfoList.Add(item);
                    }
                    DataProvider.Ins.DB.SaveChanges();

                    if (p != null)
                    {
                        p.Close();

                    }
                }


            });

        }
    }
}
