using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.User
{
    public class UpdateUserDto
    {
        public short Id { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool? IsAdmin { get; set; } // Admin yetkisi olanlar için
    }

}
