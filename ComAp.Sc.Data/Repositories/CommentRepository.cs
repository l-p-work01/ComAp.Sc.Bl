using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ComAp.Sc.Core.Models;
using ComAp.Sc.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ComAp.Sc.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class CommentRepository : ICommentRepository
    {
        private readonly ScDatabaseContext Context;

        public CommentRepository(ScDatabaseContext context)
        {
            this.Context = context;
        }
        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await Context.Comment.ToListAsync();
        }
        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            var comment = await Context.Comment.FindAsync(commentId);
            return comment;
        }

        public async Task<int> AddCommentAsync(Comment comment)
        {
            Context.Comment.Add(comment);
            await Context.SaveChangesAsync();
            var id = comment.CommentId;
            return id;
        }
        public async Task RemoveCommentWithIdAsync(int commentId)
        {
            var comment = await Context.Comment.FindAsync(commentId);
            if (comment != null)
            {
                Context.Comment.Remove(comment);
                await Context.SaveChangesAsync();
            }            
        }
    }
}
