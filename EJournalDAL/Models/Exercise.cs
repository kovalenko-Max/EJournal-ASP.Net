using System;
using System.Collections.Generic;

namespace EJournalDAL.Models
{
    public class Exercise
    {
        public int Id;
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int? IdGroup { get; set; }
        public ExcerciseType ExerciseType { get; set; }
        public StudentMark StudentMarks { get; set; }

        public Exercise()
        {

        }

        public Exercise(Group group)
        {
            Description = string.Empty;
            IdGroup = group.Id;
            ExerciseType = (ExcerciseType)0;
            StudentMarks = new StudentMark();
        }
    }
}
