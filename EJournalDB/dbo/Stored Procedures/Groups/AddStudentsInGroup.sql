CREATE PROCEDURE [EJournal].[AddStudentsInGroup]
	@IdsStudent as [EJournal].[GroupIdsStudentsIds] readonly
AS

insert into [EJournal].[GroupStudents] (IdGroup, IdStudents)
select * from @IdsStudent