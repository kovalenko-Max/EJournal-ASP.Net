CREATE PROCEDURE [EJournal].[UpdateProjectGroup] @Id INT,
	@Name NVARCHAR(100),
	@Mark INT,
	@Students
AS
[EJournal].[StudentsIds] READONLY AS

UPDATE [EJournal].[ProjectGroups]
SET Name = @Name,
	Mark = @Mark
WHERE Id = @Id

DELETE
FROM StudetsProjectGroup
WHERE IdProjectGroup = @Id

INSERT INTO StudetsProjectGroup (
	IdProjectGroup,
	IdStudent
	)
SELECT IdProjectGroup,
	Idstudent
FROM @Students