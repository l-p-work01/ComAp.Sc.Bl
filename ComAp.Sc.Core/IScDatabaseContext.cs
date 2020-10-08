using ComAp.Sc.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ComAp.Sc.Core
{
    public interface IScDatabaseContext
    {
        DbSet<Comment> Comment { get; set; }
    }
}
