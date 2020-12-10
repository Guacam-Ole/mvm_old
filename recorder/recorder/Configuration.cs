using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using System.IO;
using System.Threading;

namespace OleAlbers.McM.Recorder
{
    public class Configuration
    {
        public object Microphone { get; set; }
        public string Path { get; set; }
        public string WaveFileName { get; set; }
        public string Mp3FileName { get; set; }

        public const int SamplingRate= 44100;
        public const ALFormat Format = ALFormat.Mono16;
        public const int BitsPerChannel = 16;
        public const int Channels = 1;

        public Configuration()
        {
            GetMicrophone();
        }

        private void GetMicrophone()
        {
            var microphone = AudioCapture.DefaultDevice;
            Console.WriteLine($"default Microphones: {microphone}");

            using (var capture=new AudioCapture(microphone, SamplingRate, Format, SamplingRate*10 ))
            {
                capture.Start();
                Thread.Sleep(10000);
                capture.Stop();
            }

        }
    }
}
