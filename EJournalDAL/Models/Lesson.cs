﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime DateLesson { get; set; }
        public int IdGroup { get; set; }

        public List<Attendances> Attendances { get; set; }

        public Lesson()
        {
            Topic = string.Empty;
            DateLesson = DateTime.Now;
            Attendances = new List<Attendances>();
        }

        public override bool Equals(object obj)
        {
            bool isEquals = obj is Lesson lesson &&
                   Id == lesson.Id &&
                   Topic == lesson.Topic &&
                   DateLesson == lesson.DateLesson &&
                   IdGroup == lesson.IdGroup &&
                   Attendances.SequenceEqual(lesson.Attendances);

            return isEquals;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Topic, DateLesson, IdGroup, Attendances);
        }
    }
}
