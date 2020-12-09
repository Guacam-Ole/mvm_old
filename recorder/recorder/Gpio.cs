using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace recorder
{
    public class Gpio
    {
        private GpioController _gpioController;
        public const int GpioPowerLed = 14;     // TODO: Config
        public const int GpioRecordLed = 10;

        public Gpio()
        {
            _gpioController = new GpioController();

        }
        public void Blink(int gpioId, int durationMs=1000)
        {
            _gpioController.OpenPin(gpioId, PinMode.Output);
            _gpioController.Write(gpioId, PinValue.High);
            Thread.Sleep(durationMs);
            _gpioController.Write(gpioId, PinValue.Low);
            Thread.Sleep(durationMs);
        }
    }
}
