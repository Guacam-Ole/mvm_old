using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

using System;

namespace OleAlbers.McM.Recorder
{
    public class Configuration
    {
        public string Microphone { get; set; }
        public string Path { get; set; } = "/mnt/usb";  // TODO: Config
        public string WaveFileName { get; set; }
        public string Mp3FileName { get; set; }

        // TODO: Config
        public const int SamplingRate = 44100;

        public const ALFormat Format = ALFormat.Mono16;
        public const int BitsPerChannel = 16;
        public const int Channels = 1;

        public Configuration()
        {
            GetMicrophone();
            InitPaths();
        }

        private void GetMicrophone()
        {
            Microphone = AudioCapture.DefaultDevice;
            Console.WriteLine($"using Microphone: '{Microphone}'");
        }

        private void InitPaths()
        {
            string filename = $"{Path}/record-{DateTime.Now.ToString("yyyyMMdd-HHss")}-mvm";
            WaveFileName = filename + ".wav";
            Mp3FileName = filename + ".mp3";
        }
    }
}