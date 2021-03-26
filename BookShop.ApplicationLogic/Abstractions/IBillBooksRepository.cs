using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface IBillBooksRepository: IRepository<BillBooks>
    {
        BillBooks GetBillById(Guid orderId);
        IEnumerable<BillBooks> GetBillByBillId(Guid billId);
    }
}
