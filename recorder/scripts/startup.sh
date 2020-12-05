ts()
{
 date +"%Y-%m-%d %T"
}


cd /home/pi/recorder/scripts
echo "$(ts) Power on. Initiatlizing" >>/var/log/mcm.log

python pwrblink.py &
sleep 10
pkill -f pwrblink.py
python ./pwron.py

echo "$(ts) Ready to go" >>/var/log/mcm.log