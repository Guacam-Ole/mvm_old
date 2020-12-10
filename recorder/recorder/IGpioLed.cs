using static OleAlbers.McM.Recorder.GpioLed;

namespace OleAlbers.McM.Recorder
{
    public interface IGpioLed
    {
        void ChangeMode(LedModes newMode, LedBlinkModes blinkMode = LedBlinkModes.None);

    }
}