using EJournalDAL.Models;
using System.Text.Json.Serialization;

namespace EJournal_ASP.Net.Tests
{
    public static class Mock
    {
        public static Course GetCourseMock(int iDCourse)
        {
            return new Course($"Course {iDCourse}")
            {
                Id = iDCourse
            };
        }
    }
}
