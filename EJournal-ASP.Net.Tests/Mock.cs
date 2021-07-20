using EJournalDAL.Models;
using System.Collections.Generic;

namespace EJournal_ASP.Net.Tests
{
    public static class Mock
    {
        public static Course GetCourseMock(int idCourse)
        {
            return new Course($"Course {idCourse}")
            {
                Id = idCourse
            };
        }

        public static Comment GetCommentMock(int idComment)
        {
            return new Comment($"CommentText {idComment}", $"CommentType {idComment}")
            {
                Id = idComment
            };
        }

        public static Lesson GetLessonMock(int idLesson)
        {
            return new Lesson()
            {
                Id = idLesson,
                Topic = $"Topic {idLesson}",
                DateLesson = new System.DateTime(2021, 10, 10),
                IdGroup = idLesson
            };
        }

        public static Group GetGroupMock(int idGroup)
        {
            return new Group()
            {
                Id = idGroup,
                Name = $"Name {idGroup}",
                Course = new Course($"Course {idGroup}")
            };
        }

        public static Group GetGroupMock(int idGroup, Course course)
        {
            return new Group($"Name {idGroup}", course)
            { 
                Id = idGroup,
            };
        }

        public static Student GetStudentMock(int idStudent)
        {
            return new Student()
            {
                Id = idStudent,
                Name = $"Name {idStudent}",
                Surname = $"Surname {idStudent}",
                Email = $"Email {idStudent}",
                Phone = $"Phone {idStudent}",
                Git = $"Git {idStudent}",
                City = $"City {idStudent}",
                TeacherAssessment = idStudent,
                Ranking = idStudent,
                AgreementNumber = $"AgreementNumber {idStudent}",
                Comments = new List<Comment>()
            };
        }

        public static Exercise GetExerciseMock(int idExercise, Group group, List<Student> students)
        {
            Exercise exercise = new Exercise(group);

            foreach(var student in students)
            {
                exercise.StudentMarks.Add(new StudentMark(student, 2 * idExercise));
            }

            return exercise;
        }
    }
}
