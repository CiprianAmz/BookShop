using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.ApplicationLogic.Model
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
