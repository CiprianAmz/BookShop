using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookbyId(Guid BookId);
        Book GetBookList();
    }
}
