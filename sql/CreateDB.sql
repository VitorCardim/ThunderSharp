CREATE DATABASE TV;
/*use TV;*/
/* Drops Table
Drop table Reservation;
Drop table Production;
Drop table PersonGenres;
Drop table Genres;
Drop table Person;
Drop table Profile;
Drop Database TV;
*/

CREATE TABLE [dbo].[Profile] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [Label] [varchar](50) NOT NULL,
	[Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL,
    CONSTRAINT PK_Profile_Id PRIMARY KEY CLUSTERED (Id)
    )

INSERT INTO 
    Profile(Label,Created,Updated)
VALUES ('Actor/Actress',GETDATE(),GETDATE())

INSERT INTO 
    Profile(Label,Created,Updated)
VALUES ('Producer',GETDATE(),GETDATE())

CREATE TABLE [dbo].[Genres] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [Label] [varchar](20) NOT NULL,
	[Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL,
    CONSTRAINT PK_Genres_Id PRIMARY KEY CLUSTERED (Id)
    )

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Film',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Novel',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Series',GETDATE(),GETDATE())

CREATE TABLE [dbo].[Person] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NOT NULL,
    [Email] [varchar](50) NOT NULL Unique,
    [Age] [varchar](3) NOT NULL,
    [PhoneNumber] [varchar](15) NOT NULL, /* Because of international Numbers*/
    [Password] [varchar](255) NOT NULL,
    [ProfileId] [int] NOT NULL,
    [Fee] [Decimal],
	[Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL,
    CONSTRAINT PK_Person_Id PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Person_ProfileId FOREIGN KEY (ProfileId) REFERENCES [dbo].[Profile] (Id)
    )

INSERT INTO 
    Person(Name,Email,Age,PhoneNumber,Password,ProfileId,Fee,Created,Updated)
VALUES ('ProdutorOne','Produtor@gmail.com','50','999999999','qwasdsadsad',1,null,Getdate(),Getdate())

INSERT INTO 
    Person(Name,Email,Age,PhoneNumber,Password,ProfileId,Fee,Created,Updated)
VALUES ('ActorOne','ActorOne@gmail.com','22','999999999','qwasdsadsad',2,1231,Getdate(),Getdate())

INSERT INTO 
    Person(Name,Email,Age,PhoneNumber,Password,ProfileId,Fee,Created,Updated)
VALUES ('ActorTwo','ActorTwo@gmail.com','21','999999999','qwasdsadsad',2,311,Getdate(),Getdate())

INSERT INTO 
    Person(Name,Email,Age,PhoneNumber,Password,ProfileId,Fee,Created,Updated)
VALUES ('ActressOne','ActressOne@gmail.com','19','999999999','qwasdsadsad',2,12331,Getdate(),Getdate())

INSERT INTO 
    Person(Name,Email,Age,PhoneNumber,Password,ProfileId,Fee,Created,Updated)
VALUES ('ActressTwo','ActressTwo@gmail.com','30','999999999','qwasdsadsad',2,12331,Getdate(),Getdate())

INSERT INTO 
    Person(Name,Email,Age,PhoneNumber,Password,ProfileId,Fee,Created,Updated)
VALUES ('Nome1','Nome@gmail.com','19','999999999','qwasdsadsad',2,12331,Getdate(),Getdate())

INSERT INTO 
    Person(Name,Email,Age,PhoneNumber,Password,ProfileId,Fee,Created,Updated)
VALUES ('ProductorTwo','ProductorTwo@gmail.com','19','999999999','qwasdsadsad',1,Null,Getdate(),Getdate())

CREATE TABLE [dbo].[PersonGenres] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [PersonId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[Created] DateTime NOT NULL,
    CONSTRAINT PK_PersonGenres_Id PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_PersonGenres_PersonId FOREIGN KEY (PersonId) REFERENCES [dbo].[Person] (Id),
    CONSTRAINT FK_PersonGenres_GenreId FOREIGN KEY (GenreId) REFERENCES [dbo].[Genres] (id)
)

INSERT INTO 
    PersonGenres(PersonId,GenreId,Created)
VALUES (2,2,Getdate())

INSERT INTO 
    PersonGenres(PersonId,GenreId,Created)
VALUES (2,1,Getdate())

INSERT INTO 
    PersonGenres(PersonId,GenreId,Created)
VALUES (2,3,Getdate())

INSERT INTO 
    PersonGenres(PersonId,GenreId,Created)
VALUES (3,1,Getdate())

INSERT INTO 
    PersonGenres(PersonId,GenreId,Created)
VALUES (4,2,Getdate())

INSERT INTO 
    PersonGenres(PersonId,GenreId,Created)
VALUES (5,3,Getdate())

INSERT INTO 
    PersonGenres(PersonId,GenreId,Created)
VALUES (6,1,Getdate())

CREATE TABLE [dbo].[Production] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](200) NOT NULL,
    [PersonId] [int] NOT NULL,
    [Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL,
    CONSTRAINT PK_Production_Id PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Production_PersonId FOREIGN KEY (PersonId) REFERENCES [dbo].[Person] (Id),
)


INSERT INTO 
    Production(Name,PersonId,Created,Updated)
VALUES ('O vento nos levou',1,Getdate(),Getdate())

INSERT INTO 
    Production(Name,PersonId,Created,Updated)
VALUES ('O vento te levou',1,Getdate(),Getdate())

INSERT INTO 
    Production(Name,PersonId,Created,Updated)
VALUES ('O Sono nos levou',7,Getdate(),Getdate())



CREATE TABLE [dbo].[Reservation] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [PersonId] [int] NOT NULL,
	[ProductionId] [int] NOT NULL,
	[Created] DateTime NOT NULL,
    [InitialDate] Date NOT NULL,
    [FinalDate] Date NOT NULL,
    CONSTRAINT PK_Reservation_Id PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Reservation_PersonId FOREIGN KEY (PersonId) REFERENCES [dbo].[Person] (Id),
    CONSTRAINT FK_Reservation_ProductionId FOREIGN KEY (ProductionId) REFERENCES [dbo].[Production] (id)
)


INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (2,1,Getdate(),DateAdd(dd,2,GetDate()),DateAdd(dd,3,GetDate()))

INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (2,2,Getdate(),DateAdd(dd,4,GetDate()),DateAdd(dd,5,GetDate()))

INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (3,1,Getdate(),DateAdd(dd,2,GetDate()),DateAdd(dd,3,GetDate()))

INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (4,3,Getdate(),DateAdd(dd,2,GetDate()),DateAdd(dd,2,GetDate()))

INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (5,3,Getdate(),DateAdd(dd,10,GetDate()),DateAdd(dd,12,GetDate()))

INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (6,3,Getdate(),DateAdd(dd,1,GetDate()),DateAdd(dd,10,GetDate()))

INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (6,3,Getdate(),DateAdd(dd,20,GetDate()),DateAdd(dd,40,GetDate()))

INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (6,1,Getdate(),DateAdd(dd,15,GetDate()),DateAdd(dd,19,GetDate()))

INSERT INTO 
    Reservation(PersonId,ProductionId,Created,InitialDate,FinalDate)
VALUES (6,1,Getdate(),DateAdd(dd,40,GetDate()),DateAdd(dd,41,GetDate()))


/* Entities Selects

Select *
From Profile

Select *
From Genres

Select *
From Person

Select *
From PersonGenres

Select *
From Production

Select *
From Reservation
*/

/* Select to Producer Production Details

Select Person.Name, Reservation.InitialDate, Reservation.FinalDate
From Person
Join Reservation On Reservation.PersonId = Person.Id
Join Production On Production.Id = Reservation.ProductionId
Where Production.Id = 1    /*Input Production Id */
AND   Production.PersonId = 1 /*Input Production Producer Id*/
Group by 
Person.Name,
Reservation.InitialDate, 
Reservation.FinalDate
Order by Person.Name */

/*  Select to Search Actor that has disponibility, Genre and Fee on Range. Only one Genre on Search.

Select Person.Name, Person.Fee, Person.PhoneNumber, Person.Email
From Person
Join Reservation On Reservation.PersonId = Person.Id
Join PersonGenres On PersonGenres.PersonId = Person.Id
Where PersonGenres.GenreId = 3 --Input Genres
AND   (Cast('2020-10-27' as Date) < Reservation.InitialDate  OR Reservation.FinalDate < Cast('2020-10-27' as Date)) -- Input InitialDate
AND   (Cast('2020-10-30' as Date) < Reservation.InitialDate  OR Reservation.FinalDate < Cast('2020-10-30' as Date))  --Input LastDate          
Group By 
Person.Name, 
Person.Fee, 
Person.PhoneNumber, 
Person.Email
*/



