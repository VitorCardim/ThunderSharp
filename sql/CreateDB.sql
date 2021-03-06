CREATE DATABASE TV;
use TV;


CREATE TABLE [dbo].[Profile] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [Label] [varchar](50) NOT NULL,
	[Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL,
    CONSTRAINT PK_Profile_Id PRIMARY KEY CLUSTERED (Id)
    )


CREATE TABLE [dbo].[Genres] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [Label] [varchar](20) NOT NULL,
	[Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL,
    CONSTRAINT PK_Genres_Id PRIMARY KEY CLUSTERED (Id)
    )


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


CREATE TABLE [dbo].[PersonGenres] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [PersonId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[Created] DateTime NOT NULL,
    CONSTRAINT PK_PersonGenres_Id PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_PersonGenres_PersonId FOREIGN KEY (PersonId) REFERENCES [dbo].[Person] (Id),
    CONSTRAINT FK_PersonGenres_GenreId FOREIGN KEY (GenreId) REFERENCES [dbo].[Genres] (id)
)


CREATE TABLE [dbo].[Production] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](200) NOT NULL,
    [PersonId] [int] NOT NULL,
    [Created] DateTime NOT NULL,
    [Updated] DateTime NOT NULL,
    CONSTRAINT PK_Production_Id PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Production_PersonId FOREIGN KEY (PersonId) REFERENCES [dbo].[Person] (Id),
)


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



