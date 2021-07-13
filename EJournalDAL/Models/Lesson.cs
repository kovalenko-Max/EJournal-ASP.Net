using System;
using System.Collections.Generic;

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
    }
}
