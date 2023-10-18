using Pet_Shop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pet_Shop.ViewModel
{
    public class InvoiceViewModel:BaseViewModel
    {
        #region command
        public ICommand AddCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand AddServiceCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand EditServiceCommand { get; set; }
        public ICommand EditItemCommand { get; set; }


        public ICommand DeleteCommand { get; set; }
        public ICommand DeleteServiceCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }

        public ICommand PayCommand { get; set; }
        
        #endregion

        #region constructor data
        private string _ProductName { get; set; }
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }

        private DateTime? _DateInput { get; set; }
        public DateTime? DateInput { get => _DateInput; set { _DateInput = value; OnPropertyChanged(); } }

        private int? _Quantity { get; set; }
        public int? Quantity { get => _Quantity; set { _Quantity = value; OnPropertyChanged(); } }

        private int? _QuantityItem { get; set; }
        public int? QuantityItem { get => _QuantityItem; set { _QuantityItem = value; OnPropertyChanged(); } }
        private int? _QuantityServiceItem { get; set; }
        public int? QuantityServiceItem { get => _QuantityServiceItem; set { _QuantityServiceItem = value; OnPropertyChanged(); } }

        private double? _InputPrice { get; set; }
        public double? InputPrice { get => _InputPrice; set { _InputPrice = value; OnPropertyChanged(); } }

        private double? _PriceItem { get; set; }
        public double? PriceItem { get => _PriceItem; set { _PriceItem = value; OnPropertyChanged(); } }
        private double? _PriceServiceItem { get; set; }
        public double? PriceServiceItem { get => _PriceServiceItem; set { _PriceServiceItem = value; OnPropertyChanged(); } }

        private double? _OutputPrice { get; set; }
        public double? OutputPrice { get => _OutputPrice; set { _OutputPrice = value; OnPropertyChanged(); } }
        private string _Status { get; set; }
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        private double? _TotalPriceInvoice { get; set; }
        public double? TotalPriceInvoice { get => _TotalPriceInvoice; set { _TotalPriceInvoice = value; OnPropertyChanged(); } }

        public bool IsSelected { get; set; }
        private ObservableCollection<Invoice> _List;
        public ObservableCollection<Invoice> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> _ProductList;
        public ObservableCollection<Product> ProductList { get => _ProductList; set { _ProductList = value; OnPropertyChanged(); } }

        private ObservableCollection<InvoiceInfo> _InvoiceInfoList;
        public ObservableCollection<InvoiceInfo> InvoiceInfoList { get => _InvoiceInfoList; set { _InvoiceInfoList = value; OnPropertyChanged(); } }
        private ObservableCollection<InvoiceInfo> _InvoiceInfoListItem;
        public ObservableCollection<InvoiceInfo> InvoiceInfoListItem { get => _InvoiceInfoListItem; set { _InvoiceInfoListItem = value; OnPropertyChanged(); } }

        private ObservableCollection<InvoiceInfo> _InvoiceInfoListItemSer;
        public ObservableCollection<InvoiceInfo> InvoiceInfoListItemSer { get => _InvoiceInfoListItemSer; set { _InvoiceInfoListItemSer = value; OnPropertyChanged(); } }

        private ObservableCollection<Service> _ServiceList;
        public ObservableCollection<Service> ServiceList { get => _ServiceList; set { _ServiceList = value; OnPropertyChanged(); } }
        #endregion

        #region product
        private Invoice _SelectedItem;
        public Invoice SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();

            }
        }

        private InvoiceInfo _SelectedInfoItem;
        public InvoiceInfo SelectedInfoItem
        {
            get => _SelectedInfoItem;
            set
            {
                _SelectedInfoItem = value;
                OnPropertyChanged();
                
            }
        }
        

        private InvoiceInfo _SelectedInfoItemSM;
        public InvoiceInfo SelectedInfoItemSM
        {
            get => _SelectedInfoItemSM;
            set
            {
                _SelectedInfoItemSM = value;
                OnPropertyChanged();
                if (SelectedInfoItemSM != null)
                {

                    SelectedProductItem = SelectedInfoItemSM.Product;

                    PriceItem = SelectedInfoItemSM.Price;

                    QuantityItem = SelectedInfoItemSM.Quantity;
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
                QuantityItem = 1;
                PriceItem = SelectedProductItem.Price;
            }
        }


        #endregion

        #region service

        private Service _SelectedServiceItem;
        public Service SelectedServiceItem
        {
            get => _SelectedServiceItem;
            set
            {
                _SelectedServiceItem = value;
                OnPropertyChanged();
                QuantityServiceItem = 1;
                 PriceServiceItem = SelectedServiceItem.Price;
            }
        }
        private InvoiceInfo _SelectedInfoItemSer;
        public InvoiceInfo SelectedInfoItemSer
        {
            get => _SelectedInfoItemSer;
            set
            {
                _SelectedInfoItemSer = value;
                OnPropertyChanged();
                SelectedServiceItem = SelectedInfoItemSer.Service;
                QuantityServiceItem = SelectedInfoItemSer.Quantity;
                PriceServiceItem = SelectedInfoItemSer.Price;

            }
        }
        #endregion
        public InvoiceViewModel()
        {
            List = new ObservableCollection<Invoice>(DataProvider.Ins.DB.Invoices);
            InvoiceInfoList = new ObservableCollection<InvoiceInfo>(DataProvider.Ins.DB.InvoiceInfoes);
            ServiceList = new ObservableCollection<Service>(DataProvider.Ins.DB.Services);
            ProductList = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);
            TotalPriceInvoice = 0;

            InvoiceInfoListItem = new ObservableCollection<InvoiceInfo>();

            AddItemCommand = new RelayCommand<object>((p) => {
                if (SelectedProductItem == null)
                {
                    return false;
                }
                if(QuantityItem < 1)
                {
                    return false;
                }
                
                return true;
            }, (p) =>
            {
                if (InvoiceInfoListItem.Where(x => x.IdProduct == SelectedProductItem.Id).FirstOrDefault() == null)
                {
                    InvoiceInfo invoiceInfo = new InvoiceInfo() {IdProduct = SelectedProductItem.Id, Product = SelectedProductItem, Quantity = QuantityItem, Price = DataProvider.Ins.DB.Products.Where(x => x.Id == SelectedProductItem.Id).FirstOrDefault().Price };
                    InvoiceInfoListItem.Add(invoiceInfo);
                }
                else
                {
                    int? newQuantity = InvoiceInfoListItem.Where(x => x.IdProduct == SelectedProductItem.Id).FirstOrDefault().Quantity + QuantityItem;
                    InvoiceInfoListItem.Remove(InvoiceInfoListItem.Where(x => x.IdProduct == SelectedProductItem.Id).FirstOrDefault());

                    InvoiceInfo invoiceInfoSer = new InvoiceInfo() { IdProduct = SelectedProductItem.Id, Product = SelectedProductItem, Quantity = newQuantity, Price = DataProvider.Ins.DB.Products.Where(x => x.Id == SelectedProductItem.Id).FirstOrDefault().Price };
                    InvoiceInfoListItem.Add(invoiceInfoSer);
                }
                
                TotalPriceInvoice = GetTotalPrice();
            });

            EditItemCommand = new RelayCommand<object>((p) => {
                if (SelectedInfoItemSM == null)
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                var obj = InvoiceInfoListItem.Where(x => x.IdProduct == SelectedInfoItemSM.IdProduct).SingleOrDefault();
                obj.Price = PriceItem;
                obj.Quantity = QuantityItem;

               
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
                        var pro = InvoiceInfoListItem.Where(c => c.IdProduct == SelectedInfoItemSM.Product.Id).FirstOrDefault();
                        if (pro != null)
                        {
                            InvoiceInfoListItem.Remove(pro);

                        }
                    }

                }

                QuantityItem = 0;
                PriceItem = 0;

            });

            InvoiceInfoListItemSer = new ObservableCollection<InvoiceInfo>();

            AddServiceCommand = new RelayCommand<object>((p) => {
                if (SelectedServiceItem == null)
                {
                    return false;
                }
                if (QuantityServiceItem < 1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                if(InvoiceInfoListItemSer.Where(x => x.IdService == SelectedServiceItem.Id).FirstOrDefault() == null)
                {
                    InvoiceInfo invoiceInfoSer = new InvoiceInfo() {  IdService = SelectedServiceItem.Id, Service = SelectedServiceItem, Quantity = QuantityServiceItem, Price = DataProvider.Ins.DB.Services.Where(x => x.Id == SelectedServiceItem.Id).FirstOrDefault().Price };
                    InvoiceInfoListItemSer.Add(invoiceInfoSer);
                }
                else
                {
                    int? newQuantity = InvoiceInfoListItemSer.Where(x => x.IdService == SelectedServiceItem.Id).FirstOrDefault().Quantity + QuantityServiceItem;
                    InvoiceInfoListItemSer.Remove(InvoiceInfoListItemSer.Where(x => x.IdService == SelectedServiceItem.Id).FirstOrDefault());

                    InvoiceInfo invoiceInfoSer = new InvoiceInfo() { IdService = SelectedServiceItem.Id, Service = SelectedServiceItem, Quantity = newQuantity, Price = DataProvider.Ins.DB.Services.Where(x => x.Id == SelectedServiceItem.Id).FirstOrDefault().Price };
                    InvoiceInfoListItemSer.Add(invoiceInfoSer);
                }

                
                TotalPriceInvoice = GetTotalPrice();
            });

            EditServiceCommand = new RelayCommand<object>((p) => {
                if (SelectedInfoItemSer == null)
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                var obj = InvoiceInfoListItemSer.Where(x => x.IdService == SelectedInfoItemSer.IdService).SingleOrDefault();

                MessageBox.Show(obj.Quantity.ToString());
                obj.Quantity = QuantityServiceItem;

                MessageBox.Show("Ban da sua thanh cong!");


            });
            DeleteServiceCommand = new RelayCommand<object>((p) => {
                if (SelectedInfoItemSer == null)
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
                    if (SelectedInfoItemSer != null)
                    {
                        var pro = InvoiceInfoListItemSer.Where(c => c.IdService == SelectedInfoItemSer.Service.Id).FirstOrDefault();
                        if (pro != null)
                        {
                            InvoiceInfoListItemSer.Remove(pro);

                        }
                    }

                }

                QuantityItem = 0;
                PriceItem = 0;

            });


            //Pay 
            PayCommand = new RelayCommand<object>((p) => {
                if (InvoiceInfoListItem.Count() == 0 && InvoiceInfoListItemSer.Count() == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                // Thêm thông báo xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn thanh toán những sản phẩm này không?", "Xác nhận nhập", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Invoice invoice = new Invoice() { DateOutput = DateTime.Now, TotalPrice = TotalPriceInvoice };
                    DataProvider.Ins.DB.Invoices.Add(invoice);

                    foreach (var item in InvoiceInfoListItem)
                    {
                        item.Invoice = invoice;
                        item.Id = invoice.Id;
                       
                        item.TotalPrice = item.Quantity*item.Price;
                        DataProvider.Ins.DB.InvoiceInfoes.Add(item);

                    }

                    foreach (var item in InvoiceInfoListItemSer)
                    {
                        item.Invoice = invoice;
                        item.Id = invoice.Id;
                       

                        item.TotalPrice = item.Quantity * item.Price;
                        DataProvider.Ins.DB.InvoiceInfoes.Add(item);

                    }
                    DataProvider.Ins.DB.SaveChanges();

                     MessageBox.Show("Ban da thanh toan thanh cong");
                }


            });
        }

        double? GetTotalPrice()
        {
            TotalPriceInvoice = 0;
            foreach (var item in InvoiceInfoListItem)
            {
                TotalPriceInvoice += (item.Price * item.Quantity);
            }
            foreach (var item in InvoiceInfoListItemSer)
            {
                TotalPriceInvoice += (item.Price * item.Quantity);
            }


            return TotalPriceInvoice;
        }
       
    }
}
