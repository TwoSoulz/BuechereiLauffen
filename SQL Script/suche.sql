/*
Suche Buch Titel
*/
SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag
FROM buecherei.buch
JOIN buecher_autor
ON buch.buecher_autor_ID = buecher_autor.ID
JOIN buecher_genre
ON buch.buecher_genre_ID = buecher_genre.ID
JOIN buecher_verlage
ON buch.verlage_ID = buecher_verlage.ID
Where buch.Titel like "%(variable)%";

/*
Suche Autor
*/
SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag
FROM buecherei.buch
JOIN buecher_autor
ON buch.buecher_autor_ID = buecher_autor.ID
JOIN buecher_genre
ON buch.buecher_genre_ID = buecher_genre.ID
JOIN buecher_verlage
ON buch.verlage_ID = buecher_verlage.ID
Where buecher_autor.Autor like "%(variable)%";

/*
Suche Genre
*/
SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag
FROM buecherei.buch
JOIN buecher_autor
ON buch.buecher_autor_ID = buecher_autor.ID
JOIN buecher_genre
ON buch.buecher_genre_ID = buecher_genre.ID
JOIN buecher_verlage
ON buch.verlage_ID = buecher_verlage.ID
Where buecher_genre.Genre like "%(variable)%";

/*
Suche Verlag
*/
SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag
FROM buecherei.buch
JOIN buecher_autor
ON buch.buecher_autor_ID = buecher_autor.ID
JOIN buecher_genre
ON buch.buecher_genre_ID = buecher_genre.ID
JOIN buecher_verlage
ON buch.verlage_ID = buecher_verlage.ID
Where buecher_verlage.Verlag like "%(variable)%";

/*
Suche ISBN
*/
SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag
FROM buecherei.buch
JOIN buecher_autor
ON buch.buecher_autor_ID = buecher_autor.ID
JOIN buecher_genre
ON buch.buecher_genre_ID = buecher_genre.ID
JOIN buecher_verlage
ON buch.verlage_ID = buecher_verlage.ID
Where buch.ISBN = "(variable)";

/*
Suche Alles 
*/
SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag
FROM buecherei.buch
JOIN buecher_autor
ON buch.buecher_autor_ID = buecher_autor.ID
JOIN buecher_genre
ON buch.buecher_genre_ID = buecher_genre.ID
JOIN buecher_verlage
ON buch.verlage_ID = buecher_verlage.ID
Where buch.Titel LIKE "%(variable)%"
or buecher_autor.Autor LIKE "%(variable)%"
or buecher_genre.Genre LIKE "%(variable)%"
or buecher_verlage.Verlag LIKE "%(variable)%"
or buch.ISBN like "%(variable)%";