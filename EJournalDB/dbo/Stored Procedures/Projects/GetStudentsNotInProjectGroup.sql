CREATE PROCEDURE [EJournal].[GetStudentsNotInProjectGroup] @IdProjectGroup INT
AS
SELECT DISTINCT s.Id,
	s.Name,
	s.Surname,
	s.Phone,
	s.Email,
	s.Git,
	s.City,
	s.Ranking,
	s.TeacherAssessment,
	s.AgreementNumber,
	s.IsDelete
FROM [EJournal].[Students] AS s
WHERE S.IsDelete = 0
	AND Id NOT IN (
		SELECT IdStudent
		FROM [EJournal].StudetsProjectGroup
		WHERE IdProjectGroup = @IdProjectGroup
		)
ORDER BY S.Name