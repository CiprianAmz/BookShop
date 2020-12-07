using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using BookShop.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShop.EFDataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }

        public User GetUserById(Guid userId)
        {
            return dbContext.Users.Where(a => a.Id == userId).FirstOrDefault();
        }
    }
}

