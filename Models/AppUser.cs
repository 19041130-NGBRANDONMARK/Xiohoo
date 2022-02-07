using System;
using System.Collections.Generic;

#nullable disable

namespace Lesson05.Models
{
    public partial class AppUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public string Role { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
