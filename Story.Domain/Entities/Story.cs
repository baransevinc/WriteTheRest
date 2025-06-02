using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Domain.Entities
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }             // Hikaye başlığı
        public string Theme { get; set; }             // Ana konusu
        public string? Description { get; set; }      // Açıklama
        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }    // Yayınlanma tarihi (varsa)

        public ICollection<Chapter> Chapters { get; set; }
    }

}
