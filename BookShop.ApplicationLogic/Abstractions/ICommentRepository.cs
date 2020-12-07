using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace BookShop.ApplicationLogic.Abstractions
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Comment GetCommentById(Guid commentId);
        IEnumerable<Comment> GetCommentByBookId(Guid BookId);
        IEnumerable<Comment> GetCommentByUserId(Guid userId);

    }
}
