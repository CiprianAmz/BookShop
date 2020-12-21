using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.EFDataAccess
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }
        public Book GetBookbyId(Guid BookId)
        {
            return dbContext.Books.Where(a => a.Id == BookId).FirstOrDefault();
        }

        public Book GetBookList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBookByCategory( string category)
        {
            return dbContext.Books.Where(a => a.Category == category).AsEnumerable();
        }
    }
}
