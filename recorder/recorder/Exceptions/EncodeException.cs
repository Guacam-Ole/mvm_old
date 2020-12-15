using System;
using System.Collections.Generic;
using System.Text;

namespace OleAlbers.McM.Recorder.Exceptions
{
    public class EncodeException : Exception
    {
        public EncodeException(string message) : base(message)
        {
        }
    }
}
