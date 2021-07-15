CREATE PROCEDURE [EJournal].[AddCourse] @Name NVARCHAR(100)
AS
DECLARE @IdCourese INT

INSERT INTO [EJournal].[Courses] (Name)
OUTPUT INSERTED.Id
VALUES (@Name)

SET @IdCourese = SCOPE_IDENTITY()

RETURN @IdCourese