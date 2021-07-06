using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class Attendances
    {
        public Student Student { get; set; }
        public bool isPresent { get; set; }

        public Attendances(Student student)
        {
            Student = student;
            isPresent = true;
        }

        public override bool Equals(object obj)
        {
            return obj is Attendances attendances &&
                   EqualityComparer<Student>.Default.Equals(Student, attendances.Student) &&
                   isPresent == attendances.isPresent;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Student, isPresent);
        }
    }
}
