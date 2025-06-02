using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsAdmin { get; set; } // Admin olup olmadığını ayırt eder

        public ICollection<StoryVersion> StoryVersions { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }

}
