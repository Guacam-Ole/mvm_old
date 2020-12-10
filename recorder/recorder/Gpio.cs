using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;

namespace OleAlbers.McM.Recorder
{
    public class Gpio : IGpio
    {
        private GpioController _gpioController;
        public const int GpioPowerLed = 14;     // TODO: Config
        public const int GpioRecordLed = 10;
        private bool _stopAllBlinking = false;
        private const int DefaultDuration= 1000;

        public Gpio()
        {
            _gpioController = new GpioController();
        }

        public void StopAllBlinking()
        {
            _stopAllBlinking = true;
        }

        public async void BlinkAsync(int gpioId, int? durationHiMs = null, int? durationLoMs = null)
        {
            durationHiMs ??= DefaultDuration;
            durationLoMs ??= durationHiMs;
            _gpioController.OpenPin(gpioId, PinMode.Output);

            await Task.Run(() =>
            {
                while (!_stopAllBlinking)
                {
                    _gpioController.Write(gpioId, PinValue.High);
                    Thread.Sleep(durationHiMs.Value);
                    _gpioController.Write(gpioId, PinValue.Low);
                    Thread.Sleep(durationLoMs.Value);
                }
            });
        }
    }
}