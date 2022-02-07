using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Lesson05.Models
{
    public class CourseSchedule
    {
        public int CourseScheduleId { get; set; }

        public string TrainerId  { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public DateTime Date { get; set; }
        
        public System.TimeSpan StartTime  { get; set; }

        public System.TimeSpan EndTime  { get; set; }

        public string Venue { get; set; }

    }
}
