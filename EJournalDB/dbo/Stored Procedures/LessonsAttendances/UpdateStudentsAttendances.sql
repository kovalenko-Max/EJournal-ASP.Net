CREATE PROCEDURE [EJournal].[UpdateStudentsAttendances] @StudentAttendance [EJournal].[StudentAttendance] READONLY,
	@Id INT,
	@Topic NVARCHAR(250),
	@DateLesson DATETIME
AS
UPDATE [EJournal].[Lessons]
SET DateLesson = @DateLesson,
	Topic = @Topic
WHERE Lessons.Id = @Id

MERGE [EJournal].[Attendances] AS A
USING @StudentAttendance AS SA
	ON SA.LessonsIds = A.IdLesson
		AND SA.StudentId = A.IdStudent
WHEN MATCHED
	THEN
		UPDATE
		SET A.IsPresence = SA.isPresense;