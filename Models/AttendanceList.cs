using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson05.Models
{
    public class AttendanceList
    {

        //public string TrainerName { get; set; }
        public List<CourseAttendance> CourseAttendance { get; set; }

        public int Attendance { get; set; }
    }
}
