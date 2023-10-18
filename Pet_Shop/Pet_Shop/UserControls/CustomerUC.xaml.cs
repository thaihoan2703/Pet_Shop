using Pet_Shop.Model;
using Pet_Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pet_Shop.UserControls
{
    /// <summary>
    /// Interaction logic for CustomerUC.xaml
    /// </summary>
    public partial class CustomerUC : UserControl
    {
        public CustomerViewModel Customer { get; set; }

        public CustomerUC()
        {
            InitializeComponent();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
