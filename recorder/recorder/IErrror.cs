using System;
using System.Collections.Generic;
using System.Text;

namespace OleAlbers.McM.Recorder
{
    public interface IErrror
    {
        void DisplayException(Exception ex);
    }
}
