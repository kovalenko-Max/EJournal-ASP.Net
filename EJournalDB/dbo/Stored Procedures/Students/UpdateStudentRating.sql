CREATE PROCEDURE [EJournal].[UpdateStudentRating] @IdStudent INT
AS
DECLARE @AttendanceCoef INT
DECLARE @TestCoef INT
DECLARE @HomeWorkCoef INT
DECLARE @TeacherAssessmentCoef INT
DECLARE @ProjectGroupCoef INT
DECLARE @Rating INT

SET @AttendanceCoef = (
		SELECT sum(cast(IsPresence AS INT) * 100)
		FROM [EJournal].[Attendances]
		WHERE IdStudent = @IdStudent
		) / (
		SELECT COUNT(IsPresence)
		FROM [EJournal].[Attendances]
		WHERE IdStudent = @IdStudent
		)

IF @AttendanceCoef IS NULL
	SET @AttendanceCoef = 100
SET @TestCoef = (
		SELECT SUM(SE.Point)
		FROM [EJournal].StudentsExercises SE
		LEFT JOIN [EJournal].[Exercises] E ON E.Id = SE.IdExercise
		WHERE SE.IdStudent = @IdStudent
			AND E.Deadline < GETDATE()
			AND E.ExerciseType = 'Test'
		) / (
		SELECT COUNT(IdExercise)
		FROM [EJournal].StudentsExercises SE
		LEFT JOIN [EJournal].[Exercises] E ON E.Id = SE.IdExercise
		WHERE SE.IdStudent = @IdStudent
			AND E.Deadline < GETDATE()
			AND E.ExerciseType = 'Test'
		)

IF @TestCoef IS NULL
	SET @TestCoef = 100
SET @HomeWorkCoef = (
		SELECT SUM(SE.Point)
		FROM [EJournal].StudentsExercises SE
		LEFT JOIN [EJournal].[Exercises] E ON E.Id = SE.IdExercise
		WHERE SE.IdStudent = @IdStudent
			AND E.Deadline < GETDATE()
			AND E.ExerciseType = 'HomeWork'
		) / (
		SELECT COUNT(IdExercise)
		FROM [EJournal].StudentsExercises SE
		LEFT JOIN [EJournal].[Exercises] E ON E.Id = SE.IdExercise
		WHERE SE.IdStudent = @IdStudent
			AND E.Deadline < GETDATE()
			AND E.ExerciseType = 'HomeWork'
		)

IF @HomeWorkCoef IS NULL
	SET @HomeWorkCoef = 100
SET @TeacherAssessmentCoef = (
		SELECT TeacherAssessment
		FROM [EJournal].[Students]
		WHERE id = @IdStudent
		)

IF @TeacherAssessmentCoef IS NULL
	SET @TeacherAssessmentCoef = 100
SET @ProjectGroupCoef = (
		SELECT PG.Mark
		FROM [EJournal].[ProjectGroups] PG
		LEFT JOIN [EJournal].[StudetsProjectGroup] SPG ON SPG.IdProjectGroup = PG.ID
		WHERE SPG.IdStudent = @IdStudent
		)

IF @ProjectGroupCoef IS NULL
	SET @ProjectGroupCoef = 100
SET @Rating = @AttendanceCoef * 0.15 + @TestCoef * 0.2 + @HomeWorkCoef * 0.25 + @TeacherAssessmentCoef * 0.2 + @ProjectGroupCoef * 0.2

UPDATE [EJournal].[Students]
SET Ranking = @Rating

RETURN @Rating