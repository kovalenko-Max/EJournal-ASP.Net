CREATE PROCEDURE [EJournal].[DeleteProjectGroup] @Id INT
AS
DELETE [EJournal].[ProjectGroups]
WHERE Id = @Id