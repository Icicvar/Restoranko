create table "User"(

	IDUser int IDENTITY(1,1) primary key,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Email varchar(100) not null,
	"Password" varchar(100) not null,


)


create table Guest(

	IDGuest int IDENTITY(1,1) primary key ,
	UserID int foreign key references "User"(IDUser)

)

create table Job(

	IDJob int IDENTITY(1,1) primary key,
	"Name" varchar(100) not null,

)

create table Employment(

	IDEmployment int IDENTITY(1,1) primary key,
	UserID int foreign key references "User"(IDUser),
	JobID int foreign key references Job(IDJob)

)



create table "Table"(

	IDTable int IDENTITY(1,1) primary key,
	TableNumber int not null

)
create table "Order"(

	IDOrder int IDENTITY(1,1) primary key,
	OrderNumber int not null,
	OrderDate datetime not null,
	TotalPrice int not null,
	WaiterID int foreign key references Job(IDJob)

)

create table Reservation(

	IDReservation int IDENTITY(1,1) primary key,
	DateReservation datetime not null,
	TableID int foreign key references "Table"(IDTable),
	OrderID int foreign key references "Order"(IDOrder),
	GuestID int foreign key references Guest(IDGuest)

)

create table Product(

	IDProduct int IDENTITY(1,1) primary key,
	"Name" varchar(100) not null,
	Price int not null,

)

create table Item(

	IDItem int IDENTITY(1,1) primary key,
	OrderID int foreign key references "Order"(IDOrder),
	ProductID int foreign key references Product(IDProduct),
	Amount int not null,
	BarmanID int foreign key references Job(IDJob)

)





CREATE PROCEDURE CreateUser
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Password VARCHAR(100)
AS
BEGIN
    INSERT INTO [User] (FirstName, LastName, Email, [Password])
    VALUES (@FirstName, @LastName, @Email, @Password)
END


CREATE PROCEDURE SelectUser
    @IDUser INT
AS
BEGIN
    SELECT IDUser, FirstName, LastName, Email, [Password]
    FROM [User]
    WHERE IDUser = @IDUser
END

CREATE PROCEDURE UpdateUser
    @IDUser INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Password VARCHAR(100)
AS
BEGIN
    UPDATE [User]
    SET FirstName = @FirstName, LastName = @LastName, Email = @Email, [Password] = @Password
    WHERE IDUser = @IDUser
END

CREATE PROCEDURE DeleteUser
    @IDUser INT
AS
BEGIN
    DELETE FROM [User]
    WHERE IDUser = @IDUser
END

CREATE PROCEDURE CheckUser
	@Email NVARCHAR(100),
	@Password NVARCHAR(64)
AS
BEGIN
	SET NOCOUNT ON
	IF NOT EXISTS (SELECT IDUser FROM "User" WHERE Email = @Email and Password = @Password)
		SELECT -1
	ELSE
		SELECT 0
END
GO

