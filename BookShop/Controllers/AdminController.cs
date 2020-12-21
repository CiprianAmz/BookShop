using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookShop.ApplicationLogic.Services;
using BookShop.ApplicationLogic.Model;
using BookShop.Models.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using DocumentFormat.OpenXml.Vml;



namespace BookShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AdminServices adminServices;
        public AdminController(UserManager<IdentityUser> userManager, AdminServices adminServices, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.adminServices = adminServices;
            this.roleManager = roleManager;
        }
        public ActionResult Index()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                if (userId == null)
                {
                    return BadRequest("Null");
                }

                var admin = adminServices.GetAdminByAdminId(userId);

                var BookList = adminServices.GetBookList();

                return View(new AdminBooksViewModel { Admin = admin, Books = BookList });
            }
            catch (Exception)
            {
                return BadRequest("aici se blocheaza");
            }
        }

        public ActionResult OutOfStock()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                if (userId == null)
                {
                    return BadRequest("Null");
                }

                var admin = adminServices.GetAdminByAdminId(userId);

                var BookList = adminServices.GetBookList();

                return View(new AdminBooksViewModel { Admin = admin, Books = BookList });
            }
            catch (Exception)
            {
                return BadRequest("aici se blocheaza");
            }
        }


        [HttpPost]
        public IActionResult AddBook([FromForm]AdminAddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string image = "";
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var memoryStream = new MemoryStream())
            {
                model.ImageFile.CopyTo(memoryStream);
                image = Convert.ToBase64String(memoryStream.ToArray());
            }

            var userId = userManager.GetUserId(User);
            adminServices.addBook(userId, model.Name, model.Price, model.Description, image, model.Stock, model.Category);
            return RedirectToAction("Index");
 

        }
        [HttpGet]
        public IActionResult AddBook([FromRoute] Book Book)
        {
            var BookVM = new AdminAddBookViewModel { Name = Book.Name, Price = Book.Price, Description = Book.Description, Stock = Book.Stock, Category = Book.Category};
            return View(BookVM);

        }

        [HttpPost]
        public IActionResult DeleteBook([FromForm]AdminDeleteBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);

            adminServices.deleteBook(userId, model.Id);
            return Redirect(Url.Action("Index", "Admin"));
            // return Redirect(Url.Action("AddBook", "Admin"));

        }
        [HttpGet]
        public IActionResult DeleteBook([FromRoute]string id)
        {
            var Book = adminServices.GetBookbyId(id).Single();
            var BookVM = new AdminDeleteBookViewModel { Id = Book.Id};
            return View(BookVM);

        }

        [HttpPost]
        public IActionResult EditBook([FromForm]AdminEditBookView model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);

            adminServices.editBook(userId, model.Id, model.Name, model.Price, model.Description, model.Stock, model.Category);
            return RedirectToAction("Index");
            // return Redirect(Url.Action("Index", "Admin"));
        }

        [HttpGet]
        public IActionResult EditBook([FromRoute]string id)
        {
            var Book = adminServices.GetBookbyId(id).Single();
            var BookVM = new AdminEditBookView { Id = Book.Id, Name = Book.Name, Price = Book.Price, Description = Book.Description, Stock = Book.Stock, Category = Book.Category };
            return View(BookVM);

        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole { Name = model.roleName };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

            }
      
            return View(model);

        }

    }
    
}

