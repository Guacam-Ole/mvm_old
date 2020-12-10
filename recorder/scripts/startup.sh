ts()
{
 date +"%Y-%m-%d %T"
}

cd /home/pi/recorder/recorder
dotnet build recorder.csproj
cd bin/Debug/netcoreapp3.1
echo "$(ts) Power on. Initiatlizing" >>/home/pi/recorder/recorder/mvm.log
mount /dev/sda1 /mnt/usb -o uid=pi,gid=pi
echo "$(ts) Usb mounted" >>/home/pi/recorder/recorder/mvm.log
./recorder
echo "$(ts) recording stopped" >>/home/pi/recorder/recorder/mvm.log
