/*
-- Query: Select * FROM mitarbeiter
LIMIT 0, 1000

-- Date: 2017-12-18 09:45
*/
INSERT INTO `mitarbeiter` (`ID`,`Vorname`,`Passwort`) VALUES (NULL,'Can','Start123');
INSERT INTO `mitarbeiter` (`ID`,`Vorname`,`Passwort`) VALUES (NULL,'Kevin','Start123');
INSERT INTO `mitarbeiter` (`ID`,`Vorname`,`Passwort`) VALUES (NULL,'Florian','Start123');
INSERT INTO `mitarbeiter` (`ID`,`Vorname`,`Passwort`) VALUES (NULL,'Sebastian','Start123');

/*
-- Query: select * From buecher_autor
LIMIT 0 1000

-- Date: 2017-12-20 10:40
*/
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Adrian Leemann');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Andreas Brandhorst');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Arabella Carter-Johnson');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Ben Bova');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Brandon Sanderson');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Brenda Novak');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Charles Dickens');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Charlotte link');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Christian Haller');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'ConCrafter');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Dan Brown');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Dick Bruna');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Felix Francis');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Heinrich Böll');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'J.D. Barker');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Jeffrey Archer');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Jessica Gilmore');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Jörg Maurer');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Julie von Kessel');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Karin Alvtegen');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Kerrelyn Sparks');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Lina Wolff');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Maria Blumencron');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Mary Basson');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Norbert Frei');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Norbert Lammert');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Paul Hawkins');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Raywen White');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Rotraut Susanne Berner');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Rudolph Herzog');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Sabine Kray');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Salman Rushdie');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Seressia Glass');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Stephen King');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Trudi Canvan');
INSERT INTO `buecher_autor` (`ID`,`Autor`) VALUES (NULL,'Ulf Schiewe');

/*
-- Query: SELECT * FROM buecher_verlage
LIMIT 0, 1000

-- Date: 2017-12-15 08:23
*/
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (1,'Aufbau-Verlag ');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (2,'Bastei Lübbe ');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (3,'C. Bertelsmann Verlag (Random House) ');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (4,'Blanvalet Verlag ');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (5,'Cora Verlag ');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (6,'Diogenes');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (7,'Droemer (Droemer Knaur/Weltbild)');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (8,'DTV Deutscher Taschenbuch Verlag');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (9,'Dumont Buchverlag');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (10,'Fischer Verlage');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (11,'Hanser (Carl Hanser Verlage)');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (12,'Heyne Verlag (Random House)');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (13,'Hoffmann und Campe');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (14,'Kiepenheuer & Witsch');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (15,'Piper Verlag ');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (16,'Rowohlt');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (17,'Suhrkamp / Insel ');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (18,'Ullstein Verlage (Allegria, Claasen, Econ, Li)');
INSERT INTO `buecher_verlage` (`ID`,`Verlag`) VALUES (19,'Goldmann Verlag');

/*
-- Query: SELECT * FROM buecher_genre
LIMIT 0, 1000

-- Date: 2017-12-15 08:23
*/
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Krimi');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Thriller');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Horror');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Sachbuch');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Fachliteratur');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Roman');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Kinderbücher');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Hörbuch');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Drama');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Action');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Abenteuer');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Liebesroman');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Fantasy & Science-Fiction');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Ratgeber');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Jugend');
INSERT INTO `buecherei`.`buecher_genre` (`Genre`) VALUES ('Historik');

/*
-- Query: SELECT * FROM buecherei.buch
LIMIT 0, 1000

-- Date: 2018-02-07 09:40
*/
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783257012170','miffy',12,7,6);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783257300512','Scharade',13,6,6);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783404609628','Iris und Thula',3,4,2);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783423078177','Gefangen in New York',4,6,8);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783423349208','Jugendrevolte und globaler Protest',25,4,8);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783426520031','Odins Blut Raben',36,6,7);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783426521625','Sugar und Spice',33,12,7);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783431039993','Origin',11,2,2);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783442715831','Das verborgene Ufer',9,6,19);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783446237605','Große Erwartungen',7,6,11);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783446255241','Hallo Karlchen',29,7,11);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783453421776','Winter eines Lebens',16,6,19);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783453439078','Mindcontrol',34,6,12);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783455001075','Bret Eastion Ellis und die anderen Hunde',22,6,13);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783455002669','Freiheit von der Pille',31,6,13);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783462051551','Der Panzer zielte auf Kafka',14,4,14);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783462051704','Heil Hitler das Schwein ist Tot!',30,4,14);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783492060806','Das Erwachen',2,13,15);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783492704441','Bänder der Trauer',5,13,15);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783518468876','Wer vertritt das Volk?',26,4,17);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783548376974','How to take over earth',27,13,18);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783570103333','Golden House',32,6,3);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783596701490','Stille Nacht allerseits',18,7,10);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783641023232','Die Meisterin',35,13,3);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783641193539','1408',34,3,12);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783644402874','Grüezi, Moin, Servus',1,4,16);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783732415472','Altenstein',19,6,16);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783733503826','ConCrafter: Hallo mein Name ist Luca',10,4,10);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783733711641','Der Millionär und die geheimnisvolle Schöne',17,12,5);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783734105227','Die Entscheidung',8,1,4);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783746633381','Die Malerin',24,6,1);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783746633572','Ich töte dich',6,2,1);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783764506247','The Fourth Monkey',15,2,4);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783832161057','Schuld',20,1,9);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783832180584','Auf Wiedersehen, Tibet',23,4,9);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783955766696','Zum Beißen verführt',21,13,5);
INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`) VALUES ('9783958189225','Flammender Sturm',28,6,18);


