using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;

namespace OleAlbers.McM.Recorder
{
    public class GpioLed : IGpioLed
    {
        public enum LedModes {  Off, On, Blink}
        public enum LedBlinkModes { None, Slow=1000, Medium=750, Fast=200, LightSpeed=100 }

        private GpioController _gpioController;
        private LedModes _ledMode;
        private LedBlinkModes _blinkMode;
        private int _gpioId ;

        public GpioLed(int id)
        {
            _gpioId = id;
            _gpioController = new GpioController();
            _gpioController.OpenPin(id, PinMode.Output);
        }

        public void ChangeMode(LedModes newMode, LedBlinkModes blinkMode= LedBlinkModes.None)
        {
            if (newMode != LedModes.Blink) blinkMode = LedBlinkModes.None;
            if (_ledMode == LedModes.Blink && newMode != LedModes.Blink) Thread.Sleep((int)_blinkMode * 2);
            
            _blinkMode = blinkMode;
            _ledMode = newMode;
            
            switch (_ledMode)
            {
                case LedModes.Blink:
                    BlinkAsync();
                    break;
                case LedModes.On:
                    On();
                    break;
                case LedModes.Off:
                    Off();
                    break;
            }
        }

        private void On()
        {
            _gpioController.Write(_gpioId, PinValue.High);
        }

        private void Off()
        {
            _gpioController.Write(_gpioId, PinValue.Low);
        }


        ~GpioLed()
        {
            _gpioController.ClosePin(_gpioId);
        }

        private async void BlinkAsync()
        {
            await Task.Run(() =>
            {
                while (_blinkMode !=LedBlinkModes.None)
                {
                    _gpioController.Write(_gpioId, PinValue.High);
                    Thread.Sleep((int)_blinkMode);
                    if (_blinkMode == LedBlinkModes.None) break;
                    _gpioController.Write(_gpioId, PinValue.Low);
                    Thread.Sleep((int)_blinkMode);
                }
            });
        }
    }
}