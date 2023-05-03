create database Restoranko_DB
GO

CREATE TABLE "User" (
    IDUser INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL
);

CREATE TABLE "JobType" (
    IDJobType INT IDENTITY(1,1) PRIMARY KEY,
    JobTypeName VARCHAR(50) NOT NULL
);

CREATE TABLE "Job" (
    IDJob INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES "User"(IDUser),
    JobTypeID INT FOREIGN KEY REFERENCES "JobType"(IDJobType)
);

CREATE TABLE "Guest" (
    IDGuest INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES "User"(IDUser)
);

CREATE TABLE "Table" (
    IDTable INT IDENTITY(1,1) PRIMARY KEY,
    TableNumber INT NOT NULL
);

CREATE TABLE "Order" (
    IDOrder INT IDENTITY(1,1) PRIMARY KEY,
    OrderNumber INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalPrice INT NOT NULL,
    WaiterID INT FOREIGN KEY REFERENCES "Job"(IDJob)
);

CREATE TABLE "Reservation" (
    IDReservation INT IDENTITY(1,1) PRIMARY KEY,
    DateReservation DATETIME NOT NULL,
    TableID INT FOREIGN KEY REFERENCES "Table"(IDTable),
    OrderID INT FOREIGN KEY REFERENCES "Order"(IDOrder),
    GuestID INT FOREIGN KEY REFERENCES "Guest"(IDGuest),
    UserID INT FOREIGN KEY REFERENCES "User"(IDUser)
);

CREATE TABLE "Product" (
    IDProduct INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Price INT NOT NULL
);

CREATE TABLE "Item" (
    IDItem INT IDENTITY(1,1) PRIMARY KEY,
    Amount INT NOT NULL,
    JobID INT FOREIGN KEY REFERENCES "Job"(IDJob),
    ProductID INT FOREIGN KEY REFERENCES "Product"(IDProduct),
    OrderID INT FOREIGN KEY REFERENCES "Order"(IDOrder)
);

CREATE TABLE "Inventory" (
    IDInventory INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT FOREIGN KEY REFERENCES "Product"(IDProduct),
    Quantity INT NOT NULL
);

CREATE TABLE "Recipe" (
    RecipeID INT PRIMARY KEY,
    RecipeName VARCHAR(50) NOT NULL,
    RecipeDescription VARCHAR(500),
    RecipeInstructions VARCHAR(MAX),
    RecipeImage VARCHAR(MAX)
);

CREATE TABLE "Ingredient" (
    IngredientID INT PRIMARY KEY,
    IngredientName VARCHAR(50) NOT NULL
);

CREATE TABLE "RecipeIngredient" (
    RecipeID INT,
    IngredientID INT,
    Quantity DECIMAL(10, 2),
    Unit VARCHAR(20),
    PRIMARY KEY (RecipeID, IngredientID),
    FOREIGN KEY (RecipeID) REFERENCES Recipe(RecipeID),
    FOREIGN KEY (IngredientID) REFERENCES Ingredient(IngredientID)
);

CREATE TABLE "ProductTime" (
    IDProductTime INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    OrderID INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME,
    CONSTRAINT FK_ProductTime_Product FOREIGN KEY (ProductID) REFERENCES "Product"(IDProduct),
    CONSTRAINT FK_ProductTime_Order FOREIGN KEY (OrderID) REFERENCES "Order"(IDOrder)
);

CREATE TABLE "Transaction" (
    IDTransaction INT IDENTITY(1,1) PRIMARY KEY,
    TransactionDate DATETIME NOT NULL,
    TransactionType VARCHAR(50) NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    Description VARCHAR(500),
    UserID INT FOREIGN KEY REFERENCES "User"(IDUser),
    OrderID INT FOREIGN KEY REFERENCES "Order"(IDOrder)
);


-- MANT TO MANY VEZA
create table "Job_JobType"(
JobID int foreign key references "Job"(IDJob),
JobTypeID int foreign key references "JobType"(IDJobType),
primary key (JobID, JobTypeID)
)
create table "User_Guest"(
UserID int foreign key references "User"(IDUser),
GuestID int foreign key references "Guest"(IDGuest),
primary key (UserID, GuestID)
)
create table "Product_Order"(
ProductID int foreign key references "Product"(IDProduct),
OrderID int foreign key references "Order"(IDOrder),
primary key (ProductID, OrderID)
)