using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh_gyak_2.Exceptions
{
    public class EmptyFileException : Exception
    {
        public EmptyFileException()
        {
        }

        public EmptyFileException(string? message) : base(message)
        {
        }
    }
}
