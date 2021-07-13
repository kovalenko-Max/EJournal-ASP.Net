CREATE PROCEDURE [EJournal].[AddGroupWithStudents] @NameGroup NVARCHAR(100),
	@IdCourse INT,
	@IdsStudent
AS
[EJournal].[GroupIdsStudentsIds] readonly AS

DECLARE @IdGroup INT
DECLARE @GroupStudentsCopy AS [EJournal].[GroupIdsStudentsIds]

INSERT INTO @GroupStudentsCopy
SELECT *
FROM @IdsStudent

INSERT INTO [EJournal].[Groups] (
	Name,
	IdCourse
	)
VALUES (
	@NameGroup,
	@IdCourse
	)

SET @IdGroup = SCOPE_IDENTITY()

UPDATE @GroupStudentsCopy
SET IdGroup = @IdGroup

INSERT INTO [EJournal].[GroupStudents] (
	IdGroup,
	IdStudents
	)
SELECT *
FROM @GroupStudentsCopy

RETURN @IdGroup