using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string CommentType { get; set; }

        public Comment()
        {
        }

        public Comment(string commentColumn, string commentType)
        {
            CommentText = commentColumn;
            CommentType = commentType;
        }

        public override string ToString()
        {
            return CommentText;
        }

        public override bool Equals(object obj)
        {
            return obj is Comment comment &&
                   Id == comment.Id &&
                   CommentText == comment.CommentText &&
                   CommentType == comment.CommentType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
