CREATE PROCEDURE [EJournal].[GetExercisesByGroup] @IdGroup INT
AS
SELECT E.Id,
	E.Description,
	E.Deadline,
	E.IdGroup,
	E.ExerciseType,
	S.Id IdStudent,
	S.Name,
	S.Surname,
	SE.Point
FROM [EJournal].Exercises E
INNER JOIN [EJournal].[Groups] G ON G.Id = E.IdGroup
LEFT JOIN [EJournal].StudentsExercises SE ON E.Id = SE.IdExercise
LEFT JOIN [EJournal].Students S ON SE.IdStudent = S.Id
WHERE G.Id = @IdGroup
ORDER BY E.Deadline