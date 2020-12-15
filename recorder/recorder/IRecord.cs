using System;
using System.Collections.Generic;
using System.Text;

namespace OleAlbers.McM.Recorder
{
    public interface IRecord
    {
        void StartRecord();
        void Encode(string source, string target);
        void StopRecord();
    }
}
