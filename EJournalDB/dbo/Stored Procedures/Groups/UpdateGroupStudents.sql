CREATE PROCEDURE [EJournal].[UpdateGroupStudents] @IdGroup INT,
	@NameGroup NVARCHAR(100),
	@IdCourse INT,
	@IdsAddStudent
AS
[EJournal].[GroupIdsStudentsIds] readonly,
	@IdsDeleteStudent AS [EJournal].[GroupIdsStudentsIds] readonly AS

UPDATE [EJournal].[Groups]
SET Name = @NameGroup,
	IdCourse = @IdCourse
WHERE Id = @IdGroup

DELETE
FROM [EJournal].[GroupStudents]
WHERE IdGroup = @IdGroup
	AND IdStudents IN (
		SELECT IdStudents
		FROM @IdsDeleteStudent
		)

INSERT INTO [EJournal].[GroupStudents] (
	IdGroup,
	IdStudents
	)
SELECT *
FROM @IdsAddStudent