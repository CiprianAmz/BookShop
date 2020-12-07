using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOrderByOrdeId(Guid orderId, User user);
        IEnumerable<Order> GetOrderByUserId(Guid userId);
        IEnumerable<Order> GetOrderByBookId(Guid BookId);
    }
}
