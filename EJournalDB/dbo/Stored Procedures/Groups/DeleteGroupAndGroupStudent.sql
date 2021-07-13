CREATE PROCEDURE [EJournal].[DeleteGroupAndGroupStudent] @IdGroup INT
AS
DELETE
FROM [EJournal].[GroupStudents]
WHERE IdGroup = @IdGroup;

DELETE
FROM Groups
WHERE Id = @IdGroup