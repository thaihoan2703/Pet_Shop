using Pet_Shop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Pet_Shop.ViewModel
{
    public class AddCustomerViewModel:BaseViewModel
    {

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand EditCommand { get; set; }


        public int Id { get; set; }

        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MoreInfo { get; set; }

        public Customer Customer { get; set; }

        private ObservableCollection<Customer> _List;
        public ObservableCollection<Customer> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        public AddCustomerViewModel()
        {
            List = new ObservableCollection<Model.Customer>(DataProvider.Ins.DB.Customers);

            AddCommand = new RelayCommand<Window>((p) => {
                if(DisplayName ==null && Address == null) { return false; }
                return true;
            }, (p) =>
            {
                var Customer = new Customer() { DisplayName = DisplayName, Phone = Phone, Email = Email, Address = Address, MoreInfo = MoreInfo};
                DataProvider.Ins.DB.Customers.Add(Customer);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(Customer);
                if (p != null)
                {
                    p.Close();

                }
            });

            CancelCommand = new RelayCommand<Window>((p) => {
                return true;
            }, (p) =>
            {
                if (p != null)
                {
                    p.Close();
                    
                }

            });
            EditCommand = new RelayCommand<Window>((p) => {

                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.Id == Id);

                if (displayList != null && displayList.Count() != 0)
                {
                    return true;
                }

                return true;
            }, (p) =>
            {
                var Customer = DataProvider.Ins.DB.Customers.Where(x => x.Id == Id).SingleOrDefault();
                Customer.DisplayName = DisplayName;
                Customer.Phone = Phone;
                Customer.Email = Email;
                Customer.Address = Address;
                Customer.MoreInfo = MoreInfo;
                DataProvider.Ins.DB.SaveChanges();
                if (p != null)
                {
                    p.Close();

                }

            });
        }


    }
}
