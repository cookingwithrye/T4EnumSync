--We're going to store information about a car, both the color and vehicle type.
--Normally you could use an option like `SET IDENTITY_INSERT ON` and have hardcoded primary keys set for the values, but we're not going to do that.

CREATE DATABASE [T4EnumSync];

USE [T4EnumSync];

--available vehicle types
CREATE TABLE VehicleType (
	VehicleTypeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	VehicleName NVARCHAR(100) NOT NULL
);

--available colors
CREATE TABLE Color (
	ColorID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ColorName NVARCHAR(50) NOT NULL UNIQUE,
);

--the vehicle record
CREATE TABLE Vehicle (
	VehicleID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	
	VehicleTypeID INT NOT NULL FOREIGN KEY REFERENCES VehicleType(VehicleTypeID),
	ColorID INT NOT NULL FOREIGN KEY REFERENCES Color(ColorID),

	OwnerName NVARCHAR(100) NOT NULL,	--who owns the vehicle?
);