using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface ICartRepository : IRepository<ShoppingCart>
    {
        ShoppingCart GetCartByCartId(Guid cartId);
        ShoppingCart GetCartByUserId(Guid userId);
        
    }
}
