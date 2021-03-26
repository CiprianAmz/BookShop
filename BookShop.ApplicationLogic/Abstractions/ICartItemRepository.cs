using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        CartItem GetCartById(Guid cartId);
        IEnumerable<CartItem> GetCartByShoppingCartId(Guid userId);

    }
}
