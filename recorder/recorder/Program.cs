
using System;
using System.Threading;

using NAudio.Wave;

using Serilog;

namespace OleAlbers.McM.Recorder
{
    class Program
    {

        private static IGpioLed _powerLed;
        private static IGpioLed _recordLed;
        private static IRecord _record;

        private static Configuration _configuration;
        

        static void Init(bool disableGPIO=false)
        {
#if WINDOWS
                _powerLed = new FakeGpioLed();
                _recordLed = new FakeGpioLed();
#else
                _powerLed = new GpioLed(14);
                _recordLed = new GpioLed(10);
#endif
            _powerLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.Medium);
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("/home/pi/recorder/recorder/mvm.log")
                .CreateLogger();

            Log.Logger = log;

            Log.Information("MvM ready.");
            _powerLed.ChangeMode(GpioLed.LedModes.On);
            
        }

        private static void StartRecording()
        {
            
            _recordLed.ChangeMode(GpioLed.LedModes.On);
            _configuration= new Configuration();

            Log.Debug("Button pressed. Prepare to sabbel");
            Thread.Sleep(5000); // Give a few seconds to prepare // TODO: Config
            _record = new Record(_configuration);
            _recordLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.Medium);
            // TODO: Record WAV

            _record.StartRecord();
            Thread.Sleep(10000);
            _record.StopRecord();

            _recordLed.ChangeMode(GpioLed.LedModes.On); 

            Log.Information("Recording started");

        }

        private static WaveFileWriter _wv;

        private static  void nauTest()
        {
            var win = new WaveInEvent();
            _wv = new WaveFileWriter("tst2.wav", win.WaveFormat);
            win.DataAvailable += Win_DataAvailable;
            win.StartRecording();
            Thread.Sleep(10000);
            win.StopRecording();
            


        }

        private static void Win_DataAvailable(object sender, WaveInEventArgs e)
        {
            _wv.Write(e.Buffer, 0, e.BytesRecorded);

        }

        private static void EncodeRecording()
        {
            Log.Debug("Prepare to encode");
            _recordLed.ChangeMode(GpioLed.LedModes.On);
            Thread.Sleep(2000); // Give a few seconds to show buttonpress worked
            _recordLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.Fast);
            // TODO: Encode MP3

            Log.Information("Encoding Wave-File");
        }

        private static void TestLed()
        {
            Console.WriteLine("ON");
            _powerLed.ChangeMode(GpioLed.LedModes.On);
            Thread.Sleep(5000);
            Console.WriteLine("Start blinking slow");
            _powerLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.Slow);
            Thread.Sleep(5000);
            Console.WriteLine("ON");
            _powerLed.ChangeMode(GpioLed.LedModes.On);
            Thread.Sleep(5000);
            Console.WriteLine("Start blinking fast");
            _powerLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.Fast);
            Thread.Sleep(5000);
            Console.WriteLine("OFF");
            _powerLed.ChangeMode(GpioLed.LedModes.Off);
            Thread.Sleep(5000);
            Console.WriteLine("medium blink");
            _powerLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.Medium);
            Thread.Sleep(5000);
            Console.WriteLine("lightspeed");
            _powerLed.ChangeMode(GpioLed.LedModes.Blink, GpioLed.LedBlinkModes.LightSpeed);
            Thread.Sleep(5000);
            Console.WriteLine("on egain");
            _powerLed.ChangeMode(GpioLed.LedModes.On);
        
    }

        static void Main(string[] args)
        {
            nauTest();
            //Init();
            ////Console.ReadLine();  // TODO: On Buttonpress instead of keyboard
            //StartRecording();
        }

    }
}
