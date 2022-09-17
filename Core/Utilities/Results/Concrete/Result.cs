using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(string message, bool success):this(success)
        {
            Message=message;
        }

        public Result(bool success)
        {
            Success=success;
        }

        public string Message { get; }

        public bool Success { get; }
    }
}
