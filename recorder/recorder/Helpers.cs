using System;
using System.Collections.Generic;
using System.Text;

namespace OleAlbers.McM.Recorder
{
    public static class Helpers
    {
        public static Byte[] ToByteArray(this string source)
        {
            return System.Text.Encoding.ASCII.GetBytes(source);
        }
    }
}
