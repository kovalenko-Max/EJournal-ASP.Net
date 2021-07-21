CREATE PROCEDURE [EJournal].[AddExerciseToStudent] @IdGroup INT,
	@Description NVARCHAR(250),
	@ExerciseType NVARCHAR(250),
	@Deadline DATETIME,
	@StudentExerciseVariable
AS
[EJournal].[StudentExercise] Readonly AS

DECLARE @IdExercise INT
DECLARE @StudentExercise AS [EJournal].[StudentExercise]

INSERT INTO @StudentExercise
SELECT *
FROM @StudentExerciseVariable

INSERT INTO [EJournal].[Exercises] (
	IdGroup,
	Description,
	ExerciseType,
	Deadline
	)
VALUES (
	@IdGroup,
	@Description,
	@ExerciseType,
	@Deadline
	)

SET @IdExercise = SCOPE_IDENTITY()

UPDATE @StudentExercise
SET IdExercise = @IdExercise

INSERT INTO [EJournal].[StudentsExercises]
SELECT *
FROM @StudentExercise

RETURN @IdExercise