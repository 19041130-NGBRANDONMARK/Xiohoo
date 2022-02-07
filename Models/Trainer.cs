using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lesson05.Models
{
    public class Trainer
    {
        public int Email { get; set; }

        public string FullName { get; set; }

        public string Courses { get; set; }
    }
}
//not used