using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookShop.ApplicationLogic.Services;
using BookShop.ApplicationLogic.Model;
using BookShop.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly UserServices userServices;
        public UserController(UserManager<IdentityUser> userManager, UserServices userServices)
        {
            this.userManager = userManager;
            this.userServices = userServices;
        }

        public IActionResult ViewBook([FromRoute] string id)
        {
            var Book = userServices.GetBookbyId(id).Single();
            var rating = userServices.GetAverageRating(Book);
            var comments = userServices.GetComments(Book);
            var BookVM = new UserMainBookViewModel { Book = Book, Comments = comments, Rating = rating };
            return View(BookVM);
        }

        public IActionResult ViewOrders([FromRoute] string id)
        {
            var order = userServices.GetOrderById(id);
            var Book = userServices.GetBookList();
            var BookVM = new ViewOrders {Orders = order, Books = Book };
            return View(BookVM);
        }

        public IActionResult ViewCart([FromRoute] string id)
        {
            var cart = userServices.GetCartByUserId(id);
            var carts = userServices.getCartByShoppingCartId(cart.Id.ToString());
            var Books = userServices.GetBookList();
            IList<Book> cartBooks = new List<Book>();
            float value = 0;
            foreach( var item in carts)
            {
                foreach (var Book in Books)
                    if(item.BookId.ToString() == Book.Id.ToString())
                    {
                       cartBooks.Add(Book);
                        value += Book.Price;
                    }
            }
         
            var BookVM = new ViewCart { cartItems = carts, Books = cartBooks.AsEnumerable(), Value = value};
            return View(BookVM);
        }
        public IActionResult Checkout([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var shoppingCart = userServices.GetCartByUserId(id);
            var carts = userServices.getCartByShoppingCartId(shoppingCart.Id.ToString());
            foreach( var cart in carts.ToList())
            {
                userServices.deleteCart(cart);
            }
            
            return Redirect(Url.Action("Index", "User"));
        }
        [HttpPost]
        public IActionResult AddBill([FromForm] AddBillModelView model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = userManager.GetUserId(User);
            userServices.addBill(userId, model.Address, model.PhoneNumber, model.CardNumber, model.ExpirationDate, model.CVV, model.TotalValue);
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddBill([FromRoute] string id)
        {
            var shoppingCart = userServices.GetCartByUserId(id);
            var carts = userServices.getCartByShoppingCartId(shoppingCart.Id.ToString());
            IList<Book> BookList = new List<Book>();
            float value = 0;
            var Books = userServices.GetBookList();
            foreach(var Book in Books)
            {
                foreach(var cart in carts)
                {
                  if (Book.Id == cart.BookId)
                    {
                        BookList.Add(Book);
                        value += Book.Price;
                    }
                }
            }

            var BookVM = new AddBillModelView { Address = null, CardNumber = null, PhoneNumber = null, CVV = null, ExpirationDate = null, TotalValue = value, BookList = BookList,CartItems = carts.ToList() };
            foreach (var cart in carts.ToList())
            {
                userServices.deleteCart(cart);
            }
            return View(BookVM);
        }

        public IActionResult DeleteOrder([FromRoute] string id)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            userServices.deleteOrder(id);
            return Redirect(Url.Action("Index", "User"));
        }

        public ActionResult Index()
        {
            try
            {        
                    var BookList = userServices.GetBookList();
                    return View(new UserBookViewModel { Books = BookList });

            }
            catch (Exception)
            {
                return BadRequest("aici se blocheaza");
            }
        }
 
        public ActionResult ViewBooksFiction()
        {
            try
            {
                string cat = "Fiction";
                    var BookList = userServices.GetBookByCategory(cat);
                    return View(new UserBookViewModel { Books = BookList });  

            }
            catch (Exception)
            {
                return BadRequest("aici se blocheaza");
            }
        }

        public ActionResult ViewBooksScience()
        {
            try
            {
                string cat = "Science";
                var BookList = userServices.GetBookByCategory(cat);
                return View(new UserBookViewModel { Books = BookList });

            }
            catch (Exception)
            {
                return BadRequest("aici se blocheaza");
            }
        }
        public ActionResult ViewBooksNonFiction()
        {
            try
            {
                string cat = "NonFiction";
                var BookList = userServices.GetBookByCategory(cat);
                return View(new UserBookViewModel { Books = BookList });

            }
            catch (Exception)
            {
                return BadRequest("aici se blocheaza");
            }
        }

        [HttpPost]
        public IActionResult AddComment([FromForm]UserAddCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);

            userServices.addComment(userId, model.BookID, model.Comm);
            //var Book = userServices.GetBookbyGuid(model.BookID).Single();
            //var rating = userServices.GetAverageRating(Book);
            //var comments = userServices.GetComments(Book);
            //var BookVM = new UserMainBookViewModel { Book = Book, Comments = comments, Rating = rating };
            ViewBook(model.BookID.ToString());
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult AddComment([FromRoute]string id)
        {
            var Book = userServices.GetBookbyId(id).Single();
            var BookVM = new UserAddCommentViewModel { BookID = Book.Id};
            return View(BookVM);

        }

        public IActionResult DeleteComment([FromForm] UserAddCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);

            userServices.addComment(userId, model.BookID, model.Comm);
            //var Book = userServices.GetBookbyGuid(model.BookID).Single();
            //var rating = userServices.GetAverageRating(Book);
            //var comments = userServices.GetComments(Book);
            //var BookVM = new UserMainBookViewModel { Book = Book, Comments = comments, Rating = rating };
            ViewBook(model.BookID.ToString());
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult DeleteComment([FromRoute] string id)
        {
            var Book = userServices.GetBookbyId(id).Single();
            var BookVM = new UserAddCommentViewModel { BookID = Book.Id };
            return View(BookVM);

        }


        [HttpPost]
        public IActionResult AddRating([FromForm]UserAddRatingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);

            userServices.addRating(userId, model.BookID, model.Rate);


           
            return RedirectToAction("Index");
            // return Redirect(Url.Action("Index", "Admin"));
        }

        [HttpGet]
        public IActionResult AddRating([FromRoute]string id)
        {
            var Book = userServices.GetBookbyId(id).Single();
            var BookVM = new UserAddRatingViewModel { BookID = Book.Id };
            return View(BookVM);

        }

        [HttpPost]
        public IActionResult AddOrder([FromForm]AddOrderModelView model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);
            userServices.addOrder(userId, model.BookId);
            return RedirectToAction("Index");
            // return Redirect(Url.Action("Index", "Admin"));
        }

        [HttpGet]
        public IActionResult AddOrder([FromRoute]string id)
        {
            var Book = userServices.GetBookbyId(id).Single();
            var BookVM = new AddOrderModelView {BookId = Book.Id};
            return View(BookVM);

        }

        [HttpPost]
        public IActionResult AddCart([FromForm] AddCartModelView model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);
            userServices.addToCart(userId, model.BookId);
            return RedirectToAction("Index");
            // return Redirect(Url.Action("Index", "Admin"));
        }

        [HttpGet]
        public IActionResult AddCart([FromRoute] string id)
        {
            var Books = userServices.GetBookbyId(id).Single();
            var BooksVM = new AddCartModelView { BookId = Books.Id };
            return View(BooksVM);
        }

        [HttpPost]
        public IActionResult AddWish([FromForm] AddOrderModelView model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);
            userServices.addWish(userId, model.BookId);
            return RedirectToAction("Index");
            // return Redirect(Url.Action("Index", "Admin"));
        }

        [HttpGet]
        public IActionResult AddWish([FromRoute] string id)
        {
            var Book = userServices.GetBookbyId(id).Single();
            var BookVM = new AddWishModelView { BookId = Book.Id };
            return View(BookVM);

        }

        


        public IActionResult ViewBills([FromRoute] string id)
        {
            var bills = userServices.GetBillsByUserId(id);
            var BookVM = new ViewBills { Bills = bills};
            return View(BookVM);
        }

        public IActionResult deleteCart([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var cart = userServices.GetCartItemById(id);

            userServices.deleteCart(cart);


            return Redirect(Url.Action("Index", "User"));
        }
    }


}

