namespace EJournalDAL.Models
{
    public class StudentMark
    {
        public Student Student { get; set; }
        public int Point { get; set; }

        public StudentMark()
        {

        }

        public StudentMark(Student student)
        {
            Student = student;
        }

        public StudentMark(Student student, int point)
        {
            Student = student;
            Point = point;
        }

        public StudentMark(int studentId, string name, string surname, int studentPoint)
        {
            Student = new Student(name, surname);
            Student.Id = studentId;
            Point = studentPoint;
        }
    }
}
