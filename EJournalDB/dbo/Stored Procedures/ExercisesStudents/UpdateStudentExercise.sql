CREATE PROCEDURE [EJournal].[UpdateStudentExercise] @Id INT,
	@IdGroup INT,
	@Description NVARCHAR(250),
	@ExerciseType NVARCHAR(250),
	@Deadline DATETIME,
	@StudentExercise
AS
[EJournal].[StudentExercise] Readonly AS

UPDATE [EJournal].[Exercises]
SET Description = @Description,
	Deadline = @Deadline,
	ExerciseType = @ExerciseType
WHERE Exercises.Id = @Id

MERGE [EJournal].[StudentsExercises] AS SE
USING @StudentExercise AS SEV
	ON SEV.IdStudent = SE.IdStudent
		AND SEV.IdExercise = SE.IdExercise
WHEN MATCHED
	THEN
		UPDATE
		SET SE.Point = SEV.Points;