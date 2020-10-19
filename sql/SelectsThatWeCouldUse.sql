use TV;


/*Select to Producer Production Details*/

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
Order by Person.Name 

/*  Select to Search Actor that has disponibility, Genre and Fee on Range. Only one Genre on Search. */

Select Person.Name, Person.Fee, Person.PhoneNumber, Person.Email
From Person
Join Reservation On Reservation.PersonId = Person.Id
Join PersonGenres On PersonGenres.PersonId = Person.Id
Where PersonGenres.GenreId = 3 --Input Genres
AND Person.Fee <= Cast('1000' as Decimal) -- Input Bucket
AND   (Cast('2020-10-27' as Date) < Reservation.InitialDate  OR Reservation.FinalDate < Cast('2020-10-27' as Date)) -- Input InitialDate
AND   (Cast('2020-10-30' as Date) < Reservation.InitialDate  OR Reservation.FinalDate < Cast('2020-10-30' as Date))  --Input LastDate          
Group By 
Person.Name, 
Person.Fee, 
Person.PhoneNumber, 
Person.Email




