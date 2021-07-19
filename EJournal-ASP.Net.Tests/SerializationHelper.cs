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
    }
}
