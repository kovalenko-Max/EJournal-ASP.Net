CREATE PROCEDURE [EJournal].[DeleteGroup] @IdGroup INT
AS
DELETE
FROM [EJournal].[Groups]
WHERE Id = @IdGroup