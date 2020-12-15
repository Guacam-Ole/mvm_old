using System;
using System.Collections.Generic;
using System.Text;

namespace OleAlbers.McM.Recorder.Exceptions
{
    public class RecordException : Exception
    {
        public RecordException(string message) : base(message)
        {
        }
    }
}
