using Pet_Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pet_Shop
{
    /// <summary>
    /// Interaction logic for updateCustomerWindow.xaml
    /// </summary>
    public partial class updateCustomerWindow : Window
    {
        public int idText;
        public updateCustomerWindow(Customer cus)
        {
            InitializeComponent();
            idText = cus.Id;
        }

        private void Id_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.Text =  idText.ToString();
            var customer = DataProvider.Ins.DB.Customers.Where(c => c.Id == idText).SingleOrDefault();
            txtDisplayname.Text = customer.DisplayName;
            txtAddress.Text = customer.Address;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;
            txtMoreInfo.Text = customer.MoreInfo;
        }
    }
}
