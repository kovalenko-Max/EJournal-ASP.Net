CREATE PROCEDURE [EJournal].[DeleteStudentsFromGroup]
	@IdsStudent as [EJournal].[GroupIdsStudentsIds] readonly
AS

CREATE table #IdsStudent (IdGroup int, IdStudent int)
insert into #IdsStudent(IdGroup, IdStudent) select * from @IdsStudent
DELETE from [EJournal].[GroupStudents]
	--where [EJournal].[GroupStudents].IdGroup = #IdsStudent.IdGroup and IdStudents = #IdsStudent.IdStudent


