using EJournal_ASP.Net.Tests.Mocks;
using EJournalDAL.Models;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace EJournal_ASP.Net.Tests
{
    [TestFixture]
    public class CommentControllerTests
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
        public void GetCommentsByStudentIdAsync_WhenValidValuePassed_ShouldReturnCommentsByStudentIdAsyncTests(int commentsCount, int idStudent)
        {
            List<Comment> comments = new List<Comment>();
            Student student = Mock.GetStudentMock(idStudent);

            for (int i = 1; i <= commentsCount; ++i)
            {
                comments.Add(Mock.GetCommentMock(i));
            }

            _sharedDatabaseFixture.FillCommentsTable(student, comments);
            
            string expected = _serializationHelper.CommentJsonSerialize(comments);
            var queryResult = _client.GetAsync($"/byId/{idStudent}").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }
    }
}
