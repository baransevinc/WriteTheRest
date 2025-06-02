using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Domain.Entities
{
    public class Chapter
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }                // Bölüm sıralaması
        public bool IsCompleted { get; set; }         // Yayınlanmış versiyonu var mı
        public DateTime CreatedAt { get; set; }
        public string? Summary { get; set; }          // Bölüm özeti veya açıklaması

        public Story Story { get; set; }
        public ICollection<StoryVersion> StoryVersions { get; set; }
    }

}
