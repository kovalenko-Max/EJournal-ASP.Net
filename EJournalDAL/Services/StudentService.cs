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
                student.AgreementNumber).FirstOrDefault().Id;
        }

        public async Task<bool> DeleteStudent(int idStudent)
        {
            int result = _dbConnection.DeleteStudent(idStudent);

            return result > 0;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = _dbConnection.GetAllStudents();

            return _mapper.Map<IEnumerable<Student>>(students);
        }

        public async Task<IEnumerable<Student>> GetStudentById(int idStudent)
        {
            var student = _dbConnection.GetStudent(idStudent);

            return _mapper.Map<IEnumerable<Student>>(student);
        }

        public async Task<IEnumerable<Student>> GetStudentsByGroupId(int idGroup)
        {
            var studentGroup = _dbConnection.GetGroupAndStudentsInIt(idGroup);

            return _mapper.Map<IEnumerable<Student>>(studentGroup);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            var updateStudents = _dbConnection.UpdateStudent(student.Id, student.Name, student.Surname, student.Email,
                student.Phone, student.Git, student.City, student.TeacherAssessment, student.AgreementNumber);

            return updateStudents > 0;
        }
    }
}
