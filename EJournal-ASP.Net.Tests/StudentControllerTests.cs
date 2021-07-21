using EJournal_ASP.Net.Tests.Mocks;
using EJournalDAL.Models;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace EJournal_ASP.Net.Tests
{
    [TestFixture]
    public class StudentControllerTests
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

        [TestCase(3)]
        public void GetAllAsync_WhenValidValuePassed_ShouldReturnAllStudentsAsyncTests(int studentsCount)
        {
            List<Student> students = new List<Student>();

            for (int i = 1; i <= studentsCount; ++i)
            {
                students.Add(Mock.GetStudentMock(i));
            }

            _sharedDatabaseFixture.FillStudentsTable(students);

            string expected = _serializationHelper.StudentJsonSerialize(students);
            var queryResult = _client.GetAsync("/Student").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2)]
        public void GetStudentByIdAsync_WhenValidValuePassed_ShouldReturnStudentByIdAsyncTests(int studentsCount, int idStudent)
        {
            List<Student> students = new List<Student>();

            for (int i = 1; i <= studentsCount; ++i)
            {
                students.Add(Mock.GetStudentMock(i));
            }

            _sharedDatabaseFixture.FillStudentsTable(students);

            List<Student> resultStudent = new List<Student>() { students[idStudent - 1] };
            string expected = _serializationHelper.StudentJsonSerialize(resultStudent);
            var queryResult = _client.GetAsync($"/Student/{idStudent}").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }
    }
}
