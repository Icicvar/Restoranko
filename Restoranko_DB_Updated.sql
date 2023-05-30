create database Restoranko_DB_Updated
GO

USE Restoranko_DB_Updated
GO

CREATE TABLE "UserType" (
    IDUserType INT IDENTITY(1,1) PRIMARY KEY,
    UserTypeName VARCHAR(50) NOT NULL
);

CREATE TABLE "User" (
    IDUser INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL,
	UserTypeID INT FOREIGN KEY REFERENCES "UserType"(IDUserType)
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
    WaiterID INT FOREIGN KEY REFERENCES "User"(IDUser)
);

CREATE TABLE "Reservation" (
    IDReservation INT IDENTITY(1,1) PRIMARY KEY,
    DateReservation DATETIME NOT NULL,
    TableID INT FOREIGN KEY REFERENCES "Table"(IDTable),
    OrderID INT FOREIGN KEY REFERENCES "Order"(IDOrder),
    GuestID INT FOREIGN KEY REFERENCES "User"(IDUser),
    EmployeeID INT FOREIGN KEY REFERENCES "User"(IDUser)
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

CREATE TABLE "Ingredient" (
    IngredientID INT PRIMARY KEY,
    IngredientName VARCHAR(50) NOT NULL,
	Quantity DECIMAL(10, 2) NOT NULL
);

CREATE TABLE "Recipe" (
    IDRecipe INT PRIMARY KEY,
    RecipeName VARCHAR(50) NOT NULL,
    RecipeDescription VARCHAR(500),
    RecipeInstructions VARCHAR(MAX),
    RecipeImage VARCHAR(MAX)
);

CREATE TABLE "RecipeIngredients" (
    RecipeID INT,
    IngredientID INT,
    Quantity DECIMAL(10, 2),
    PRIMARY KEY (RecipeID, IngredientID),
    FOREIGN KEY (RecipeID) REFERENCES Recipe(IDRecipe),
    FOREIGN KEY (IngredientID) REFERENCES Ingredient(IngredientID)
);

CREATE TABLE "Product" (
    IDProduct INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Price INT NOT NULL,
	RecepieID INT FOREIGN KEY REFERENCES "Recipe"(IDRecipe)
);

CREATE TABLE "Item" (
    IDItem INT IDENTITY(1,1) PRIMARY KEY,
    Amount INT NOT NULL,
    EmpolyeeID INT FOREIGN KEY REFERENCES "User"(IDUser),
    ProductID INT FOREIGN KEY REFERENCES "Product"(IDProduct),
    OrderID INT FOREIGN KEY REFERENCES "Order"(IDOrder)
);

CREATE TABLE "ProductTime" (
    IDProductTime INT IDENTITY(1,1) PRIMARY KEY,
    ItemID INT NOT NULL,
    OrderID INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME,
    CONSTRAINT FK_ProductTime_Product FOREIGN KEY (ItemID) REFERENCES "Item"(IDItem),
    CONSTRAINT FK_ProductTime_Order FOREIGN KEY (OrderID) REFERENCES "Order"(IDOrder)
);