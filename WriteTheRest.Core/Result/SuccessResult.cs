using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTheRest.Core.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(object data, string message) : base(true, message)
        {
            this.Data = data;
        }

        public SuccessResult(object data) : base(true, string.Empty)
        {
            Data = data;
        }

        public SuccessResult()
        {

        }
        public object Data { get; set; }
    }
}