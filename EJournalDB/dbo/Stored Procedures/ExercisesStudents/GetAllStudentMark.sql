CREATE PROCEDURE [EJournal].[GetAllStudentMark]
AS
SELECT [IdStudent], [IdExercise], [Point]
FROM [EJournal].[StudentsExercises]