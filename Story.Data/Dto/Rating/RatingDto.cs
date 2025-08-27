using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.Rating
{
    public class RatingDto
    {
        public short Id { get; set; }
        public int StoryVersionId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
        public DateTime RatedAt { get; set; }
        public string Username { get; set; } // User tablosundan
    }

}
