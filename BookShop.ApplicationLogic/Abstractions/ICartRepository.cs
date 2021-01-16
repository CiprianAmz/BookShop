using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface ICartRepository : IRepository<ShoppingCart>
    {
        ShoppingCart GetCartByCartId(Guid cartId);
        IEnumerable<ShoppingCart> GetCartByUserId(Guid userId);
        
    }
}
