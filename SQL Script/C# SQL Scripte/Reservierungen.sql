SELECT leser.ID
FROM buecherei.leser
Where leser.Vorname like "Vorname"
And leser.Nachname like "Nachname"
And leser.Hausnummer like "Hausnummer"
And leser.Straße like "Straße"
And leser.PLZ like "PLZ";

--Wenn der Wert 0 ist, dann erstellt er einen neuen

Insert Into `leser` (`Vorname`, `Nachname`, `Hausnummer`, `Straße`, `Ort`, `PLZ`) VALUES ('Vorname','Nachname',Hausnummer,'Straße','ORT',PLZ);



------Beim neu erstellten User die Userid herausfinden
---Userid herausfinden 
SELECT leser.ID
FROM buecherei.leser
Where leser.Vorname like "Vorname"
And leser.Nachname like "Nachname"
And leser.Hausnummer like "Hausnummer"
And leser.Straße like "Straße"
And leser.PLZ like "PLZ";

-------Reservierung einstellen
--Überprüfung ob buch reserviert ist
Select reservierungen.reservierungs_id
From reservierungen
Where Buch_ISBN like "ISBN vom Buch wo reserviert werden soll"
--Wenn hierzu ein Wert rauskommt ist das Buch schon reserviert und die Reservierung stopt


------Wenn as buch noch nicht Reserviert ist geht es hier weiter
--Hierzu wird die ID manuell erstellt 
Select Count(reservierungs_id) + 1 From reservierungen;

--Hier wird die Reservierung erstellt und die Manuelle ID muss hier eingeben werden
Insert Into `reservierungen` (`reservierungs_id`,`Leser_ID`, `Buch_ISBN`) Values (manuelle ID, Leser_ID, Buch_ISBN);



------Reservierung Löschen
Delete FROM reservierungen
Where buch_ISBN like "Buch_ISBN";





