﻿using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DataModels.EJournalDBDBStoredProcedures;

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

        public async Task<bool> AddComment(Comment comment, int studentId)
        {
            int result = _dbConnection.AddComment(comment.Id, comment.CommentText, comment.CommentType);

            return result > 0 ? true : false;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByStudentId(int studentId)
        {
            IEnumerable<EJournal_Comment> comments = new List<EJournal_Comment>(_dbConnection.GetCommentsByStudent(studentId));

            return _mapper.Map<List<Comment>>(comments);
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            int result = _dbConnection.DeleteComment(commentId);

            return result > 0 ? true : false;
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            int result = _dbConnection.UpdateComment(comment.Id, comment.CommentText, comment.CommentType);

            return result > 0 ? true : false;
        }
    }
}
