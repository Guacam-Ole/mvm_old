time()
{
 date +"%Y-%m-%d %T"
}


cd ./home/pi/recorder/scripts
echo "$(time): Power on. Initiatlizing" >>/var/log/mcm.log

python pwrblink.py
sleep 10
pkill -f pwrblink.py
python ./pwron.py

echo "$(time): Ready to go" >>/var/log/mcm.log
