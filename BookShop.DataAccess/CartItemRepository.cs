using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using BookShop.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShop.EFDataAccess
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }


        public CartItem GetCartById(Guid cartId)
        {
            return dbContext.CartItem.Where(a => a.Id == cartId).FirstOrDefault();
        }

        public IEnumerable<CartItem> GetCartByShoppingCartId(Guid cartId)
        {
            return dbContext.CartItem.Where(a => a.ShoppingCartId == cartId).AsEnumerable();
        }


    }
}
