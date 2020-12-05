import RPi.GPIO as GPIO 
import time 

GPIO.setmode(GPIO.BCM) 
GPIO.setwarnings(False) 
GPIO.setup(14,GPIO.OUT) 
for x in range(0, 5): 
    GPIO.output(14,GPIO.HIGH) 
    time.sleep(1)
    GPIO.output(14,GPIO.LOW) 
    time.sleep(1)