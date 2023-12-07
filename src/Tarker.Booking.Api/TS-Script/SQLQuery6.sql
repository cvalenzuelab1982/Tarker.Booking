USE Booking
GO

CREATE TABLE [User]
(
	UserId int PRIMARY KEY IDENTITY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	UserName varchar(50) NOT NULL,
	Password varchar(10) NOT NULL,
);

CREATE TABLE [Customer](
	CustomerId int PRIMARY KEY IDENTITY,
	FullName varchar(50) NOT NULL,
	DocumentNumber varchar(8) NOT NULL,
);


CREATE TABLE [Booking](
	BookingId int PRIMARY KEY IDENTITY,
	RegisterDate datetime NOT NULL,
	Code varchar(50) NOT NULL,
	Type varchar(50) NOT NULL,
	UserId int NOT NULL,
	CustomerId int NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User](UserId),
	FOREIGN KEY (CustomerId) REFERENCES [Customer](CustomerId)
);