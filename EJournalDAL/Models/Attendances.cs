namespace EJournalDAL.Models
{
    public class Attendances
    {
        public Student Student { get; set; }
        public bool IsPresent { get; set; }

        public Attendances()
        {

        }

        public Attendances(Student student)
        {
            Student = student;
            IsPresent = true;
        }
    }
}
