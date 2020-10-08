using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComAp.Sc.Ws.Models;
using ComAp.Sc.Core.Repositories;

namespace ComAp.Sc.Ws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComment()
        {
            var dbComments = await commentRepository.GetCommentsAsync();
            var comments = new List<Comment>();
            foreach (var comment in dbComments)
            {
                comments.Add(new Comment()
                {
                    CommentId = comment.CommentId, CommentText = comment.CommentText, Datetime = comment.Datetime
                }); 
            }
            return comments;
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {

            var dbComment = await commentRepository.GetCommentByIdAsync(id);
            if (dbComment == null)
            {
                return NotFound();
            }
            var comment = new Comment()
            {
                CommentId = dbComment.CommentId,
                CommentText = dbComment.CommentText,
                Datetime = dbComment.Datetime
            };
            return comment;
        }

        // POST: api/Comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            var commentId = await commentRepository.AddCommentAsync(new Core.Models.Comment() { CommentText = comment.CommentText, Datetime = comment.Datetime });
            return CreatedAtAction("GetComment", 
                                    new { id = commentId }, 
                                    new Comment
                                    {
                                        CommentText = comment.CommentText,
                                        CommentId = commentId,
                                        Datetime = comment.Datetime
                                    });
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            if (id == 0)
                return BadRequest();

            var dbComment = await commentRepository.GetCommentByIdAsync(id);
            if (dbComment == null)
            {
                return NotFound();
            }

            await commentRepository.RemoveCommentWithIdAsync(id);
            return NoContent();         
        }
    }
}
