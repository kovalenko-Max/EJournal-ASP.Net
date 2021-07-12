using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using EJournalDAL.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace EJournal_ASP.Net.IntegrationalTests.API
{
    public class CourseApiTests
    {
        public CourseApiTests()
        {
        }
        [OneTimeSetUp]
        public void Setup() => _server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>()
            .UseUrls("http://localhost:5000"));


        [OneTimeTearDown]
        public void Teardown() => _server.Dispose();

        [SetUp]
        public void CreateClient() => _client = new RestClient("http://localhost:5000");

        TestServer _server;
        RestClient _client;


        [Test]

        public async Task CourseGetTest()
        {
            var request = new RestRequest("/Course/id?id=2", Method.GET);
            var queryResult = _client.Execute<Course>(request).Data;

        }

    }
}
