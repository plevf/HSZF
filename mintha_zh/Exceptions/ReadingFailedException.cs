using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh.Exceptions
{
    public class ReadingFailedException : Exception
    {
        public ReadingFailedException() { }
        public ReadingFailedException(string? message) : base(message)
        {
        }
    }
}
