using System;
using System.Threading;

namespace OleAlbers.McM.Recorder
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var powerLed = new GpioLed(14);

            Console.WriteLine("Start blinking slow");
            powerLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.Slow);
            Thread.Sleep(5000);
            Console.WriteLine("ON");
            powerLed.ChangeMode(GpioLed.LedModes.On);
            Thread.Sleep(5000);
            Console.WriteLine("Start blinking fast");
            powerLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.LightSpeed);
            Thread.Sleep(5000);
            Console.WriteLine("OFF");
            powerLed.ChangeMode(GpioLed.LedModes.Off);
            Thread.Sleep(5000);
            Console.WriteLine("medium blink");
            powerLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.Medium);
            Thread.Sleep(5000);
            Console.WriteLine("on egain");
            powerLed.ChangeMode(GpioLed.LedModes.On);
            Console.ReadLine();
        }
    }
}
