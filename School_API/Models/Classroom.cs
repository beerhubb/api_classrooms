using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_API.Models
{
    public class Classroom
    {
        public string ClassroomId { get; set; }

        public string ClassroomName { get; set; }

        public Studens ClassStudent { get; set; }

        public Teacher ClassTeacher { get; set; }
    }
}
