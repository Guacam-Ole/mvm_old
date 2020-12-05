# Troubleshooting
Eigentlich ist ja gerade Sinn der Box dass man sich um nix kümmern muss. Falls man aber doch eine Neuinstallation vornimmt oder dieses Projekt einfach als Grundlage für eine eigene Lösung kann man über folgende Wege prüfen ob alles geht. (Grundlegende Linux-Kenntnisse vorausgesetzt)

## LED - Test
Wechselt in das Verzeichnis `/home/pi/recorder/scripts`. Hier könnt ihr die LED-Scripte einzeln ansteuern:

| Befehl | Funktiion |
|--|--|
|`python recblink.py`|Aufnahmebutton blinkt (abbruch mit strg-c)|
|`python recon.py` | Aufnahmebutton leuchtet dauerhaft |
|`python recoff.py` | Aufnahmebutton ist aus |
|`python pwrblink.py`|Powerbutton blinkt (abbruch mit strg-c)|
|`python pwron.py` | Powerbutton leuchtet dauerhaft |
|`python pwroff.py` | Powerbutton ist aus |
