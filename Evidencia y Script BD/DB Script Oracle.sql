--Creación tabla de autores
CREATE TABLE Authors(
	Id INTEGER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL,
	FullName VARCHAR2(200) NOT NULL,
	BirthDate date NOT NULL,
	HomeCity VARCHAR2(50) NOT NULL,
	Email VARCHAR2(100) NOT NULL,
    BooksLimit Number(10) NOT NULL,
    CONSTRAINT PK_Authors PRIMARY KEY 
    (
        Id 
    ) 
);

--Creación tabla de libros

CREATE TABLE Books(
	Id INTEGER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL,
	Title VARCHAR2(200) NOT NULL,
	Year Number(10) NOT NULL,
	Gender VARCHAR2(100) NOT NULL,
	NumPages Number(10) NOT NULL,
	AuthorId INTEGER NOT NULL,
    CONSTRAINT PK_Books PRIMARY KEY 
    (
        Id 
    ),
    CONSTRAINT FK_AuthorId
    FOREIGN KEY (AuthorId)
    REFERENCES Authors(Id)
);

--Creación de usuario de BD y asignación de permisos necesarios
CREATE USER nexostest IDENTIFIED BY nexostest;
GRANT READ ANY TABLE TO nexostest;
GRANT CONNECT TO nexostest;
GRANT CREATE SESSION, GRANT ANY PRIVILEGE TO nexostest;
GRANT UNLIMITED TABLESPACE TO nexostest;
GRANT CREATE ANY TABLE TO nexostest;
GRANT ALTER ANY TABLE,
ALTER DATABASE,
QUERY REWRITE,
SELECT ANY TABLE,
SELECT ANY SEQUENCE,
SELECT ANY TRANSACTION 
TO "NEXOSTEST"

--Insertar autor de prueba
Insert into NEXOSTEST.AUTHORS (ID,FULLNAME,BIRTHDATE,HOMECITY,EMAIL,BOOKSLIMIT) values ('stiven ',to_date('26/02/95','DD/MM/RR'),'barranquilla','stevenvillamizar@hotmail.es','10');
--Insertar libro de prueba
Insert into BOOKS (ID,TITLE,YEAR,GENDER,NUMPAGES,AUTHORID) values ('un mundo feliz','2010','novela de aventuras.','200','1');



 

