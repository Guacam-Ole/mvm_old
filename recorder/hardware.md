# Hardware
Normalerweise sollte niemand an der Hardware rumschrauben müssen, aber ich kenn ja meine Pappenheimer :)
Es handelt sich um einen einfachen Raspberry 4.
Öffnet den Deckel bitte vorsichtig, damit sich keine Drähte lösen

## Buttons
Die Buttons sind am GPIO angeschlossen. Folgende Belegung wird erwartet:
(Die grauen Adern eines Buttons sind beliebig tauschbar)

| Art | Farbe | PIN | Bezeichnung |
|-----|-------|------|-------------|
|Power-LED Masse | Schwarz | 6 | GND |
|Power-LED Signal | Rot | 8 | GPIO 14 |
|Power-Button | Grau | 9 | GND | 
|Power-Button | Grau | 5 | GPIO 3 |
|Record-LED Masse | Schwarz | 20 | GND |
|Record-LED Signal | Blau | 19 | GPIO 10 |
|Record-Button | Grau | 14 | GND |
|Record-Button | Grau | 13 | GPIO 27 |
