using EJournalDAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EJournal_ASP.Net.Tests
{
    public class SerializationHelper
    {
        public string CourseJsonSerialize(List<Course> shapeList)
        {
            return JsonConvert.SerializeObject(shapeList);
        }

        public string CourseJsonSerialize(Course course)
        {
            return JsonConvert.SerializeObject(course);
        }

        public string CommentJsonSerialize(List<Comment> shapeList)
        {
            return JsonConvert.SerializeObject(shapeList);
        }

        public string CommentJsonSerialize(Comment comment)
        {
            return JsonConvert.SerializeObject(comment);
        }

        public string LessonJsonSerialize(List<Lesson> shapeList)
        {
            return JsonConvert.SerializeObject(shapeList);
        }

        public string LessonJsonSerialize(Lesson lesson)
        {
            return JsonConvert.SerializeObject(lesson);
        }

        public string GroupJsonSerialize(List<Group> shapeList)
        {
            return JsonConvert.SerializeObject(shapeList);
        }

        public string GroupJsonSerialize(Group group)
        {
            return JsonConvert.SerializeObject(group);
        }

        public string StudentJsonSerialize(List<Student> shapeList)
        {
            return JsonConvert.SerializeObject(shapeList);
        }

        public string StudentJsonSerialize(Student student)
        {
            return JsonConvert.SerializeObject(student);
        }

        public string ExerciseJsonSerialize(List<Exercise> shapeList)
        {
            return JsonConvert.SerializeObject(shapeList);
        }

        public string ExerciseJsonSerialize(Exercise exercise)
        {
            return JsonConvert.SerializeObject(exercise);
        }
    }
}
