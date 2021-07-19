using System;
using System.Diagnostics;
using DataModels;
using LinqToDB.Configuration;
using EJournalDAL.Models;
using LinqToDB;
using System.Collections.Generic;

namespace EJournal_ASP.Net.Tests
{
    public class SharedDatabaseFixture : IDisposable
    {
        private const string _testDBName = "EJournalDB.Test";
        private string _connectionString { get; }

        public EJournalDB DataConnection { get; set; }

        public SharedDatabaseFixture()
        {
            _connectionString = @$"Server=.\SQLEXPRESS;Database={_testDBName};ConnectRetryCount=0;Integrated Security=True";

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
            procStartInfo.Arguments = @$"/sf:{dacpacFilePath} /a:Publish /p:CreateNewDatabase=true /tsn:.\SQLEXPRESS /tdn:{_testDBName} /v:DbType=production  /v:DbVer=1.0.0 /p:ScriptNewConstraintValidation=False /p:GenerateSmartDefaults=True /of:True /p:BlockOnPossibleDataLoss=False";

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
            foreach(var course in courses)
            {
                DataConnection.Courses
                .Value(c => c.Name, course.Name)
                .Insert();
            }
        }
    }
}
