using System;

namespace recorder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start blinking");
            var gpio = new Gpio();
            gpio.BlinkAsync(Gpio.GpioPowerLed);
            Console.ReadLine();
            gpio.StopAllBlinking();
        }
    }
}
