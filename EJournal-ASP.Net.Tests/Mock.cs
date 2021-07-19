using EJournalDAL.Models;

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
                IdGroup = idLesson
            };
        }

        public static Group GetGroupMock(int idGroup)
        {
            return new Group()
            {
                Id = idGroup,
                Name = $"Name {idGroup}"
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
                AgreementNumber = $"AgreementNumber {idStudent}"
            };
        }

        public static Exercise GetExerciseMock(int idExercise)
        {
            return new Exercise()
            {
                Id = idExercise,
                Description = $"Description {idExercise}",
                IdGroup = idExercise
            };
        }
    }
}
