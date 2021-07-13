CREATE PROCEDURE [EJournal].[DeleteComment] @Id INT
AS
DELETE [EJournal].[Comments]
WHERE Id = @Id

DELETE [EJournal].[StudentsComments]
WHERE IdComment = @Id