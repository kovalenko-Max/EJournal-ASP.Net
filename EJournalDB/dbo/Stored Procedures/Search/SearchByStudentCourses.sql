CREATE PROCEDURE [EJournal].[SearchByStudentCourses] @Name NVARCHAR(50)
AS
SELECT s.[Id],
	s.[Name],
	s.[Surname],
	s.[Email],
	s.[Phone],
	s.[Git],
	s.[City],
	s.[Ranking],
	s.[AgreementNumber]
FROM [EJournal].[Students] S
LEFT JOIN [EJournal].[GroupStudents] GS ON GS.IdStudents = S.Id
LEFT JOIN [EJournal].[Groups] G ON G.Id = GS.IdGroup
LEFT JOIN [EJournal].[Courses] C ON C.Id = G.IdCourse
WHERE S.IsDelete = 0
	AND C.[Name] LIKE ('%' + LTRIM(RTRIM(@Name)) + '%')