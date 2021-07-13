CREATE PROCEDURE [EJournal].[GetStudentsNotAreInGroup] @IdGroup INT
AS
SELECT S.[Id],
	S.[Name],
	S.[Surname],
	S.[Email],
	S.[Phone],
	S.[Git],
	S.[City],
	S.[Ranking],
	S.[AgreementNumber]
FROM [EJournal].[Students] S
WHERE S.IsDelete = 0
	AND Id NOT IN (
		SELECT IdStudents
		FROM [EJournal].GroupStudents
		WHERE IdGroup = @IdGroup
		)
ORDER BY S.Name