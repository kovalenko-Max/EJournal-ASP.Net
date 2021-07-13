using System.Collections.Generic;

namespace EJournalDAL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Git { get; set; }
        public string City { get; set; }
        public int TeacherAssessment { get; set; }
        public int Ranking { get; set; }
        public string AgreementNumber { get; set; }
        public List<Comment> Comments { get; set; }

        public Student()
        {

        }

        public Student(string name, string surname, string email, string phone, string git, string city, string agreementNumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Git = git;
            City = city;
            AgreementNumber = agreementNumber;
            Comments = new List<Comment>();
        }

        public Student(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Comments = new List<Comment>();
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
