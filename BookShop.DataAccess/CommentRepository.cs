using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
using BookShop.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.DataAccess
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BookShopDBContext dBContext) : base(dBContext)
        {

        }

        public IEnumerable<Comment> GetCommentByBookId(Guid BookId)
        {
            return dbContext.Comments.Where(a => a.BookId == BookId).AsEnumerable();
        }

        public Comment GetCommentById(Guid commentId)
        {
            return dbContext.Comments.Where(a => a.Id == commentId).FirstOrDefault();
        }

        public IEnumerable<Comment> GetCommentByUserId(Guid userId)
        {
            return dbContext.Comments.Where(a => a.Id == userId).AsEnumerable(); 
        }
    }
}
