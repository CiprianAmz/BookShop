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

        public AdminServices(IAdminRepository adminRepository,
                             IBookRepository BookRepository,
                             IUserRepository userRepository,
                             ICommentRepository commentRepository,
                             IOrderRepository orderRepository,
                             IRatingRepository ratingRepository
                            )
        { 
            this.BookRepository = BookRepository;
            this.adminRepository = adminRepository;
            this.userRepository = userRepository;
            this.commentRepository = commentRepository;
            this.orderRepository = orderRepository;
            this.ratingRepository = ratingRepository;

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

        public void addBook(String userId, String BookName, float BookPrice, String BookDescription, String Image)
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
                ImageFile = Image
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
            Guid DummyId = Guid.Empty;


            var comments = commentRepository.GetCommentByBookId(BookId).ToList();
            var orders = orderRepository.GetOrderByBookId(BookId).ToList();
            var ratings = ratingRepository.GetRatingByBookId(BookId).ToList();
            if (comments != null)
            {
                foreach (var comment in comments)
                {
                    commentRepository.Delete(comment);
                }
            }
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    order.BookId = Guid.Empty;
                    orderRepository.Update(order);
                    //orderRepository.Add(new Order()
                    //{                    
                    //    Id = order.Id,
                    //    User = order.User,
                    //    Date = order.Date,
                    //    TotalValue = order.TotalValue,
                    //    BookId = DummyId
                    //});
                }

                if (ratings != null)
                {
                    foreach (var rating in ratings)
                    {
                        ratingRepository.Delete(rating);
                    }
                }

                BookRepository.Delete(Book);

            }
        }
        public void editBook(String userId, Guid BookId , String BookName, float Price, String BookDescription)
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

            BookRepository.Update(Book);

        }

    }
}
