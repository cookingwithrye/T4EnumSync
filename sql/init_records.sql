--create some starting data for us to synchronize with
USE [T4EnumSync];

INSERT INTO [Color](ColorName) VALUES ('Red'),('Blue'),('White');
INSERT INTO [VehicleType](TypeName) VALUES ('Truck'),('Car'),('Motorcycle');

--create all possible combinations of vehicle types/colors (3*3 == 9 possible cars, so create 9 distinct owner names)

SELECT ColorID FROM [Color];
SELECT VehicleTypeID FROM [VehicleType];