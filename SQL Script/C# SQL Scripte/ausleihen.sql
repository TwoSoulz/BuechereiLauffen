--ReservierungsID herausfinden-
Select reservierungs_ID From reservierungen
Where Buch_ISBN like "9783423078177";

--IDLeser herausfinden
Select Leser_ID From reservierungen
Where reservierungs_ID like "ID reservierung";

--reservierung Löschen
Delete From reservierungen 
Where reservierungs_ID like ""

-------Asuleihen einstellen
--Überprüfung ob buch ausgeliehen ist
Select ausleihenid
From ausleihen
Where Buch_ISBN like "ISBN vom Buch wo reserviert werden soll"
--Wenn hierzu ein Wert rauskommt ist das Buch schon ausgeliehen und es soll stoppen

------Wenn as buch noch nicht ausgeliehem ist geht es hier weiter
--Hierzu wird die ID manuell erstellt 
Select Count(ausleihenid) + 1 From ausleihen;

--Hier wird das Ausleihen erstellt und die Manuelle ID muss hier eingeben werden, Die LeserID wird von oben(IdLeser herausfinden eingetragen)
--und Buch_ISBN von der ausgewählten ISBN
Insert Into `ausleihen` (`ausleihenid`,`Leser_ID`, `Buch_ISBN`) Values (manuelle ID, Leser_ID, Buch_ISBN);



--Ausleihen Löschen
DELETE From ausleihen
Where Buch_ISBN like "Buch_ISBN"

