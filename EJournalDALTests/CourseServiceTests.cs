using AutoMapper;
using AutoMapper.Configuration;
using DataModels;
using EJournalDAL.MapperProfiles;
using EJournalDAL.Models;
using EJournalDAL.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataModels.EJournalDBDBStoredProcedures;
using FluentAssertions;

namespace EJournalDALTests
{
    public class CourseServiceTests
    {
        private readonly IMapper _mapper;
        public CourseServiceTests()
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();

            mapperConfigurationExpression.AddMaps(typeof(CourseMappingProfile).Assembly);

            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);
            mapperConfiguration.AssertConfigurationIsValid();

            _mapper = new Mapper(mapperConfiguration);
        }

        [SetUp]
        public void Setup ()
        {

        }

        [Test]

        public async Task GetAll_Test ()
        {
            var dbMock = new Mock<EJournalDB>();

            CourseService courseService = new CourseService(_mapper, dbMock.Object);

            var expectedDBResult = new List<GetAllCoursesResult>
            {
                new GetAllCoursesResult
                {
                    Id = 1,
                    Name = "test1"
                },
                new GetAllCoursesResult
                {
                    Id = 2,
                    Name = "test2"
                }
            };
            dbMock.Setup(db => db.GetAllCourses()).Returns(expectedDBResult);
            var expected = _mapper.Map<List<Course>>(expectedDBResult);
            var actual = courseService.GetAll();

            actual.Should().BeEquivalentTo(expected);

        }
    }
}
