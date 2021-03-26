using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using BookShop.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShop.EFDataAccess
{
    public class CartRepository : BaseRepository<ShoppingCart>, ICartRepository
    {
        public CartRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }


        public ShoppingCart GetCartByCartId(Guid cartId)
        {
            return dbContext.ShoppingCart.Where(a => a.Id == cartId).FirstOrDefault();
        }

        public ShoppingCart GetCartByUserId(Guid userId)
        {
            return dbContext.ShoppingCart.Where(a => a.UserId == userId).FirstOrDefault();
        }


    }
}
