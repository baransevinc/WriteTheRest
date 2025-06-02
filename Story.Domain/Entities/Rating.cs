using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int StoryVersionId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }               // 1-5 arası puan
        public string? Comment { get; set; }         // Opsiyonel yorum
        public DateTime RatedAt { get; set; }

        public StoryVersion StoryVersion { get; set; }
        public User User { get; set; }
    }

}
