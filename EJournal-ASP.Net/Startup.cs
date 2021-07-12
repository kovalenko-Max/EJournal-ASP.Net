using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using LinqToDB.AspNet;
using LinqToDB.Configuration;
using System.Reflection;
using EJournalDAL.Services;
using DataModels;
using EJournalDAL.MapperProfiles;
using NLog;
using NLog.Config;
using Microsoft.Extensions.Logging;
using EJournal_ASP.Net.Controllers;
using NLog.Extensions.Logging;

namespace EJournal_ASP.Net
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblies = new[]
            {
                Assembly.GetAssembly(typeof(CourseMappingProfile)), //api
                Assembly.GetAssembly(typeof(ExerciseMappingProfile)) //api
            };

            services.AddAutoMapper(assemblies);

            services.AddControllers();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ILessonService, LessonService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EJournal_ASP.Net", Version = "v1" });
            });

            services.AddLinqToDbContext<EJournalDB>((provider, options) =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<CourseController>();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog(_configuration);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EJournal_ASP.Net v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
