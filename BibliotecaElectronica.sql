DROP TABLE IF EXISTS BibliotecaElectronica
CREATE DATABASE BibliotecaElectronica
--ON PRIMARY
--(
--Name = BibliotecaElectronica1,
--FileName = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Biblioteca\BibliotecaElectronica.mdf',
--size = 10MB, -- KB, Mb, GB, TB
--maxsize = unlimited,
--filegrowth = 1GB
--),
--(
--Name = BibliotecaElectronica2,
--FileName = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Biblioteca\BibliotecaElectronica.ndf',
--size = 10MB, -- KB, Mb, GB, TB
--maxsize = unlimited,
--filegrowth = 1GB
--)
--LOG ON
--(
--Name = BibliotecaElectronica_log,
--FileName = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Biblioteca\BibliotecaElectronica.ldf',
--size = 10MB, -- KB, Mb, GB, TB
--maxsize = unlimited,
--filegrowth = 1024MB
--)


--------------------------------------------------------- Creeare baza de date --------------------------------------------
DROP TABLE IF EXISTS Recenzie;
DROP TABLE IF EXISTS Notificare;
DROP TABLE IF EXISTS Tip_Notificare;
DROP TABLE IF EXISTS Imprumut;
DROP TABLE IF EXISTS Stoc;
DROP TABLE IF EXISTS Carte;
DROP TABLE IF EXISTS Categorie;
DROP TABLE IF EXISTS Administrator;
DROP TABLE IF EXISTS Bibliotecar;
DROP TABLE IF EXISTS Cititor;
DROP TABLE IF EXISTS Persoana;


-- Tabela Persoana
CREATE TABLE Persoana (
    ID INT PRIMARY KEY IDENTITY,
    Nume NVARCHAR(100) NOT NULL,
    Prenume NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Parola NVARCHAR(256) NOT NULL, -- Se recomandă criptarea parolelor
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Telefon NVARCHAR(20),
    Adresa NVARCHAR(255),
    DataNasterii DATE
);

-- Tabela Cititor
CREATE TABLE Cititor (
    ID INT PRIMARY KEY IDENTITY ,
    ID_Persoana INT FOREIGN KEY REFERENCES Persoana(ID),
    DataInregistrare DATE NOT NULL,
    NrCartiImprumutate INT DEFAULT 0
);



-- Tabela Bibliotecar
CREATE TABLE Bibliotecar (
    ID INT PRIMARY KEY,
    ID_Persoana INT FOREIGN KEY REFERENCES Persoana(ID),
    DataAngajare DATE NOT NULL
);

-- Tabela Administrator
CREATE TABLE Administrator (
    ID INT PRIMARY KEY,
    ID_Persoana INT FOREIGN KEY REFERENCES Persoana(ID)
);

-- Tabela Categorie
CREATE TABLE Categorie (
    ID INT PRIMARY KEY IDENTITY,
    Nume NVARCHAR(100) NOT NULL UNIQUE
);

-- Tabela Carte
CREATE TABLE Carte (
    ID INT PRIMARY KEY IDENTITY,
    Titlu NVARCHAR(200) NOT NULL,
    Autor NVARCHAR(100) NOT NULL,
    AnPublicare INT,
    ISBN NVARCHAR(20) NOT NULL UNIQUE, -- Adăugat câmpul ISBN
    ID_Categorie INT FOREIGN KEY REFERENCES Categorie(ID)
);



ALTER TABLE Carte
ADD Imagine VARBINARY(max);

-- Tabela Stoc
CREATE TABLE Stoc (
    ID INT PRIMARY KEY IDENTITY,
    ID_Carte INT FOREIGN KEY REFERENCES Carte(ID),
    NrExemplare INT NOT NULL DEFAULT 0
);

-- Tabela Imprumut
CREATE TABLE Imprumut (
    ID INT PRIMARY KEY IDENTITY,
    ID_Cititor INT FOREIGN KEY REFERENCES Cititor(ID),
    ID_Carte INT FOREIGN KEY REFERENCES Carte(ID),
    DataImprumut DATE NOT NULL,
    TermenLimita DATE NOT NULL,
    DataReturnare DATE,
    Stare NVARCHAR(50) NOT NULL DEFAULT 'Activ' -- Exemplu: 'Activ', 'Finalizat', 'Intarziat'
);

CREATE TABLE Notificare (
    ID INT PRIMARY KEY IDENTITY,
    ID_Cititor INT FOREIGN KEY REFERENCES Cititor(ID),
    Tip_Notificare NVARCHAR(100) NOT NULL, -- Tipul notificării (ex: "Returnare întârziată")
    Mesaj NVARCHAR(500) NOT NULL, -- Mesajul notificării
    DataTrimitere DATE NOT NULL, -- Data trimiterii notificării
    Stare NVARCHAR(50) NOT NULL DEFAULT 'Necitit' -- Exemplu: 'Necitit', 'Citit'
);

-- Tabela Recenzie
CREATE TABLE Recenzie (
    ID INT PRIMARY KEY IDENTITY,
    ID_Cititor INT FOREIGN KEY REFERENCES Cititor(ID),
    ID_Carte INT FOREIGN KEY REFERENCES Carte(ID),
    Nota INT CHECK (Nota BETWEEN 1 AND 5),
    Comentariu NVARCHAR(500),
    DataRecenzie DATE NOT NULL
);

----------------------------------------------- Populare baza de date ----------------------------------------
-- Populare tabel Categorie
INSERT INTO Categorie (Nume) 
VALUES 
('Ficțiune'), 
('Non-ficțiune'), 
('Romantic'), 
('Fantasy'), 
('Istorie'), 
('Știință'), 
('Self-help'), 
('Mister'), 
('Aventură'), 
('Biografie');

-- Populare tabel Carte
INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie) 
VALUES 
('Marele Gatsby', 'F. Scott Fitzgerald', 1925, '978-0743273565', 1), 
('1984', 'George Orwell', 1949, '978-0451524935', 1), 
('Harry Potter și Piatra Filozofală', 'J.K. Rowling', 1997, '978-0439708180', 4), 
('Sapiens: O scurtă istorie a omenirii', 'Yuval Noah Harari', 2011, '978-0062316110', 6), 
('Arta subtilă a nepăsării', 'Mark Manson', 2016, '978-0062457714', 7), 
('Sherlock Holmes: Aventurile', 'Arthur Conan Doyle', 1892, '978-0141034355', 8), 
('Cei trei mușchetari', 'Alexandre Dumas', 1844, '978-0199538461', 9), 
('Steve Jobs: Biografie', 'Walter Isaacson', 2011, '978-1451648539', 10), 
('Doamna Bovary', 'Gustave Flaubert', 1856, '978-1853260780', 3), 
('Călătoria fantastică', 'Isaac Asimov', 1966, '978-0553275728', 4);

-- Populare tabel Persoana
INSERT INTO Persoana (Nume, Prenume, Username, Parola, Email, Telefon, Adresa, DataNasterii)
VALUES 
('Popescu', 'Ion', 'ionpopescu', HASHBYTES('SHA2_256', 'parola123'), 'ion.popescu@example.com', '0712345678', 'Str. Exemplu, Nr. 1', '1985-07-14'),
('Ionescu', 'Maria', 'mariaionescu', HASHBYTES('SHA2_256', 'parola456'), 'maria.ionescu@example.com', '0723456789', 'Str. Exemplelor, Nr. 5', '1990-03-22'),
('Dumitrescu', 'Andrei', 'andreid', HASHBYTES('SHA2_256', 'parola789'), 'andrei.d@example.com', '0734567890', 'Bd. Revoluției, Nr. 10', '1988-12-01'),
('Georgescu', 'Elena', 'elenag', HASHBYTES('SHA2_256', 'parola999'), 'elena.g@example.com', '0701234567', 'Str. Libertății, Nr. 20', '1995-05-17');

-- Populare tabel Cititor
INSERT INTO Cititor ( ID_Persoana, DataInregistrare, NrCartiImprumutate)
VALUES 
( 1, GETDATE(), 2),
( 2, GETDATE(), 1);

-- Populare tabel Bibliotecar
INSERT INTO Bibliotecar (ID, ID_Persoana, DataAngajare)
VALUES 
(1, 3, '2015-09-01');

-- Populare tabel Administrator
INSERT INTO Administrator (ID, ID_Persoana)
VALUES 
(1, 4);

select * from Persoana where ID=4

-- Populare tabel Stoc
INSERT INTO Stoc (ID_Carte, NrExemplare)
VALUES 
(1, 5), 
(2, 3), 
(3, 7), 
(4, 4), 
(5, 2), 
(6, 6), 
(7, 3), 
(8, 1), 
(9, 4), 
(10, 2);

-- Populare tabel Imprumut
INSERT INTO Imprumut (ID_Cititor, ID_Carte, DataImprumut, TermenLimita, DataReturnare, Stare)
VALUES 
(1, 1, GETDATE() - 10, GETDATE() + 20, NULL, 'Activ'),
(2, 3, GETDATE() - 15, GETDATE() + 15, GETDATE() - 5, 'Finalizat'),
(1, 2, GETDATE() - 5, GETDATE() + 25, NULL, 'Activ');

-- Populare tabel Tip_Notificare
INSERT INTO Tip_Notificare (Mesaj)
VALUES 
('Termenul limită pentru returnarea cărții este aproape'),
('Cartea a fost returnată cu întârziere'),
('Aveți o notificare nouă în cont');

-- Populare tabel Notificare
INSERT INTO Notificare (ID_Cititor, ID_Tip_Notificare, DataTrimitere, Stare)
VALUES 
(1, 1, GETDATE() - 3, 'Necitit'),
(2, 2, GETDATE() - 10, 'Citit');

-- Populare tabel Recenzie
INSERT INTO Recenzie (ID_Cititor, ID_Carte, Nota, Comentariu, DataRecenzie)
VALUES 
(1, 1, 5, 'O carte incredibilă, plină de emoție.', GETDATE() - 20),
(2, 3, 4, 'Mi-a plăcut mult, dar aș fi vrut mai multe detalii.', GETDATE() - 15),
(1, 5, 3, 'Interesantă, dar nu este genul meu preferat.', GETDATE() - 10);



select * from Cititor

select * from Persoana

INSERT INTO Persoana (Nume, Prenume, Username, Parola, Email, Telefon, Adresa, DataNasterii)
VALUES 
('Sofianu', 'Gabriela', 'gabsof', 'parola', 'gabsofianu@gmail.com', '0712345678', 'Str. Exemplu, Nr. 1', '1985-07-14')

select * from Persoana

INSERT INTO Cititor (ID_Persoana, DataInregistrare, NrCartiImprumutate)
VALUES 
( 4, GETDATE(), 2)

set identity_insert Cititor ON


INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Marele Gatsby' AS Titlu,
    'F. Scott Fitzgerald' AS Autor,
    1925 AS AnPublicare,
    '978-0743273565' AS ISBN,
    1 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\marele_gatsby.jpeg', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    '1984' AS Titlu,
    'George Orwell' AS Autor,
    1949 AS AnPublicare,
    '978-0451524935' AS ISBN,
    1 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\1984.jpeg', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Harry Potter și Piatra Filozofală' AS Titlu,
    'J.K. Rowling' AS Autor,
    1997 AS AnPublicare,
    '978-0439708180' AS ISBN,
    4 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\Harry Potter și Piatra Filozofală.jpg', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Sapiens: O scurtă istorie a omenirii' AS Titlu,
    'Yuval Noah Harari' AS Autor,
    2011 AS AnPublicare,
    '978-0062316110' AS ISBN,
    6 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\Sapiens O scurta istorie a omenirii.jpg', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Arta subtilă a nepăsării' AS Titlu,
    'Mark Manson' AS Autor,
    2016 AS AnPublicare,
    '978-0062457714' AS ISBN,
    7 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\Arta subtila a nepasarii.webp', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Sherlock Holmes: Aventurile' AS Titlu,
    'Arthur Conan Doyle' AS Autor,
    1892 AS AnPublicare,
    '978-0141034355' AS ISBN,
    8 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\Aventurile lui Sherlock Holmes.webp', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Cei trei mușchetari' AS Titlu,
    'Alexandre Dumas' AS Autor,
    1844 AS AnPublicare,
    '978-0199538461' AS ISBN,
    9 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\Cei trei muschetari.jpg', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Steve Jobs: Biografie' AS Titlu,
    'Walter Isaacson' AS Autor,
    2011 AS AnPublicare,
    '978-1451648539' AS ISBN,
    10 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\Steve Jobs Biografie.jpg', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Doamna Bovary' AS Titlu,
    'Gustave Flaubert' AS Autor,
    1856 AS AnPublicare,
    '978-1853260780' AS ISBN,
    3 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\Doamna Bovary.webp', SINGLE_BLOB) AS ImageData;

INSERT INTO Carte (Titlu, Autor, AnPublicare, ISBN, ID_Categorie, Imagine)
SELECT 
    'Călătoria fantastică' AS Titlu,
    'Isaac Asimov' AS Autor,
    1966 AS AnPublicare,
    '978-0553275728' AS ISBN,
    5 AS ID_Categorie,
    BulkColumn AS Imagine
FROM OPENROWSET(BULK 'C:\Users\gabso\OneDrive\Desktop\ProiectBaze\Calatoria fantastica.webp', SINGLE_BLOB) AS ImageData;


INSERT INTO Persoana (Nume, Prenume, Username, Parola, Email, Telefon, Adresa, DataNasterii)
VALUES 
('a', 'a', 'a', 'a', 'a', 'a', 'Str. Exemplu, Nr. 1', '1985-07-14')

select * from Cititor

Alter TRIGGER trg_UpdateNrCartiImprumutate
ON Imprumut
AFTER INSERT
AS
BEGIN
    -- Actualizează numărul de cărți împrumutate pentru fiecare cititor
   UPDATE Cititor
    SET NrCartiImprumutate = NrCartiImprumutate + (
        SELECT COUNT(*) 
        FROM Inserted 
        WHERE Inserted.ID_Cititor = Cititor.ID
    )
    WHERE ID IN (
        SELECT ID_Cititor 
        FROM Inserted
    );
END;

INSERT INTO Imprumut (ID_Cititor, ID_Carte, DataImprumut, TermenLimita, DataReturnare, Stare)
VALUES 
(13, 8, GETDATE() - 10, GETDATE() + 20, NULL, 'Activ'),
(13, 9, GETDATE() - 15, GETDATE() + 15, GETDATE() - 5, 'Activ'),
(13, 10, GETDATE() - 5, GETDATE() + 25, NULL, 'Activ');


select * from carte

CREATE PROCEDURE SetFinalizatPentruImprumuturiFinalizate
AS
BEGIN
    -- Actualizează starea la 'Finalizat' pentru înregistrările care au DataReturnare nenulă
    UPDATE Imprumut
    SET Stare = 'Finalizat'
    WHERE DataReturnare IS NOT NULL;
END;

EXEC SetFinalizatPentruImprumuturiFinalizate;

ALTER TABLE Carte
add Descriere NVARCHAR(300);

INSERT INTO Recenzie (ID_Cititor, ID_Carte, Nota, Comentariu, DataRecenzie)
VALUES 
(1, 1, 5, N'O capodoperă literară, cu o poveste captivantă și personaje memorabile.', '2024-12-01'),
(2, 1, 4, N'Foarte bună, dar am simțit că finalul a fost ușor grăbit.', '2024-12-02'),
(3, 1, 3, N'Poveste interesantă, însă stilul de scriere nu este pe gustul meu.', '2024-12-03'),
(4, 1, 5, N'Un roman clasic ce merită citit de toată lumea.', '2024-12-04'),
(5, 1, 4, N'Povestea este minunată, dar unele pasaje au fost prea descriptive.', '2024-12-05'),
(6, 1, 2, N'Nu mi-a plăcut. Prea multă dramă și personaje greu de înțeles.', '2024-12-06'),
(7, 1, 5, N'Un roman fascinant, cu multe lecții de viață.', '2024-12-07'),
(8, 1, 3, N'M-a impresionat doar parțial. Unele părți sunt plictisitoare.', '2024-12-08'),
(9, 1, 4, N'Excelent, dar mi-ar fi plăcut să aflu mai multe despre anumite personaje.', '2024-12-09'),
(10, 1, 5, N'Un roman extraordinar, care m-a ținut în priză până la ultima pagină.', '2024-12-10');


UPDATE Carte
SET Descriere = 'Nick Carraway, un tanar atras de visul american, proaspat sosit la New York, intra in lumea fascinanta a lui Jay Gatsby, o lume a succesului si a iluziei.
Pe fundalul Americii anilor 1920, Gatsby, impins de iubirea fata de Daisy Buchanan, isi schimba complet existenta, transformandu-se dintr-un tanar sarac in traficant de bauturi alcoolice si apoi milionar.
In ciuda petrecerilor grandioase a caror gazda este, Gatsby ascunde o nemarginita nefericire. Tot ce face este destinat sa-i atraga atentia lui Daisy, insa iubirea sa nu ajunge sa se implineasca niciodata...
Carte emblematica a "generatiei pierdute", Marele Gatsby este, conform Washington Post, "al doilea mare roman in limba engleza al secolului XX, dupa Ulise, de James Joyce".'
WHERE Titlu = 'Marele Gatsby';

select * from Recenzie
select * from Carte

ALTER TABLE Carte
ADD NumarPagini INT, -- Numărul de pagini
    Dimensiune NVARCHAR(50), -- Dimensiunea cărții (ex: "20x25cm")
    Editura NVARCHAR(100); -- Numele editurii

	UPDATE Carte
SET NumarPagini = 200, -- Numărul de pagini
    Dimensiune = '15x22cm', -- Dimensiunea cărții
    Editura = 'Editura Humanitas' -- Numele editurii
WHERE ID = 1; -- Cartea cu ID=1


select * from Stoc

select * from Persoana

CREATE TRIGGER trg_UpdateStocOnInsert
ON Imprumut
AFTER INSERT
AS
BEGIN
    -- Actualizează numărul de exemplare din tabelul Stoc
    UPDATE Stoc
    SET NrExemplare = NrExemplare - 1
    FROM Stoc
    INNER JOIN inserted ON Stoc.ID_Carte = inserted.ID_Carte
    WHERE Stoc.NrExemplare > 0; -- Asigură că nu scade sub 0

    -- Opțional: gestionează situațiile în care nu există stoc disponibil
    IF EXISTS (
        SELECT 1
        FROM Stoc
        INNER JOIN inserted ON Stoc.ID_Carte = inserted.ID_Carte
        WHERE Stoc.NrExemplare < 0
    )
    BEGIN
        THROW 50001, 'Stoc insuficient pentru cartea selectată.', 1;
    END
END;

CREATE TABLE Feedback (
    ID INT PRIMARY KEY IDENTITY, 
    ID_Recenzie INT NOT NULL, 
    NrLike INT NOT NULL DEFAULT 0, 
    NrDislike INT NOT NULL DEFAULT 0, 
    FOREIGN KEY (ID_Recenzie) REFERENCES Recenzie(ID)
);

select * from Recenzie


-- Adăugarea unor valori în tabela Feedback
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (1, 15, 3);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (10, 20, 5);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (11, 8, 0);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (12, 12, 4);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (13, 25, 7);

INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (2, 15, 3);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (3, 20, 5);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (4, 8, 0);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (5, 12, 4);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (6, 25, 7);

INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (7, 15, 3);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (8, 20, 5);
INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (9, 8, 0);

INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike) VALUES (17, 0, 0);
select * from Recenzie
select * from Feedback


CREATE TRIGGER trg_AfterInsertRecenzie
ON Recenzie
AFTER INSERT
AS
BEGIN

    INSERT INTO Feedback (ID_Recenzie, NrLike, NrDislike)
    SELECT ID, 0, 0
    FROM inserted;
END;


CREATE TRIGGER trg_UpdateNrExemplareOnReturn
ON Imprumut
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Inserted
        WHERE DataReturnare IS NOT NULL
    )
    BEGIN
        UPDATE Stoc
        SET NrExemplare= NrExemplare + 1
        FROM Stoc
        INNER JOIN Inserted ON Stoc.ID_Carte= Inserted.ID_Carte
        WHERE Inserted.DataReturnare IS NOT NULL;
    END
END;

CREATE TABLE TaskLogs (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    TaskName NVARCHAR(100) NOT NULL,
    LastRunTime DATETIME NOT NULL  
);

INSERT INTO Imprumut (ID_Cititor, ID_Carte, DataImprumut, TermenLimita, DataReturnare, Stare)
VALUES 
(13, 1, GETDATE() - 10, GETDATE() -1, NULL, 'Activ')

select * from Imprumut

select * from Notificare

select * from TaskLogs

DELETE FROM TaskLogs
WHERE ID = 3



delete from Notificare
where id=6

select * from Cititor
select * from Persoana

ALTER TABLE Notificare
ALTER COLUMN DataTrimitere DATETIME NOT NULL;

UPDATE Notificare
SET DataTrimitere = DATEADD(HOUR, 17, DataTrimitere) -- Adaugă ora 12:00 pentru toate intrările
WHERE CAST(DataTrimitere AS TIME) = '00:00:00';


