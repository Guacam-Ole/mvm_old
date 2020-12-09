namespace OleAlbers.McM.Recorder
{
    public interface IGpio
    {
        void StopAllBlinking();

        void BlinkAsync(int gpioId, int durationMs = 1000);
    }
}