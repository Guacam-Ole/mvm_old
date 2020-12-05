import RPi.GPIO as GPIO 
import time 

def rec_callback(channel):
    print ("horido!")
    print (channel)

GPIO.setmode(GPIO.BCM) 
GPIO.setwarnings(False) 
GPIO.setup(27,GPIO.IN, pull_up_down=GPIO.PUD_DOWN) 
GPIO.add_event_detect (27, GPIO.RISING, callback=rec_callback)

while (True):
	time.sleep(1)
