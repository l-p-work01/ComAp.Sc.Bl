using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ComAp.Sc.Core.Models;

namespace ComAp.Sc.Core.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<int> AddCommentAsync(Comment entity);
        Task RemoveCommentWithIdAsync(int commentId);
    }
}
