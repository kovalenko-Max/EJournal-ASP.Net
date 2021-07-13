CREATE PROCEDURE [EJournal].[GetLessonsByGroup] @groupId INT
AS
SELECT L.[Id],
	L.[IdGroup],
	L.[DateLesson],
	L.[Topic]
FROM [EJournal].[Lessons] L
JOIN [EJournal].[Groups] G ON G.Id = L.IdGroup
WHERE G.Id = @groupId