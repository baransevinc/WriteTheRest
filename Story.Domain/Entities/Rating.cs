using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Domain.Entities
{
    public class Rating
    {
        public short Id { get; set; }
        public short StoryId { get; set; }
        public short ChapterId { get; set; }
        public short StoryVersionId { get; set; }
        public short UserId { get; set; }
        public short Score { get; set; }               // 1-5 arası puan
        public string? Comment { get; set; }         // Opsiyonel yorum
        public DateTime RatedAt { get; set; }

        public Story Story { get; set; }
        public Chapter Chapter { get; set; }
        public StoryVersion StoryVersion { get; set; }
        public User User { get; set; }
    }

}
