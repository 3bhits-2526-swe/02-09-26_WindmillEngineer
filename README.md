# Windrad-System - Virtual Engineering Konzept

**Name / Gruppe:** Our Whole World  
## Teammitglieder

- Wolf Fabian
- Auer Manuel
- Forster Laurin

---

## Pitch

Windrad-System ist eine interaktive Simulation eines Stromnetzes. Die Spieler müssen defekte Windräder reparieren, um die Energieversorgung aufrechtzuerhalten und einen zentralen Akku vollständig aufzuladen. Das Projekt zeigt die Herausforderungen von Energieerzeugung, Wartung und Netzstabilität auf spielerische Weise.

---

## 1. System in einem Satz
Unser System simuliert den Supply und Demand eines Stromnetzes mit einer angeschlossenen Stadt. Dabei gibt es mehrere Windräder, die immer wieder kaputt gehen und repariert werden müssen. Das Ziel des Spiels ist es, einen Akku vollständig aufzuladen – sobald dieser voll ist, hat man gewonnen.

---

## 2. Input → Verarbeitung → Output

| Input | Verarbeitung | Output |
| :--- | :--- | :--- |
| Den zu reparierenden Teil zum Windrad ziehen | Windrad wurde repariert | Windrad produziert wieder Strom |

---

## 3. Regeln
* Wenn ein Windrad kaputt geht, muss man es reparieren.
* Wenn der Akku leer ist und der Supply (Angebot) niedriger ist als der Demand (Nachfrage), heißt es: Game Over.
* Wenn der Akku fertig geladen wurde, hat man gewonnen.

---

## MVP

Der aktuelle MVP umfasst:

- Mehrere Windräder mit zufälligen Ausfällen
- Reparaturmechanik für defekte Windräder
- Simulation von Stromangebot und Stromnachfrage
- Akku als Energiespeicher
- Gewinnbedingung bei vollständig geladenem Akku
- Verlustbedingung bei leerem Akku und zu geringer Stromproduktion

---
## 4. Virtual Engineering Anteil
Folgende Virtual Engineering Komponenten sind Teil des Projekts:
* [x] Anzeige (Dashboard / Unity)
* [ ] Digital Twin
* [ ] Live-Daten (Internet)
* [x] Simulation
* [x] Fehlererkennung

---

## 5. Interaktion
**Was kann ein Besucher tun?**
* Interaktion mit den Windrädern (z.B. Reparaturteile zuweisen).

## 6. Skizze
*(Hier sollte ein Bild oder eine Grafik der Skizze des Systems eingefügt werden, die Windräder, eine Lampe, eine Anzeige und Pfeile zeigt)*
