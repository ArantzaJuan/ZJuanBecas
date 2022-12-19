CREATE DATABASE ZJuanBeca
USE  ZJuanBeca

CREATE TABLE Alumno
(IdAlumno INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR (50),
ApellidoPaterno VARCHAR (50),
ApellidoMaterno VARCHAR (50),
Genero BIT,
Edad INT)
INSERT INTO Alumno(Nombre,ApellidoPaterno,ApellidoMaterno,Genero,Edad )
VALUES ('Arantza','Juan','Alfonso','1',23)
INSERT INTO Alumno(Nombre,ApellidoPaterno,ApellidoMaterno,Genero,Edad )
VALUES ('Enrique','Juan','Alfonso','1',19)
-----------------------------------  BECA  ------------------------------
CREATE TABLE Beca
(IdBeca INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR (50))
INSERT INTO Beca(Nombre)
VALUES ('Beca educativa')
INSERT INTO Beca(Nombre)
VALUES ('Beca cultural')
INSERT INTO Beca(Nombre)
VALUES ('Beca deportiva')
-------------------------------------  BecaAlumno   --------------------
CREATE TABLE BecaAlumno
(IdBecaAlumno INT PRIMARY KEY IDENTITY(1,1),
IdAlumno INT FOREIGN KEY REFERENCES Alumno(IdAlumno),
IdBeca INT FOREIGN KEY REFERENCES Beca(IdBeca),
IdBeca2 INT FOREIGN KEY REFERENCES Beca(IdBeca))
INSERT INTO BecaAlumno(IdAlumno,IdBeca,IdBeca2)
VALUES (1,2,null)

