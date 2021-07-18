using EJournalDAL.Models;
using NUnit.Framework;
using LinqToDB.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Tests
{
    [TestFixture]
    public class CourseControllerTests
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
        public void GetAllAsync_When_ShouldReturnAllCoursesAsync(int coursesCount)
        {
            List<Course> courses = new List<Course>();
            for (int i = 1; i <= coursesCount; ++i)
            {
                courses.Add(Mock.GetCourseMock(i));
            }

            _sharedDatabaseFixture.FillCoursesTable(courses);

            string expected = _serializationHelper.CourseJsonSerialize(courses);
            var queryResult = _client.GetAsync("/Course").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }
    }
}