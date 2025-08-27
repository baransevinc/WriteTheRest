using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Domain.Entities
{
    public class StoryVersion // Chapter Versions - Bölüm versiyonları aslında bu sınıf bir bölüm için farklı kullanıcılar tarafından yazılan versiyonları temsil eder.
    {
        public short Id { get; set; }
        public short StoryId { get; set; }
        public short ChapterId { get; set; }
        public short UserId { get; set; }
        public string Title { get; set; }             // Versiyon başlığı (isteğe bağlı)
        [Required]
        public string Content { get; set; }           // Hikaye metni
        public DateTime CreatedAt { get; set; }
        public bool IsPublishedVersion { get; set; }  // En çok oylanan mı?
        public int TotalScore { get; set; }           // Oylardan gelen toplam puan
        public int RatingCount { get; set; }          // Oylayan kişi sayısı
                                                       
        public Chapter Chapter { get; set; }
        public User User { get; set; }
        public Story Story { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }

}
