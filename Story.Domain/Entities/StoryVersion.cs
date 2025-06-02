using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Domain.Entities
{
    public class StoryVersion
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }             // Versiyon başlığı (isteğe bağlı)
        public string Content { get; set; }           // Hikaye metni
        public DateTime CreatedAt { get; set; }
        public bool IsPublishedVersion { get; set; }  // En çok oylanan mı?
        public int TotalScore { get; set; }           // Oylardan gelen toplam puan
        public int RatingCount { get; set; }          // Oylayan kişi sayısı
                                                       
        public Chapter Chapter { get; set; }
        public User User { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }

}
