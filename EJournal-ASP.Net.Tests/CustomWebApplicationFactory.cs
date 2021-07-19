using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using DataModels;
using LinqToDB.Configuration;
using LinqToDB.AspNet;

namespace EJournal_ASP.Net.Tests
{
    public class CustomWebApplicationFactory
        : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                    typeof(LinqToDbConnectionOptions<EJournalDB>));

                bool isRemove = services.Remove(descriptor);

                services.AddLinqToDbContext<EJournalDB>((provider, options) =>
                {
                    options.UseSqlServer(@$"Server=LAPTOP-E2SFBO2T;Database=EJournalDB.Test;ConnectRetryCount=0;Integrated Security=True");
                });
            });
        }
    }
}
