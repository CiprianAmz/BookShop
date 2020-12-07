using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using BookShop.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShop.EFDataAccess
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }

        public Rating GetRating(Guid ratingId)
        {
            return dbContext.Ratings.Where(a => a.Id == ratingId).FirstOrDefault();
        }

        public IEnumerable<Rating> GetRatingByBookId(Guid BookId)
        {
            return dbContext.Ratings.Where(a => a.BookId == BookId).AsEnumerable();
        }
    }
}
