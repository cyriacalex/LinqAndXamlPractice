using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LinqXamlPractice
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Person> newPersonList = (List<Person>)Person.PersonList();
        List<Order> newOrderList = (List<Order>)Order.OrderList();
        public Window1()
        {
            InitializeComponent();
        }

        private void btnYears_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbDate1.Text, out int result1) || int.TryParse(tbDate2.Text, out int result2) || int.TryParse(tbPrice1.Text, out int result3) || int.TryParse(tbPrice2.Text, out int result4))
                MessageBox.Show("Enter proper values");
            else
            {
                int date1 = int.Parse(tbDate1.Text);
                int date2 = int.Parse(tbDate2.Text);
                int price1 = int.Parse(tbPrice1.Text);
                int price2 = int.Parse(tbPrice2.Text);

                var resultList = newPersonList.Join(newOrderList, p => p.id,
                    o => o.customerid,
                    (p, o) => new { p.firstName, p.lastName, o.orderDate, o.price })
                    .Where(a => a.orderDate >= date1 && a.orderDate <= date2)
                    .Where(a => a.price >= price1 && a.price <= price2);

                orderpeoplegrid.ItemsSource = resultList;
            }
        }
    }
}
