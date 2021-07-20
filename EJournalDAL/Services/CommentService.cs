using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataModels.EJournalDBStoredProcedures;

namespace EJournalDAL.Services
{
    public class CommentService : ICommentService
    {
        private readonly EJournalDB _dbConnection;
        private readonly IMapper _mapper;

        public CommentService(IMapper mapper, EJournalDB dbConnection)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }

        public async Task<int> AddComment(Comment comment, int studentId)
        {
            var result =_dbConnection.AddComment(studentId, comment.CommentText, comment.CommentType).FirstOrDefault();

            return result.Id;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByStudentId(int studentId)
        {
            var comments = new List<EJournal_Comment>(_dbConnection.GetCommentsByStudent(studentId));

            return _mapper.Map<List<Comment>>(comments);
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            int result = _dbConnection.DeleteComment(commentId);

            return result > 0;
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            int result = _dbConnection.UpdateComment(comment.Id, comment.CommentText, comment.CommentType);

            return result > 0;
        }
    }
}
