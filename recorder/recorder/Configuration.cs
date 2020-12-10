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

        public Configuration()
        {
            GetMicrophone();
        }

        private void GetMicrophone()
        {
            var microphones = AudioCapture.AvailableDevices;
            Console.WriteLine($"Microphones:{microphones}");

            var microphone = AudioCapture.DefaultDevice;
            Console.WriteLine($"default Microphones:{microphone}");

        }
    }
}
