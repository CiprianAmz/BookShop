using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class SessionSavedBooks
    {
        private List<Book> books;
        private static SessionSavedBooks instance;

        private SessionSavedBooks()
        {
            books = new List<Book>();
        }

        public static SessionSavedBooks getInstance()
        {
            if(instance == null)
            {
                instance = new SessionSavedBooks();
            }

            return instance;
        }

        public void setBooks(List<Book> books)
        {
            this.books = books;
        }

        public List<Book> getBooks()
        {
            return this.books;
        }

    }
}
