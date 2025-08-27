using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.StoryVersion
{
    public class CreateStoryVersionDto
    {
        public short StoryId { get; set; }
        public short ChapterId { get; set; }     
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

}
