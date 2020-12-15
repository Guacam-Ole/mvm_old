using OleAlbers.McM.Recorder.Exceptions;

using OpenTK.Audio;

using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using OpenTK.Audio.OpenAL;
using OpenTK;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OleAlbers.McM.Recorder
{
    public class Record : IRecord
    {
        private Configuration _configuration;
        private AudioCapture _audioCapture;
        private AudioContext _audioContext;
        private float _gain = 0.0f;
        private int _samplingRate = 44100;
        private const int _bufferLength = 512;
        private ALFormat _format = ALFormat.Mono16;
        private byte[] _buffer = new byte[_bufferLength];
        private bool _stopRecording = false;
        private Stream _waveStream;
        private BinaryWriter _writer;

        public Record(Configuration configuration)
        {
            _configuration = configuration;
        }

        public void Encode(string source, string target)
        {
            throw new NotImplementedException();
        }

        public void StopRecord()
        {
            if (_audioCapture == null || !_audioCapture.IsRunning)
            {
                Log.Warning("Cannot stop something that is not running");
                return;
            }
            _audioCapture.Stop();
            

            do
            {
                Thread.Sleep(1000);
            } while (_audioCapture.IsRunning);

            _waveStream.Close();

            Log.Information("Capture stopped");
        }

        public void StartRecord()
        {
            if (string.IsNullOrWhiteSpace(_configuration.Microphone)) throw new MicrophoneException("Cannot detect any microphone");
            if (_audioCapture != null && _audioCapture.IsRunning)
            {
                Log.Warning("Capture already running. Won't restart");
                return;
            }

            _audioContext = new AudioContext();
            AL.Listener(ALListenerf.Gain, _gain);
            var source = AL.GenSource();

            int bufferLengthSamples = (int)((double)_bufferLength * _samplingRate * 0.001 / BlittableValueType.StrideOf(_buffer));
            try
            {
                _audioCapture = new AudioCapture(_configuration.Microphone, _samplingRate, _format, bufferLengthSamples);
            }
            catch (Exception ex)
            {
                throw new MicrophoneException("Error when trying to start capture", ex);
            }
            if (_audioCapture == null) throw new MicrophoneException("AudioCapture not initialized");
            Log.Information("Starting Capture");
            _audioCapture.Start();
            

            Capture();
        }

        

        private async void Capture()
        {
            await Task.Run(() => {
                while (_audioCapture.IsRunning)
                {
                    _audioCapture.ReadSamples(_buffer, _bufferLength/2);
                    
                    _ = _waveStream.WriteAsync(_buffer);
                    Log.Debug("Buffer saved");
                }
            });
        }
    }
}
