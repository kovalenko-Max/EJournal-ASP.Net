using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService, ILogger<CommentController> logger)
        {
            _commentService = commentService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Comment>> GetCommentsByStudentIdAsync(int studentId)
        {
            return await _commentService.GetCommentsByStudentId(studentId);
        }

        [HttpPost]
        public async Task<bool> AddAsync(Comment comment, int studentId)
        {
            return await _commentService.AddComment(comment, studentId);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Comment comment)
        {
            return await _commentService.UpdateComment(comment);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int commentId)
        {
            return await _commentService.DeleteComment(commentId);
        }
    }
}
