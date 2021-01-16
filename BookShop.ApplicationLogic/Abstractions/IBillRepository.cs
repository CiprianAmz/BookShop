using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface IBillRepository : IRepository<Bill>
    {
        Bill GetBillByBillId(Guid orderId);
        IEnumerable<Bill> GetBillByUserId(Guid billId);
    }
}
