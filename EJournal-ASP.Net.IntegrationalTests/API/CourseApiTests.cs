using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using NUnit.Framework;

namespace EJournal_ASP.Net.IntegrationalTests.API
{
    public class CourseApiTests
    {
        private readonly HttpClient _client;

        public CourseApiTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Test]

        public async Task CourseGetTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/course/");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

    }
}
