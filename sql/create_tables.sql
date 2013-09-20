USE [T4EnumSync];

--available vehicle types
CREATE TABLE VehicleType (
	VehicleTypeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TypeName NVARCHAR(100) NOT NULL
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