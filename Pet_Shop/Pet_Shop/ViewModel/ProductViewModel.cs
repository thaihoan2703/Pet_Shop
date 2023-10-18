using Pet_Shop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Pet_Shop.ViewModel
{
    public class ProductViewModel:BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        private string _DisplayName { get; set; }
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private double _Price { get; set; }
        public double Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private int _IdSuplier { get; set; }
        public int IdSuplier { get => _IdSuplier; set { _IdSuplier = value; OnPropertyChanged(); } }

        private string _BarCode { get; set; }
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> _List;
        public ObservableCollection<Product> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Suplier> _SuplierList;
        public ObservableCollection<Suplier> SuplierList { get => _SuplierList; set { _SuplierList = value; OnPropertyChanged(); } }


        private Product _SelectedItem;
        public Product SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Price = SelectedItem.Price;
                    SelectedSuplier = SelectedItem.Suplier;
                    BarCode = SelectedItem.BarCode;
                }
            }
        }
        private Model.Suplier _SelectedSuplier;
        public Model.Suplier SelectedSuplier
        {
            get => _SelectedSuplier;
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            SuplierList = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            List = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);

            AddCommand = new RelayCommand<object>((p) => {
                if(DisplayName == string.Empty || DisplayName == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var product = new Product() { DisplayName = DisplayName,Price = Price, IdSuplier = SelectedSuplier.Id, BarCode=BarCode};
                DataProvider.Ins.DB.Products.Add(product);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(product);
                MessageBox.Show("Thêm mới thành công!");
            });

            EditCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                {
                    return false;
                }

                var displayList = DataProvider.Ins.DB.Products.Where(x => x.Id == SelectedItem.Id);

                if (displayList != null && displayList.Count() != 0)
                {
                    return true;
                }

                return true;
            }, (p) =>
            {
                var pro = DataProvider.Ins.DB.Products.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                pro.DisplayName = DisplayName;
                pro.Price = Price;
                pro.IdSuplier = SelectedSuplier.Id;
                pro.BarCode = BarCode;

                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName = DisplayName;
                MessageBox.Show("Cập nhật thành công!");


            });

            DeleteCommand = new RelayCommand<object>((p) => {

                return true;
            }, (p) =>
            {
                // Thêm thông báo xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (SelectedItem != null)
                    {
                        var pro = DataProvider.Ins.DB.Products.Where(c => c.Id == SelectedItem.Id).FirstOrDefault();
                        if (pro != null)
                        {
                            DataProvider.Ins.DB.Products.Remove(pro);
                            DataProvider.Ins.DB.SaveChanges();

                        }
                    }

                }
                List = new ObservableCollection<Model.Product>(DataProvider.Ins.DB.Products);

            });
        }

    }
}
