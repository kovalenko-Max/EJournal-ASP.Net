using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using DataModels;
using LinqToDB.Configuration;
using LinqToDB.AspNet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Server.IISIntegration;
using EJournal_ASP.Net.Tests.TestAuthorization;
using Microsoft.AspNetCore.Authorization;

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

                services.AddAuthentication(IISDefaults.Negotiate);

                services.AddLinqToDbContext<EJournalDB>((provider, options) =>
                {
                    options.UseSqlServer(@$"Server=.\SQLEXPRESS;Database=EJournalDB.Test;ConnectRetryCount=0;Integrated Security=True");
                });

                services.AddSingleton<IAuthorizationHandler, AllowAnonymous>();
            });

        }
    }
}
