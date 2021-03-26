using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using BookShop.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShop.EFDataAccess
{
    public class BillBooksRepository : BaseRepository<BillBooks>, IBillBooksRepository
    {
        public BillBooksRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }


        public BillBooks GetBillById(Guid orderId)
        {
            return dbContext.BillBooks.Where(a => a.Id == orderId).FirstOrDefault();
        }

        public IEnumerable<BillBooks> GetBillByBillId(Guid billId)
        {
            return dbContext.BillBooks.Where(a => a.BillId== billId).AsEnumerable();
        }

      
    }
}
