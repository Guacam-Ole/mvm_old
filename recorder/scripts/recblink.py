import RPi.GPIO as GPIO 
import time 

GPIO.setmode(GPIO.BCM) 
GPIO.setwarnings(False) 
GPIO.setup(10,GPIO.OUT) 
for x in range(0, 5): 
    GPIO.output(10,GPIO.HIGH) 
    time.sleep(1)
    GPIO.output(10,GPIO.LOW) 
    time.sleep(1)

