﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class Exercise
    {
        public int Id;
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int? IdGroup { get; set; }
        public ExcerciseType ExerciseType { get; set; }
        public List<StudentMark> StudentMarks { get; set; }

        public Exercise()
        {

        }
        public Exercise(Group group)
        {
            Description = string.Empty;
            IdGroup = group.Id;
            ExerciseType = (ExcerciseType)0;
            StudentMarks = new List<StudentMark>();
        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            if (obj is Exercise exercise &&
                   Id == exercise.Id &&
                   Description == exercise.Description &&
                   Deadline == exercise.Deadline &&
                   IdGroup == exercise.IdGroup &&
                   ExerciseType == exercise.ExerciseType)
            {

                equal = StudentMarks.SequenceEqual(exercise.StudentMarks); ;
            }
            return equal;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
