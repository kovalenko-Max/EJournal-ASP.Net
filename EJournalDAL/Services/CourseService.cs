﻿using AutoMapper;
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
            
            return _mapper.Map<IEnumerable<Course>>(courses);
        }

        public async Task<IEnumerable<Course>> GetById(int id)
        {
            IEnumerable<GetCourseResult> courses = new List<GetCourseResult>(_dbConnection.GetCourse(id));
            return _mapper.Map<List<Course>>(courses);
        }

        public async Task<int?> Add(string name)
        {
            return _dbConnection.AddCourse(name);
        }

        public async Task<bool> Update(Course course)
        {
            int result = _dbConnection.UpdateCourse(course.Id, course.Name);
            return result > 0 ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            int result = _dbConnection.DeleteCourse(id);
            return result > 0 ? true : false;
        }
    }
}
