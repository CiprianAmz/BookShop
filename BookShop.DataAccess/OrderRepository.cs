using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using BookShop.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShop.EFDataAccess
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }

        public IEnumerable<Order> GetOrderByBookId(Guid BookId)
        {
            return dbContext.Orders.Where(a => a.BookId == BookId).AsEnumerable();
        }

        public Order GetOrderByOrdeId(Guid orderId)
        {
            return dbContext.Orders.Where(a => a.Id == orderId).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrderByUserId(Guid userId)
        {
            return dbContext.Orders.Where(a => a.User.Id == userId).AsEnumerable();
        }

      
    }
}
