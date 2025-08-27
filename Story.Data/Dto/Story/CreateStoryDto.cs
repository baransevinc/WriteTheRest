using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.Story
{
    public class CreateStoryDto
    {
        public string Title { get; set; }
        public string Theme { get; set; }
        public string? Description { get; set; }
    }
}
