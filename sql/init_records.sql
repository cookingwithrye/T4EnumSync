--create some starting data for us to synchronize with
USE [T4EnumSync];

--allow us to insert the primary key values
SET IDENTITY_INSERT [Color] ON;

INSERT INTO [Color](ColorID, ColorName) 
VALUES 
(1, 'Red'), 
(2, 'Blue'), 
(3, 'White');

INSERT INTO [VehicleType](VehicleTypeID, TypeName) 
VALUES 
(1, 'Truck'), 
(2, 'Car'), 
(3, 'Motorcycle');

SET IDENTITY_INSERT [Color] OFF;

--create some test data
INSERT INTO [Vehicle](OwnerName, ColorID, VehicleTypeID) 
VALUES
('White Motorcycle', 3, 3),
('Red Car', 1, 2),
('Blue Truck', 2, 1),
('Red Motorcycle', 1, 3);