using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.EFDataAccess
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }
        public Admin GetAdminByAdminId(Guid UserId)
        {
            return dbContext.Admins.Where(a => a.Id == UserId).FirstOrDefault();
        }
        
    }
}
