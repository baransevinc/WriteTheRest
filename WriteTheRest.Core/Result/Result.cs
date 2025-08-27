using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTheRest.Core.Result
{
    public class Result
    {
        public Result(bool success, string message)
        {
            Message = message;
            Success = success;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public Result()
        {

        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
