CREATE PROCEDURE [EJournal].[DeleteStudentsFromGroup] @IdsStudent
AS
[EJournal].[GroupIdsStudentsIds] readonly AS

CREATE TABLE #IdsStudent (
	IdGroup INT,
	IdStudent INT
	)

INSERT INTO #IdsStudent (
	IdGroup,
	IdStudent
	)
SELECT *
FROM @IdsStudent

DELETE
FROM [EJournal].[GroupStudents]
	--where [EJournal].[GroupStudents].IdGroup = #IdsStudent.IdGroup and IdStudents = #IdsStudent.IdStudent