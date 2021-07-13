CREATE PROCEDURE [EJournal].[AddCommentToStudent] @CommentType NVARCHAR(100),
	@Comment NVARCHAR(255),
	@StudentCommentVarible
AS
[EJournal].[StudentsComment] READONLY AS

DECLARE @IdComment INT
DECLARE @StudentsComment AS [EJournal].[StudentsComment]

INSERT INTO @StudentsComment
SELECT *
FROM @StudentCommentVarible

INSERT INTO [EJournal].Comments (
	[CommentText],
	CommentType
	)
VALUES (
	@Comment,
	@CommentType
	)

SET @IdComment = SCOPE_IDENTITY()

UPDATE @StudentsComment
SET IdComment = @IdComment

INSERT INTO [EJournal].StudentsComments (
	IdStudent,
	IdComment
	)
SELECT IdStudent,
	IdComment
FROM @StudentsComment

RETURN @IdComment