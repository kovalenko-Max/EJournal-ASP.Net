CREATE PROCEDURE [EJournal].[GetAllGroups]
AS
SELECT G.Id,
	G.Name,
	COUNT(S.Id) StudentsCount,
	C.Id AS IdCourse,
	C.Name AS NameCourse,
	G.IsFinish
FROM [EJournal].[Groups] G
LEFT JOIN [EJournal].Courses C ON C.Id = G.IdCourse
LEFT JOIN [EJournal].[GroupStudents] GS ON G.Id = GS.IdGroup
LEFT JOIN (
	SELECT S.Id
	FROM [EJournal].Students S
	WHERE S.IsDelete = 0
	) S ON S.Id = GS.IdStudents
WHERE G.IsDelete = 0
GROUP BY G.id,
	G.Name,
	C.Id,
	G.IsFinish,
	C.Name