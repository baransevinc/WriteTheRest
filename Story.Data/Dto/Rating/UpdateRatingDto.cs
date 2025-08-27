using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story.Data.Dto.Rating
{
    public class UpdateRatingDto
    {
        public short Id { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}
