use TV;


INSERT INTO 
    Profile(Label,Created,Updated)
VALUES ('Actor',GETDATE(),GETDATE())

INSERT INTO 
    Profile(Label,Created,Updated)
VALUES ('Producer',GETDATE(),GETDATE())


INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Film',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Novel',GETDATE(),GETDATE())

INSERT INTO 
    Genres(Label,Created,Updated)
VALUES ('Series',GETDATE(),GETDATE())




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




INSERT INTO 
    Production(Name,PersonId,Created,Updated)
VALUES ('O vento nos levou',1,Getdate(),Getdate())

INSERT INTO 
    Production(Name,PersonId,Created,Updated)
VALUES ('O vento te levou',1,Getdate(),Getdate())

INSERT INTO 
    Production(Name,PersonId,Created,Updated)
VALUES ('O Sono nos levou',7,Getdate(),Getdate())




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


