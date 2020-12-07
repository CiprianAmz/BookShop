using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.ApplicationLogic.Abstractions
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Admin GetAdminByAdminId(Guid UserId);
    }
}
