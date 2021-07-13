CREATE PROCEDURE [EJournal].[AddGroup] @Name NVARCHAR(100),
	@IdCourse INT
AS
INSERT INTO [EJournal].[Groups] (
	[Name],
	IdCourse
	)
OUTPUT INSERTED.Id
VALUES (
	@Name,
	@IdCourse
	)