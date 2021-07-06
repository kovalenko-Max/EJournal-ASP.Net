﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class StudentMark
    {
        public Student Student { get; set; }
        public int Point { get; set; }

        public StudentMark(Student student, int point)
        {
            Student = student;
            Point = point;
        }

        public StudentMark(Student student)
        {
            Student = student;
        }

        public override bool Equals(object obj)
        {
            return obj is StudentMark mark &&
                   EqualityComparer<Student>.Default.Equals(Student, mark.Student) &&
                   Point == mark.Point;
        }
    }
}
