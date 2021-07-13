CREATE PROCEDURE [EJournal].[AddStudentsAttendance] @Topic NVARCHAR(250),
	@DateLesson DATETIME,
	@IdGroup INT,
	@StudentAttendanceVariable
AS
[EJournal].[StudentAttendance] READONLY AS

DECLARE @IdLesson INT
DECLARE @StudentAttendance AS [EJournal].[StudentAttendance]

INSERT INTO @StudentAttendance
SELECT *
FROM @StudentAttendanceVariable

INSERT INTO [EJournal].Lessons (
	Topic,
	DateLesson,
	IdGroup
	)
VALUES (
	@Topic,
	@DateLesson,
	@IdGroup
	)

SET @IdLesson = SCOPE_IDENTITY()

UPDATE @StudentAttendance
SET LessonsIds = @IdLesson

INSERT INTO [EJournal].[Attendances] (
	IdLesson,
	IdStudent,
	IsPresence
	)
SELECT LessonsIds,
	StudentId,
	isPresense
FROM @StudentAttendance

RETURN @IdLesson