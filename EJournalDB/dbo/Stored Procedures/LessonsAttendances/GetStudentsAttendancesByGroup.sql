CREATE PROCEDURE [EJournal].[GetStudentsAttendancesByGroup] @GroupId INT
AS
SELECT L.[Id],
	L.DateLesson,
	L.Topic,
	S.Id IdStudent,
	S.Name,
	S.Surname,
	A.IsPresence
FROM [EJournal].[Lessons] L
JOIN [EJournal].[Groups] G ON G.Id = L.IdGroup
LEFT JOIN [EJournal].Attendances A ON A.IdLesson = L.Id
LEFT JOIN [EJournal].Students S ON A.IdStudent = S.Id
WHERE G.Id = @GroupId
ORDER BY L.DateLesson DESC