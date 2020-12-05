import RPi.GPIO as GPIO 
import pyaudio
import wave
import time 

# TODO: configurable
chunk=1024
sample_format=pyaudio.paInt16
channels=2
fs=44100
filename="sample.wav"
p=pyaudio.PyAudio()
stoprecording=False

def rec_start():
    global stoprecording
    GPIO.celanup()
    print ("initializing recording")
    for i in range (0,5) :  
        GPIO.output(10,GPIO.HIGH) 
        time.sleep(1)
        GPIO.output(10,GPIO.LOW) 
        time.sleep(1)
    print ("starting recording")
    stream=p.open(format=sample_format, channels=channels, rate=fs, frames_per_buffer=chunk, input=True)
    frames=[]

    GPIO.output(10,GPIO.HIGH) 
    GPIO.add_event_detect (27, GPIO.RISING, callback=rec_callback_stop)
    while (stoprecording!=True):
        data=stream.read(chunk)
        frames.append(data)

    print ("finished recording")
    stream.stop_stream()
    stream.close()
    p.terminate()

def rec_stop():
    global stoprecording
    stoprecording=True    
    GPIO.output(10,GPIO.LOW) 
    listen_tobutton()

def rec_callback_start(channel):
    rec_start()

def rec_callback_stop():
    rec_stop()
    
def listen_tobutton():
    GPIO.add_event_detect (27, GPIO.RISING, callback=rec_callback_start)

GPIO.setmode(GPIO.BCM) 
GPIO.setwarnings(False) 
GPIO.setup(10,GPIO.OUT) 
GPIO.setup(27,GPIO.IN, pull_up_down=GPIO.PUD_DOWN) 
listen_tobutton()


while (True):
	time.sleep(1)
