using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Web.App.New
{
    public class Cart
    {
        public int OrderId { get; }

        public int TotalCount { get; }

        public decimal TotalPrice { get; }

        public Cart(int orderId, int totalCount, decimal totalPrice)
        {
            OrderId = orderId;
            TotalCount = totalCount;
            TotalPrice = totalPrice;
        }
    }
}
