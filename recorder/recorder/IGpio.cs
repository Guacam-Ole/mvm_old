namespace OleAlbers.McM.Recorder
{
    public interface IGpio
    {
        void StopAllBlinking();

        void BlinkAsync(int gpioId, int? durationHiMs =null, int? durationLoMs=null);
    }
}