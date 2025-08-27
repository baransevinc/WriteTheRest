using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.User
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Hash'e dönüştürülür
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
