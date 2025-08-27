using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.Rating
{
    public class CreateRatingDto
    {
        public short StoryId { get; set; }
        public short ChapterId { get; set; }
        public short StoryVersionId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; } // 1-5
        public string? Comment { get; set; }
    }

}
