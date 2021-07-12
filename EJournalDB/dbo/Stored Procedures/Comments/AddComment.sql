CREATE PROCEDURE [EJournal].[AddComment] @IdStudent INT,
	@Comments NVARCHAR(255),
	@CommentType NVARCHAR(100)
AS
DECLARE @IdComment INT

INSERT INTO [EJournal].[Comments] (
	[EJournal].[Comments].[CommentText],
	[EJournal].[Comments].[CommentType]
	)
OUTPUT INSERTED.Id
VALUES (
	@Comments,
	@CommentType
	)

SET @IdComment = SCOPE_IDENTITY()

INSERT INTO [EJournal].[StudentsComments] (
	IdComment,
	IdStudent
	)
VALUES (
	@IdComment,
	@IdStudent
	)

RETURN @IdComment;