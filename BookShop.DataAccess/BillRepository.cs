using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using BookShop.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShop.EFDataAccess
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }


        public Bill GetBillByBillId(Guid orderId)
        {
            return dbContext.Bills.Where(a => a.Id == orderId).FirstOrDefault();
        }

        public IEnumerable<Bill> GetBillByUserId(Guid userId)
        {
            return dbContext.Bills.Where(a => a.UserId == userId).AsEnumerable();
        }

      
    }
}
