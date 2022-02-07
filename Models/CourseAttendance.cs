using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson05.Models
{
    public class CourseAttendance
    {

        public int CourseId { get; set; }

        public string Participant_Name { get; set; }

        public int Attendance { get; set; }

    }
}
