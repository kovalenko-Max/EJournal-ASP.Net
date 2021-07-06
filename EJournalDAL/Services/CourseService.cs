using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.Services
{
    public class CourseService : ICourseService
    {
        private readonly EJournalDB _dbConnection;
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, EJournalDB dbConnection)
        {
            _mapper = mapper;
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            IEnumerable<GetAllCoursesResult> courses = new List<GetAllCoursesResult>(_dbConnection.GetAllCourses());
            
            return _mapper.Map<List<Course>>(courses);
        }
    }
}
