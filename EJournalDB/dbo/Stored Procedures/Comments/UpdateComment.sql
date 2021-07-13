CREATE PROCEDURE [EJournal].[UpdateComment] @Id INT,
	@Comments NVARCHAR(255),
	@CommentType NVARCHAR(100)
AS
UPDATE [EJournal].[Comments]
SET [CommentText] = @Comments,
	CommentType = @CommentType
WHERE Id = @Id