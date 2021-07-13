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
    }
}
