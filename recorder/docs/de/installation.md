# Installation
Die MvM-Box sollte eigentlich nicht angefasst werden müssen. Sollte es jedoch dazu kommen dass die SD-Karte ihren Geist aufgibt kann das System einfach neu aufgesetzt werden.

## OS
Installiert dazu einfach die aktuellste Raspbian.OS - Version und aktualisiert es am Besten gleich:
```Shell
sudo asp-get update
sudo asp-get dist-upgrade
```

### Grundeinstellungen
Derzeit reichen die Standard-Libraries die bei einer "normalen" Installation von Raspbian.OS dabei sind. Es sollte nur noch der Hostname und das Passwort angepasst werden.

Hostname:
`sudo nano /etc/hostname` (tragt hier "mvm") ein

Passwort:
`sudo passwd` Tragt hier das Passwort ein, das auf dem Zettel steht den ihr haben solltet. :)

## Scripte
Nachdem Linux jetzt soweit läuft fehlen nur noch die Scripte. Wechselt dazu ins Verzeichnis `/home/pi` und installiert die Scripte von Git neu:


```Shell
git init
git remote add -f origin https://github.com/OleAlbers/mvm
git config core.sparsecheckout true
echo recorder/scripts/ > .git/info/sparse-checkout
git pull origin master
```

Im Anschluss solltet ihr ein Verzeichnis `/home/pi/recorder/scripts/` haben in dem die Dateien liegen
