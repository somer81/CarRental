Create table CarImages(
 
	Id int Primary Key Not Null,
    CarId int Not Null,
    ImagePath varchar(255),
    Date DateTime,
    FOREIGN KEY (CarId) REFERENCES Cars(Id)
)