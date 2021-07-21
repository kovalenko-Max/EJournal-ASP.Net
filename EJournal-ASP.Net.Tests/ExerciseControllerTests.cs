using EJournal_ASP.Net.Tests.Mocks;
using EJournalDAL.Models;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace EJournal_ASP.Net.Tests
{
    [TestFixture]
    public class ExerciseControllerTests
    {
        private SharedDatabaseFixture _sharedDatabaseFixture;
        private HttpClient _client;
        private CustomWebApplicationFactory _factory;
        private System.Uri _baseURL = new System.Uri("http://localhost:39278");
        private TestServer _server;
        private SerializationHelper _serializationHelper;

        [OneTimeSetUp]
        public void Setup()
        {
            _sharedDatabaseFixture = new SharedDatabaseFixture();
            _factory = new CustomWebApplicationFactory();

            _client = _factory.CreateClient();
            _client.BaseAddress = _baseURL;

            _serializationHelper = new SerializationHelper();
        }

        [TestCase(3, 1)]
        public void GetExercisesByGroupIdAsync_WhenValidValuePassed_ShouldReturnExerciseByIdGroupAsyncTests(int exercisesCount, int idGroup)
        {
            Group group = Mock.GetGroupMock(idGroup);
            List<Student> students = new List<Student>();
            group.Students = students;

            for (int i = 1; i <= exercisesCount; ++i)
            {
                students.Add(Mock.GetStudentMock(i));
            }

            Exercise excercise = Mock.GetExerciseMock(1, group, group.Students);

            _sharedDatabaseFixture.FillStudentsTable(students);
            _sharedDatabaseFixture.FillGroupsTable(new List<Group>() { group });
            _sharedDatabaseFixture.FillExercisesTable(excercise);

            foreach(var sm in excercise.StudentMarks)
            {
                sm.Student.Email = null;
                sm.Student.Phone = null;
                sm.Student.Git = null;
                sm.Student.City = null;
                sm.Student.TeacherAssessment = 0;
                sm.Student.Ranking = 0;
                sm.Student.AgreementNumber = null;
            }

            string expected = _serializationHelper.ExerciseJsonSerialize(new List<Exercise>() { excercise });
            var queryResult = _client.GetAsync($"/Exercise/{idGroup}").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }
    }
}
