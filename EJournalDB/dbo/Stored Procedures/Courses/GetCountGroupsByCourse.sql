CREATE PROCEDURE [EJournal].[GetCountGroupsByCourse] @Id INT
AS
SELECT Count(G.Id)
FROM [EJournal].Groups G
WHERE G.IdCourse = @Id