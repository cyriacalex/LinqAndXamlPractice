using System;
using System.Collections.Generic;
using System.Text;

namespace LinqXamlPractice
{
    public class Order
    {
        public decimal price { get; set; }
        public int customerid { get; set; }
        public int orderDate { get; set; }

        public static IEnumerable<Order> OrderList()
        {
            var orderList = new List<Order>();

            orderList.Add(new Order() { customerid = 2, orderDate = 1987, price = 45  });
            orderList.Add(new Order() { customerid = 4, orderDate = 1988, price = 737  });
            orderList.Add(new Order() { customerid = 7, orderDate = 1984, price = 567 });
            orderList.Add(new Order() { customerid = 8, orderDate = 1980, price =  364 });
            orderList.Add(new Order() { customerid = 3, orderDate = 1985, price =  876 });
            orderList.Add(new Order() { customerid = 10, orderDate = 1999, price = 123  });
            orderList.Add(new Order() { customerid = 4, orderDate = 1995, price =  26 });
            orderList.Add(new Order() { customerid = 8, orderDate = 2003, price =  345 });
            orderList.Add(new Order() { customerid = 9, orderDate = 2003, price =  23 });
            orderList.Add(new Order() { customerid = 7, orderDate = 1981, price =  345 });
            orderList.Add(new Order() { customerid = 2, orderDate = 2001, price =  627 });
            orderList.Add(new Order() { customerid = 2, orderDate = 1990, price =  87 });
            orderList.Add(new Order() { customerid = 10, orderDate = 1987, price =  55 });
            orderList.Add(new Order() { customerid = 1, orderDate = 1985, price =  101 });
            orderList.Add(new Order() { customerid = 3, orderDate = 1993,price =  900 });

            return orderList;
        }
    }
}
