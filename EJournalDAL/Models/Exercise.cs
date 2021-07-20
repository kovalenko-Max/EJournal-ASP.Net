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
        public ExerciseType ExerciseType { get; set; }
        public List<StudentMark> StudentMarks { get; set; }

        public Exercise()
        {
            Description = string.Empty;
            ExerciseType = (ExerciseType)0;
            StudentMarks = new List<StudentMark>();
        }

        public Exercise(Group group)
        {
            Description = string.Empty;
            IdGroup = group.Id;
            ExerciseType = (ExerciseType)0;
            StudentMarks = new List<StudentMark>();
        }
    }
}
