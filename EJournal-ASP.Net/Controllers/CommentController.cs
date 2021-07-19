using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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

        [HttpGet("/byId/{idStudent}")]
        public async Task<IEnumerable<Comment>> GetCommentsByStudentIdAsync(int idStudent)
        {
            IEnumerable<Comment> result = null;

            try
            {
                if (idStudent > 0)
                {
                    _logger.LogInformation("GetCommentsByStudentIdAsync() was called");

                    result = await _commentService.GetCommentsByStudentId(idStudent);
                }
                else
                {
                    _logger.LogInformation($"Id ({idStudent}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result != null)
            {
                _logger.LogInformation($"Comments of student ({idStudent}) were received");
            }

            return result;
        }
        
        //[HttpGet("id/{id}")]
        //public async Task<IEnumerable<Comment>> GetCommentsByIdAsync(int idStudent)
        //{
        //    return await _commentService.GetCommentsByStudentId(idStudent);
        //}

        [HttpPost]
        public async Task<int> AddAsync(Comment comment, int idStudent)
        {
            int result = 0;

            try
            {
                if (idStudent > 0)
                {
                    _logger.LogInformation("AddAsync() was called");

                    result = await _commentService.AddComment(comment, idStudent);
                }
                else
                {
                    _logger.LogInformation($"Id ({idStudent}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result > 0)
            {
                _logger.LogInformation($"Comment was added");
            }

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Comment comment)
        {
            _logger.LogInformation("UpdateAsync() was called");

            return await _commentService.UpdateComment(comment);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int idComment)
        {
            bool result = false;

            try
            {
                if (idComment > 0)
                {
                    _logger.LogInformation("DeleteAsync() was called");

                    result = await _commentService.DeleteComment(idComment);
                }
                else
                {
                    _logger.LogInformation($"Id ({idComment}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result)
            {
                _logger.LogInformation($"Comment ({idComment}) was deleted");
            }

            return result;
        }
    }
}
