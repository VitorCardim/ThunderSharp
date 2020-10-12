CREATE DATABASE TV;
use TV;

/* Drops Table
Drop table Reservation;
Drop table Production;
Drop table PersonGenres;
Drop table Genres;
Drop table Person;
Drop table Profile;
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
VALUES ('Action',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Comedy',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Documentary',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Drama',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Horror',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Musical',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Romance',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Sci-Fi',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Suspense',GETDATE(),GETDATE())


CREATE TABLE [dbo].[Person] (
	[CPF] [char](11) NOT NULL,
    [Name] [varchar](200) NOT NULL,
    [Email] [varchar](50) NOT NULL,
    [Age] [varchar](3) NOT NULL,
    [Phoner Number] [varchar](15) NOT NULL, /* Because of international Numbers*/
    [Password] [varchar](20) NOT NULL,
    [ProfileId] [int] NOT NULL,
    [Fee] [Decimal],
	[Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL,
    CONSTRAINT PK_Person_CPF PRIMARY KEY CLUSTERED (CPF),
    CONSTRAINT FK_Person_ProfileId FOREIGN KEY (ProfileId) REFERENCES [dbo].[Profile] (Id)
    )


CREATE TABLE [dbo].[PersonGenres] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [CPF] [char](11) NOT NULL,
	[GenreId] [int] NOT NULL,
	[Created] DateTime NOT NULL,
    CONSTRAINT FK_PersonGenres_CPF FOREIGN KEY (CPF) REFERENCES [dbo].[Person] (CPF),
    CONSTRAINT FK_PersonGenres_GenreId FOREIGN KEY (GenreId) REFERENCES [dbo].[Genres] (id)
)

CREATE TABLE [dbo].[Production] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](200) NOT NULL,
    [Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL
)

CREATE TABLE [dbo].[Reservation] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [CPF] [char](11) NOT NULL,
	[ProductionId] [int] NOT NULL,
	[Created] DateTime NOT NULL,
    [InitalDate] Date NOT NULL,
    [FinalDate] Date NOT NULL,
    CONSTRAINT FK_PersonGenres_CPF FOREIGN KEY (CPF) REFERENCES [dbo].[Person] (CPF),
    CONSTRAINT FK_PersonGenres_ProductionId FOREIGN KEY (ProductionId) REFERENCES [dbo].[Production] (id)
)

