using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface IUserRepository: IRepository<User>
    {
        User GetUserById(Guid userId);
    }
}
