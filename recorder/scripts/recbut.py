import RPi.GPIO as GPIO 
import time 

def rec_start
    print ("initializing recording")
    for i in range (0,5)    
        GPIO.output(10,GPIO.HIGH) 
        time.sleep(1)
        GPIO.output(10,GPIO.LOW) 
        time.sleep(1)
    print ("starting recording")
    GPIO.output(10,GPIO.HIGH) 

def rec_callback(channel):
    rec_start()
    
GPIO.setmode(GPIO.BCM) 
GPIO.setwarnings(False) 
GPIO.setup(27,GPIO.IN, pull_up_down=GPIO.PUD_DOWN) 
GPIO.setup(10,GPIO.OUT) 
GPIO.add_event_detect (27, GPIO.RISING, callback=rec_callback)

while (True):
	time.sleep(1)
