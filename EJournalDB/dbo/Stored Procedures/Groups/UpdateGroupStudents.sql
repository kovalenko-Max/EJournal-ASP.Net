CREATE PROCEDURE [EJournal].[UpdateGroupStudents]
	@IdGroup int,
	@NameGroup NVARCHAR(100),
	@IdCourse INT,
	@IdsAddStudent as [EJournal].[GroupIdsStudentsIds] readonly,
	@IdsDeleteStudent as [EJournal].[GroupIdsStudentsIds] readonly
AS

UPDATE [EJournal].[Groups]
SET Name = @NameGroup
	,IdCourse = @IdCourse
WHERE Id = @IdGroup

DELETE from [EJournal].[GroupStudents]
  where IdGroup = @IdGroup and IdStudents in 
  (
	select IdStudents from @IdsDeleteStudent
  )

insert into [EJournal].[GroupStudents] (IdGroup, IdStudents)
select * from @IdsAddStudent