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
using System.Text.RegularExpressions;

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
                    return View(new UserSearchViewModel { Books = BookList });

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

        public IActionResult SearchedList([FromForm] UserSearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var thisSearchedWord = "";
            if (model.searchedBook != null)
            {
                thisSearchedWord = model.searchedBook;
            }
            var BooksList = userServices.GetBookList();

            var SearchedList = new SearchedListViewModel { Books = BooksList, searchedWord = thisSearchedWord };

            return View(SearchedList);
        }

        public IActionResult SearchedListLucene([FromForm] UserSearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var proc1 = new System.Diagnostics.ProcessStartInfo();
            string Command;
            proc1.UseShellExecute = true;
            Command = @"java -jar C:\Users\Cipri\OneDrive\Documents\GitHub\Lucene\Lucene.jar " + model.searchedBook;
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            /// as admin = proc1.Verb = "runas";
            proc1.Arguments = "/c " + Command; // /k to show the console
            proc1.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            System.Diagnostics.Process.Start(proc1);

            var BooksList = userServices.GetBookList();
            System.Threading.Thread.Sleep(1000); // wait for lucene jar

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Cipri\OneDrive\Documents\GitHub\Lucene\result.txt");

            List<String> SearchedWords = new List<String>();

            if (lines.Length != 0)
            {
                string pattern = @"\\(?<Words>[a-zA-Z]+)\.pdf";
                Regex regex = new Regex(pattern, RegexOptions.ExplicitCapture);

                foreach(var line in lines) 
                {
                    if (regex.IsMatch(line))
                    {
                        MatchCollection matches = regex.Matches(line);
                        foreach (Match match in matches)
                        {
                            if (match.Groups["Words"].Success)
                            {
                                SearchedWords.Add(match.Groups["Words"].Value);
                            }
                        }
                    }
                }
            }

            List<Book> searchResult = new List<Book>();

            foreach (var word in SearchedWords)
            {
                foreach (var book in BooksList)
                {
                    if ((book.Id != Guid.Empty) && (book.Stock != 0) && book.Name.ToLower().Contains(word.ToLower()))
                    {
                        searchResult.Add(book);
                        break;
                    }
                }
            }

            SessionSavedBooks sessionSaved = SessionSavedBooks.getInstance();
            sessionSaved.setBooks(searchResult);

            var SearchedList = new SearchedListLuceneViewModel { Books = searchResult, searchedWord = model.searchedBook, AscentingFlag = true };

            return View(SearchedList);
        }

        public IActionResult AscendingLucene([FromForm] SearchedListLuceneViewModel model)
        {
            List<Book> books = SessionSavedBooks.getInstance().getBooks();

            if(!model.AscentingFlag)
            {
                books.Reverse();
            }

            SessionSavedBooks.getInstance().setBooks(books);
            var SearchedList = new SearchedListLuceneViewModel { Books = books, searchedWord = "", AscentingFlag = true };

            return View(SearchedList);
        }

        public IActionResult DescendingLucene([FromForm] SearchedListLuceneViewModel model)
        {
            List<Book> books = SessionSavedBooks.getInstance().getBooks();

            if (model.AscentingFlag)
            {
                books.Reverse();
            }

            SessionSavedBooks.getInstance().setBooks(books);
            var SearchedList = new SearchedListLuceneViewModel { Books = books, searchedWord = "", AscentingFlag = false };

            return View(SearchedList);
        }

        [RouteAttribute("user/search")]
        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> SearchProductPredictive()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var searchedProduct = userServices.GetBookList().Where(p => p.Name.ToLower().Contains(term.ToLower()))
                                            .Select(p => p.Name).ToList();
                return Ok(searchedProduct);
            }
            catch
            {
                return BadRequest();
            }
        }


    }

}

