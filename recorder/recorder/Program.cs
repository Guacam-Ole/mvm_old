using System;

namespace recorder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var gpio = new Gpio();
            gpio.Blink(Gpio.GpioPowerLed);
            Console.ReadLine();
        }
    }
}
