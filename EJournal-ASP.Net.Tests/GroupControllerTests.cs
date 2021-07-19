using EJournalDAL.Models;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace EJournal_ASP.Net.Tests
{
    [TestFixture]
    public class GroupControllerTests
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
        public void GetAllAsync_WhenValidValuePassed_ShouldReturnAllGroupsAsyncTests(int groupsCount)
        {
            List<Group> groups = new List<Group>();

            for (int i = 1; i <= groupsCount; ++i)
            {
                groups.Add(Mock.GetGroupMock(i));
            }

            _sharedDatabaseFixture.FillGroupsTable(groups);

            string expected = _serializationHelper.GroupJsonSerialize(groups);
            var queryResult = _client.GetAsync("/Group").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2)]
        public void GetGroupByIdAsync_WhenValidValuePassed_ShouldReturnGroupByIdAsyncTests(int groupsCount, int id)
        {
            List<Group> groups = new List<Group>();

            for (int i = 1; i <= groupsCount; ++i)
            {
                groups.Add(Mock.GetGroupMock(i));
            }

            _sharedDatabaseFixture.FillGroupsTable(groups);

            List<Group> temp = new List<Group>() { groups[id - 1] };
            string expected = _serializationHelper.GroupJsonSerialize(temp);
            var queryResult = _client.GetAsync($"/Group/{id}").Result;
            string actual = queryResult.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expected, actual);
        }
    }
}
