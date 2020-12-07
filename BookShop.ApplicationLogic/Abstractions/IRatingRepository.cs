using System;
using System.Collections.Generic;
using System.Text;
using BookShop.ApplicationLogic.Model;
namespace BookShop.ApplicationLogic.Abstractions
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Rating GetRating(Guid ratingId);
        IEnumerable<Rating> GetRatingByBookId(Guid BookId);

    }
}
