using System;
using System.Collections.Generic;
using System.Text;

namespace OleAlbers.McM.Recorder.Exceptions
{
    public class NoStorageFoundException : Exception
    {
        public NoStorageFoundException(string message) : base(message)
        {
        }
    }
}
