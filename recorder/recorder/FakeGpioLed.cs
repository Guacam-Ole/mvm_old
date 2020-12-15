using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace OleAlbers.McM.Recorder
{
    public class FakeGpioLed : IGpioLed
    {
        public void ChangeMode(GpioLed.LedModes newMode, GpioLed.LedBlinkModes blinkMode = GpioLed.LedBlinkModes.None)
        {
            Log.Debug($"Change mode {newMode} {blinkMode}");
        }
    }
}
