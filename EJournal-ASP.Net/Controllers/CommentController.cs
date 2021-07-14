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

        [HttpGet("idStudent/{id}")]
        public async Task<IEnumerable<Comment>> GetCommentsByStudentIdAsync(int idStudent)
        {
            return await _commentService.GetCommentsByStudentId(idStudent);
        }
        
        [HttpGet("id/{id}")]
        public async Task<IEnumerable<Comment>> GetCommentsByIdAsync(int idStudent)
        {
            return await _commentService.GetCommentsByStudentId(idStudent);
        }

        [HttpPost]
        public async Task<int> AddAsync(Comment comment, int idStudent)
        {
            return await _commentService.AddComment(comment, idStudent);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Comment comment)
        {
            return await _commentService.UpdateComment(comment);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int idComment)
        {
            return await _commentService.DeleteComment(idComment);
        }
    }
}
