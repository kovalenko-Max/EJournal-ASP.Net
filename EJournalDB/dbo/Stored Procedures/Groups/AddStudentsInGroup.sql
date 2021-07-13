CREATE PROCEDURE [EJournal].[AddStudentsInGroup] @IdsStudent
AS
[EJournal].[GroupIdsStudentsIds] readonly AS

INSERT INTO [EJournal].[GroupStudents] (
	IdGroup,
	IdStudents
	)
SELECT *
FROM @IdsStudent