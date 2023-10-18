using Pet_Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pet_Shop.ViewModel
{
    public class CustomerViewModel
    {
        public DataGrid CustomerGrid { get; set; }
        public CustomerViewModel(DataGrid dg) {
            CustomerGrid = dg;
            List<Customer> listCustomer = new List<Customer>();

            foreach (var item in listCustomer)
            {
                dg.Items.Add(item);
            }
        }
    }
}
