using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Exceptions;
using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.ApplicationLogic.Services
{
    public class AdminServices
    {
        private IAdminRepository adminRepository;
        private IBookRepository BookRepository;
        private IUserRepository userRepository;
        private ICommentRepository commentRepository;
        private IOrderRepository orderRepository;
        private IRatingRepository ratingRepository;
        private IWishlistRepository wishlistRepository;

        public AdminServices(IAdminRepository adminRepository,
                             IBookRepository BookRepository,
                             IUserRepository userRepository,
                             ICommentRepository commentRepository,
                             IOrderRepository orderRepository,
                             IRatingRepository ratingRepository,
                             IWishlistRepository wishlistRepository
                            )
        { 
            this.BookRepository = BookRepository;
            this.adminRepository = adminRepository;
            this.userRepository = userRepository;
            this.commentRepository = commentRepository;
            this.orderRepository = orderRepository;
            this.ratingRepository = ratingRepository;
            this.wishlistRepository = wishlistRepository;
        }
        public Admin GetAdminByAdminId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var admin = adminRepository.GetAdminByAdminId(userIdGuid);

            if (admin == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }
            return admin;
        }

        public IEnumerable<Book> GetBookList()
        {
            return BookRepository.GetAll();
        }

        public IEnumerable<Book> GetBookbyId( string BookId)
        {
            Guid BookIdGuid = Guid.Empty;
            if (!Guid.TryParse(BookId, out BookIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return BookRepository.GetAll()
                            .Where(Book => Book.Id != null && Book.Id == BookIdGuid)
                            .AsEnumerable();

        }

        public void addBook(String userId, String BookName, float BookPrice, String BookDescription, String Image, int BookStock, string category)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var admin = adminRepository.GetAdminByAdminId(userIdGuid);
            if (admin == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            BookRepository.Add(new Book()
            {
                Id = Guid.NewGuid(),
                Admin = admin,
                Name = BookName,
                Price = BookPrice,
                Description = BookDescription,
                ImageFile = Image,
                Stock = BookStock,
                Category = category
            }) ;


        }

        public void deleteBook(String userId, Guid BookId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var admin = adminRepository.GetAdminByAdminId(userIdGuid);
            if (admin == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }


            var Book = BookRepository.GetBookbyId(BookId);
            if (Book == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }
            Book.Stock = 0;
            BookRepository.Update(Book);

            }
        public void editBook(String userId, Guid BookId , String BookName, float Price, String BookDescription, int Stock, string category)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var admin = adminRepository.GetAdminByAdminId(userIdGuid);
            if (admin == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }


            var Book = BookRepository.GetBookbyId(BookId);
            if (Book == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            Book.Name = BookName;
            Book.Price = Price;
            Book.Description = BookDescription;
            Book.Stock = Stock;
            Book.Category = category;
            BookRepository.Update(Book);

        }
        


    }
}
