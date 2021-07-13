CREATE PROCEDURE [EJournal].[DeleteStudentExercise] @Id INT
AS
DELETE [EJournal].StudentsExercises
WHERE IdExercise = @Id

DELETE [EJournal].Exercises
WHERE Id = @Id