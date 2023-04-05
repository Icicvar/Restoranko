create table "User"(

	IDUser int primary key,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Email varchar(100) not null,
	"Password" varchar(100) not null,


)

create table Guest(

	IDGuest int primary key ,
	UserID int foreign key references "User"(IDUser)

)

create table Job(

	IDJob int primary key,
	"Name" varchar(100) not null,

)

create table Employment(

	IDEmployment int primary key,
	UserID int foreign key references "User"(IDUser),
	JobID int foreign key references Job(IDJob)

)



create table "Table"(

	IDTable int primary key,
	TableNumber int not null

)
create table "Order"(

	IDOrder int primary key,
	OrderNumber int not null,
	OrderDate datetime not null,
	TotalPrice int not null,
	WaiterID int foreign key references Job(IDJob)

)

create table Reservation(

	IDReservation int primary key,
	DateReservation datetime not null,
	TableID int foreign key references "Table"(IDTable),
	OrderID int foreign key references "Order"(IDOrder),
	GuestID int foreign key references Guest(IDGuest)

)

create table Product(

	IDProduct int primary key,
	"Name" varchar(100) not null,
	Price int not null,

)

create table Item(

	IDItem int primary key,
	OrderID int foreign key references "Order"(IDOrder),
	ProductID int foreign key references Product(IDProduct),
	Amount int not null,
	BarmanID int foreign key references Job(IDJob)

)



