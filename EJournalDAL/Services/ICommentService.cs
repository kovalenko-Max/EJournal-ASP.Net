using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsByStudentId(int studentId);
        Task<bool> AddComment(Comment commet, int studentId);
        Task<bool> UpdateComment(Comment comment);
        Task<bool> DeleteComment(int commentId);
    }
}
