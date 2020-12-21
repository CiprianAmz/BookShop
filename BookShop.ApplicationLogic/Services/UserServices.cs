using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Exceptions;
using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.ApplicationLogic.Services
{
    public class UserServices
    {
        private IUserRepository userRepository;
        private IBookRepository BookRepository;
        private ICommentRepository commentRepository;
        private IOrderRepository orderRepository;
        private IRatingRepository ratingRepository;
        private IWishlistRepository wishlistRepository;
        SignInManager<IdentityUser> signInManager;
        UserManager<IdentityUser> userManager;
        

        public UserServices(IUserRepository userRepository, IBookRepository BookRepository, ICommentRepository commentRepository, IOrderRepository orderRepository, IRatingRepository ratingRepository, IWishlistRepository wishlistRepository)
        {
            this.userRepository = userRepository;
            this.BookRepository = BookRepository;
            this.commentRepository = commentRepository;
            this.orderRepository = orderRepository;
            this.ratingRepository = ratingRepository;
            this.wishlistRepository = wishlistRepository;
        }

        public IEnumerable<Book> GetBookList()
        {
            return BookRepository.GetAll();
        }

        public IEnumerable<Book> GetBookByCategory( string category)
        {
            return BookRepository.GetBookByCategory(category);
        }

        public IEnumerable<Order> GetOrderById(string orderId)
        {
            Guid orderIdGuid = Guid.Empty;
            if (!Guid.TryParse(orderId, out orderIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            return orderRepository.GetOrderByUserId(orderIdGuid);
        }
        public Order GetOrderId(string orderId)
        {
            Guid orderIdGuid = Guid.Empty;
            if (!Guid.TryParse(orderId, out orderIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            return orderRepository.GetOrderByOrdeId(orderIdGuid);
        }

        public IEnumerable<Book> GetBookbyId(string BookId)
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
        public IEnumerable<Book> GetBookbyGuid(Guid BookId)
        {
           
            return BookRepository.GetAll()
                            .Where(Book => Book.Id != null && Book.Id == BookId)
                            .AsEnumerable();

        }

        public void addOrder(String userId, Guid BookId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var user = userRepository.GetUserById(userIdGuid);
            var Book = BookRepository.GetBookbyId(BookId);
            
            orderRepository.Add(new Order()
            {
                Id = Guid.NewGuid(),
                User = user,
                Date = DateTime.Today,
                TotalValue = Book.Price,
                BookId = Book.Id

            }) ; 

        }
        public void deleteOrder( string orderId)
        {

            var order = GetOrderId(orderId);

            if (order == null)
            {
       
            }
       
            orderRepository.Delete(order);

        }
        public void addWish(String userId, Guid BookId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var user = userRepository.GetUserById(userIdGuid);
            var Book = BookRepository.GetBookbyId(BookId);

            wishlistRepository.Add(new Wishlist()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                BookId = Book.Id

            });

        }

        public void addComment(String userId, Guid BookId, String comm)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var user = userRepository.GetUserById(userIdGuid);
           
            
            Guid commId = Guid.NewGuid();

            commentRepository.Add(new Comment()
            {
                Id = commId,
                UserId = user.Id,
                Comm = comm,
                BookId = BookId,
                Username = user.Email
            }); 
            
            

        }

        public void addRating(String userId, Guid BookId, float rate)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var user = userRepository.GetUserById(userIdGuid);
            Guid RatingId = Guid.NewGuid();
            
            ratingRepository.Add(new Rating()
            {
                Id = RatingId,
                User = user,
                Rate = rate,
                BookId = BookId
            });        
        }

        public IEnumerable<Comment> GetComments(Book Book)
        {
            return commentRepository.GetCommentByBookId(Book.Id);
        }
        public float GetAverageRating(Book Book)
        {
            var ratings = ratingRepository.GetRatingByBookId(Book.Id);
            int count = 0;
            float avg = 0;
            foreach( var rate in ratings)
            {
                avg += rate.Rate;
                count++;
            }
            return (avg / count);
        }

    }

}
