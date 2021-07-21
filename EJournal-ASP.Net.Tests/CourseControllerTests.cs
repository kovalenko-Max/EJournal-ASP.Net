using EJournal_ASP.Net.Tests.Mocks;
using EJournalDAL.Models;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;

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

        [SetUp]
        public void Setup()
        {
            _sharedDatabaseFixture = new SharedDatabaseFixture();
            _factory = new CustomWebApplicationFactory();

            _client = _factory.CreateClient();
            _client.BaseAddress = _baseURL;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");

            _serializationHelper = new SerializationHelper();
        }

        [TestCase(3)]
        public void GetAllAsync_WhenValidValuePassed_ShouldReturnAllCoursesAsyncTests(int coursesCount)
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

        [TestCase(3, 2)]
        public void GetCourseByIdAsync_WhenValidValuePassed_ShouldReturnCourseByIdAsyncTests(int coursesCount, int id)
        {
            List<Course> courses = new List<Course>();

            for (int i = 1; i <= coursesCount; ++i)
            {
                courses.Add(Mock.GetCourseMock(i));
            }

            _sharedDatabaseFixture.FillCoursesTable(courses);

            List<Course> temp = new List<Course> (){courses[id - 1]};
            string expected = _serializationHelper.CourseJsonSerialize(temp);
            var queryResult = _client.GetAsync($"/Course/{id}").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "C#")]
        public void AddAsync_WhenValidValuePassed_ShouldAddCourseAsyncTests(int expectedId, string courseName)
        {
            Course course = new Course(courseName);

            var response = _client.PostAsJsonAsync<Course>("/Course", course).Result;
            int actual = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(expectedId, actual);
        }
    }
}