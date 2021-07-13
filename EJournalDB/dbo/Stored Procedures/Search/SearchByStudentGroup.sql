CREATE PROCEDURE [EJournal].[SearchByStudentGroup] @Name NVARCHAR(50)
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
WHERE S.IsDelete = 0
	AND G.[Name] LIKE ('%' + LTRIM(RTRIM(@Name)) + '%')