using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.Chapter
{
    public class CreateChapterDto
    {
        public short StoryId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string? Summary { get; set; }
    }

}
