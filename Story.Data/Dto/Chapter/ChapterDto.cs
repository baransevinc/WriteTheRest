using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.Chapter
{
    public class ChapterDto
    {
        public short Id { get; set; }
        public short StoryId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Summary { get; set; }
        public string StoryTitle { get; set; } // Story'den gelen bilgi (isteğe bağlı)
    }

}
