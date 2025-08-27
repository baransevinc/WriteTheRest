using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.StoryVersion
{
    public class StoryVersionDto
    {
        public short Id { get; set; }
        public short StoryId { get; set; }
        public short ChapterId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPublishedVersion { get; set; }
        public int TotalScore { get; set; }
        public int RatingCount { get; set; }
        public string Username { get; set; } // User'dan alınan sadece ihtiyaç duyulan alan

        public string ChapterTitle { get; set; } // Chapter'dan alınan bilgi (isteğe bağlı)
    }

}
