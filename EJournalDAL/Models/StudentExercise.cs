using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class StudentExercise
    {
        public int IdStudent { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Point { get; set; }

        public int IdExercise { get; set; }

    }
}
