using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Lesson05.Models
{
    public partial class MugOrder
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Courses { get; set; }

        public DateTime DOB { get; set; }

        public string CreatedBy { get; set; }

        public string AdditionalCourses { get; set; }


    }
}
