using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.Services
{
    public class StudentService : IStudentService
    {
        private readonly EJournalDB _dbConnection;
        private readonly IMapper _mapper;

        
        public StudentService(IMapper mapper, EJournalDB dbConnection)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }
        public async Task<int?> AddStudent(Student student)
        {
            return (int)_dbConnection.AddStudent(
                student.Name,
                student.Surname,
                student.Email,
                student.Phone,
                student.Git,
                student.City,
                student.Ranking,
                student.AgreementNumber).FirstOrDefault().Column1;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            int result = _dbConnection.DeleteStudent(studentId);
            return result > 0;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = _dbConnection.GetAllStudents();
            return _mapper.Map<IEnumerable<Student>>(students);
        }

        public async Task<IEnumerable<Student>> GetStudentById(int studentId)
        {
            var studenId = _dbConnection.GetStudent(studentId);
            return _mapper.Map<IEnumerable<Student>>(studenId);
        }

        public async Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId)
        {
            var StudentGroup = _dbConnection.GetGroupAndStudentsInIt(groupId);
            return _mapper.Map<IEnumerable<Student>>(StudentGroup);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            var UpdateStudents = _dbConnection.UpdateStudent(student.Id,student.Name,student.Surname,student.Email,student.Phone,student.Git,student.City, student.TeacherAssessment,student.AgreementNumber);
            return UpdateStudents > 0;
        }
    }
}
