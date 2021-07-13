CREATE PROCEDURE [EJournal].[DeleteLessonAndStudentsAttendances] @Id INT
AS
DELETE [EJournal].Attendances
WHERE IdLesson = @Id

DELETE [EJournal].Lessons
WHERE Id = @Id