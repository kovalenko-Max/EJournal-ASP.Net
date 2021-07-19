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

        [TestCase(3, 2)]
        public void GetExercisesByGroupIdAsync_WhenValidValuePassed_ShouldReturnExerciseByIdGroupAsyncTests(int exercisesCount, int idGroup)
        {
            Group group = Mock.GetGroupMock(idGroup);
            List<Exercise> excercises = new List<Exercise>();
            List<Student> students = new List<Student>();

            for (int i = 1; i <= exercisesCount; ++i)
            {
                students.Add(Mock.GetStudentMock(i));
            }

            for (int i = 1; i <= exercisesCount; ++i)
            {
                excercises.Add(Mock.GetExerciseMock(i, group, students));
                excercises[i - 1].IdGroup = group.Id;
            }

            _sharedDatabaseFixture.FillStudentsTable(students);
            _sharedDatabaseFixture.FillGroupsTable(new List<Group>() { group });
            _sharedDatabaseFixture.FillExercisesTable(excercises);

            string expected = _serializationHelper.ExerciseJsonSerialize(excercises);
            var queryResult = _client.GetAsync($"/Exercise/idGroup/{idGroup}").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }
    }
}
