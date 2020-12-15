using System;
using System.Collections.Generic;
using System.Text;

namespace OleAlbers.McM.Recorder.Exceptions
{
    public class MicrophoneException : Exception
    {
        public MicrophoneException(string message, Exception innerException=null) : base(message, innerException) { }

    }
}
