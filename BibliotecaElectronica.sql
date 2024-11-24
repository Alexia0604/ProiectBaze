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
ADD Imagine NVARCHAR(255);

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

-- Tabela Tip_Notificare
CREATE TABLE Tip_Notificare (
    ID INT PRIMARY KEY IDENTITY,
    Mesaj NVARCHAR(500) NOT NULL -- Mesajul specific fiecărui tip de notificare
);

-- Tabela Notificare
CREATE TABLE Notificare (
    ID INT PRIMARY KEY IDENTITY,
    ID_Cititor INT FOREIGN KEY REFERENCES Cititor(ID),
    ID_Tip_Notificare INT FOREIGN KEY REFERENCES Tip_Notificare(ID), -- Asociere cu Tip_Notificare
    DataTrimitere DATE NOT NULL,
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


UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\marele_gatsby.jpeg' 
WHERE Titlu = 'Marele Gatsby';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\1984.jpeg' 
WHERE Titlu = '1984';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Harry Potter și Piatra Filozofală.jpg' 
WHERE Titlu = 'Harry Potter și Piatra Filozofală';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Sapiens O scurta istorie a omenirii.jpg' 
WHERE Titlu = 'Sapiens: O scurta istorie a omenirii';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Arta subtila a nepasarii.webp' 
WHERE Titlu = 'Arta subtila a nepasarii';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Aventurile lui Sherlock Holmes.webp' 
WHERE Titlu = 'Sherlock Holmes: Aventurile';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Cei trei muschetari.jpg' 
WHERE Titlu = 'Cei trei mușchetari';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Calatoria fantastica.webp' 
WHERE Titlu = 'Steve Jobs: Biografie';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\Doamna Bovary.webp' 
WHERE Titlu = 'Doamna Bovary';

UPDATE Carte 
SET Imagine = 'C:\Users\draga\Desktop\Anul 3\Sem I\Aplicatii baze de date\aplicatie\marele_gatsby.jpeg' 
WHERE Titlu = 'Calatoria fantastica';


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
