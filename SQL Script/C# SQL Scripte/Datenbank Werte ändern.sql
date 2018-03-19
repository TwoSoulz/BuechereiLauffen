------------------------------------Autor Ändern--------------------------------------------------------------

----Erstmal überprüfen ob der Autor überhaupt existiert

SELECT buecher_autor.ID 
FROM buecherei.buecher_autor
Where buecher_autor.Autor like "(geändeter Autor im Programm)";
--Wenn dieser Autor nicht existiert wird der wert "nichts" zurück gegeben, wenn der Autor existiert wird die "ID" zurückgegeben, die man dann
--als änderung eintragen kann


----Wenn der Autor nicht vorhanden ist wird er Hier erstellt

--Autor wird erstellt
INSERT INTO `buecher_autor` (`Autor`) VALUES ('(der neue Autor)'); 

--Jetzt wird nach dem seiner neuen ID gesucht
SELECT buecher_autor.ID 
FROM buecherei.buecher_autor
Where buecher_autor.Autor like "(der neue Autor)";
-- die wird dann zurückgeggeben 



------------------------------------Genre Ändern--------------------------------------------------------------
----Erstmal überprüfen ob das Genre überhaupt existiert
SELECT buecher_genre.ID
From buecherei.buecher_genre
Where buecher_genre.Genre like "(geändetes Genre im Programm)";
--Wenn das Genre nicht existiert wird der wert "nichts" zurück gegeben, wenn das Genre existiert wird die "ID" zurückgegeben, die man dann
--als änderung eintragen kann


----Wenn das Genre nicht vorhanden ist wird es Hier erstellt

--Genre wird erstellt
INSERT INTO `buecher_genre` (`Genre`) VALUES ('(das neue Genre)'); 

--Jetzt wird nach dem seiner neuen ID gesucht
SELECT buecher_genre.ID 
FROM buecherei.buecher_genre
Where buecher_genre.Genre like "(das neue Genre)";
--die wird dann zurückgegeben




------------------------------------Verlag Ändern--------------------------------------------------------------

----Erstmal überprüfen ob der Verlag überhaupt existiert

SELECT buecher_verlage.ID 
FROM buecherei.buecher_verlage
Where buecher_verlage.Verlag like "(geändeter Verlag im Programm)";
--Wenn dieser Verlag nicht existiert wird der wert "nichts" zurück gegeben, wenn der Verlag existiert wird die "ID" zurückgegeben, die man dann
--als änderung eintragen kann


----Wenn der Verlag nicht vorhanden ist wird er Hier erstellt

--Verlag wird erstellt
INSERT INTO `buecher_verlage` (`Verlag`) VALUES ('(der neue Verlag');

--Jetzt wird nach dem seiner neuen ID gesucht
SELECT buecher_verlage.ID 
FROM buecherei.buecher_verlage
Where buecher_verlage.Verlag like "(der neue Verlag)";
-- die wird dann zurückgeggeben 




--------------------------------------Zum Schluss wird das Buch dann aktualisiert---------------------------------
UPDATE buch
Set buch.Titel="(der neue Titel)", buecher_Autor_ID="(der neue Autor)", buecher_genre_ID=""(das neue Genre)";", verlage_ID="(der neue Verlag)"
Where buch.ISBN = "(Die ISBN von dem wo es geänder werden soll)";

