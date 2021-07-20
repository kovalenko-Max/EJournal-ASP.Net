using System;
using System.Diagnostics;
using DataModels;
using LinqToDB.Configuration;
using EJournalDAL.Models;
using LinqToDB;
using System.Collections.Generic;
using System.Data;

namespace EJournal_ASP.Net.Tests
{
    public class SharedDatabaseFixture : IDisposable
    {
        private const string _testDBName = "EJournalDB.Test";
        private string _connectionString { get; }

        public EJournalDB DataConnection { get; set; }

        public SharedDatabaseFixture()
        {
            _connectionString = @$"Server=.;Database={_testDBName};ConnectRetryCount=0;Integrated Security=True";

            PublishTestDB();
            CreateContext();
        }

        internal void PublishTestDB()
        {
            string Path = System.IO.Directory.GetCurrentDirectory();
            string solutionPath = Path.Replace(@"\EJournal-ASP.Net.Tests\bin\Debug\net5.0", "");
            string projectPath = Path.Replace(@"\bin\Debug\net5.0", "");
            string dacpacFilePath = @$"{solutionPath}\EJournalDB\bin\Debug\EJournalDB.dacpac";

            ProcessStartInfo procStartInfo = new ProcessStartInfo();
            procStartInfo.FileName = projectPath + @"\sqlpackage\sqlpackage.exe";
            procStartInfo.Arguments = @$"/sf:{dacpacFilePath} /a:Publish /p:CreateNewDatabase=true /tsn:. /tdn:{_testDBName} /v:DbType=production  /v:DbVer=1.0.0 /p:ScriptNewConstraintValidation=False /p:GenerateSmartDefaults=True /of:True /p:BlockOnPossibleDataLoss=False";

            using (Process process = new Process())
            {
                process.StartInfo = procStartInfo;
                process.Start();
                process.WaitForExit();
            }
        }

        public void Dispose() => DataConnection.Dispose();

        private void CreateContext(EJournalDB transaction = null)
        {
            var builder = new LinqToDbConnectionOptionsBuilder();
            builder.UseSqlServer(_connectionString);

            DataConnection = new EJournalDB(builder.Build());
        }

        public void FillCoursesTable(List<Course> courses)
        {
            foreach (var course in courses)
            {
                DataConnection.Courses
                .Value(c => c.Name, course.Name)
                .Insert();
            }
        }

        public void FillCommentsTable(Student student, List<Comment> comments)
        {
            foreach (var comment in comments)
            {
                DataConnection.Comments
                .Value(c => c.CommentText, comment.CommentText)
                .Value(c => c.CommentType, comment.CommentType)
                .Insert();

                DataConnection.StudentsComments
                    .Value(sc => sc.IdComment, comment.Id)
                    .Value(sc => sc.IdStudent, student.Id)
                    .Insert();
            }

            DataConnection.Students
                .Value(s => s.Name, student.Name)
                .Value(s => s.Surname, student.Surname)
                .Value(s => s.Email, student.Email)
                .Value(s => s.Phone, student.Phone)
                .Value(s => s.Git, student.Git)
                .Value(s => s.City, student.City)
                .Value(s => s.TeacherAssessment, student.TeacherAssessment)
                .Value(s => s.Ranking, student.Ranking)
                .Value(s => s.AgreementNumber, student.AgreementNumber)
                .Insert();
        }

        public void FillCommentsTable(List<Comment> comments)
        {
            foreach (var comment in comments)
            {
                DataConnection.Comments
                .Value(c => c.CommentText, comment.CommentText)
                .Value(c => c.CommentType, comment.CommentType)
                .Insert();
            }
        }

        public void FillLessonsTable(List<Lesson> lessons)
        {
            foreach (var lesson in lessons)
            {
                DataConnection.Lessons
                .Value(l => l.Topic, lesson.Topic)
                .Value(l => l.DateLesson, lesson.DateLesson)
                .Value(l => l.IdGroup, lesson.IdGroup)
                .Insert();
            }
        }

        public void FillGroupsTable(List<Group> groups)
        {
            foreach (var group in groups)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IdGroup");
                dt.Columns.Add("IdStudents");

                foreach (var s in group.Students)
                {
                    dt.Rows.Add(new object[] { null, s.Id });
                }

                DataConnection.AddGroupWithStudents(group.Name, group.Course.Id, dt);
            }
        }

        public void FillStudentsTable(List<Student> students)
        {
            foreach (var student in students)
            {
                DataConnection.Students
                .Value(s => s.Name, student.Name)
                .Value(s => s.Surname, student.Surname)
                .Value(s => s.Email, student.Email)
                .Value(s => s.Phone, student.Phone)
                .Value(s => s.Git, student.Git)
                .Value(s => s.City, student.City)
                .Value(s => s.TeacherAssessment, student.TeacherAssessment)
                .Value(s => s.Ranking, student.Ranking)
                .Value(s => s.AgreementNumber, student.AgreementNumber)
                .Insert();
            }
        }

        public void FillExercisesTable(List<Exercise> exercises)
        {

            //foreach (var exercise in exercises)
            //{
            //    DataConnection.Exercises
            //    .Value(e => e.Description, exercise.Description)
            //    .Value(e => e.IdGroup, exercise.IdGroup)
            //    .Value(e => e.Deadline, exercise.Deadline)
            //    .Value(e => e.ExerciseType, exercise.ExerciseType.ToString())
            //    .InsertAsync();
            //}
        }
    }
}
