using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.EFDataAccess 
{
    public class BookShopDBContext : DbContext
    {
        public BookShopDBContext(DbContextOptions<BookShopDBContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    
    }
}

