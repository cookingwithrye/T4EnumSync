--create some starting data for us to synchronize with
USE [T4EnumSync];

--allow us to insert the primary key values
SET IDENTITY_INSERT [Color] ON;

INSERT INTO [Color](ColorID, ColorName) 
VALUES 
(1, 'Red'), 
(2, 'Blue'), 
(3, 'White');

SET IDENTITY_INSERT [Color] OFF;

--create some test data
INSERT INTO [Vehicle](OwnerName, ColorID) 
VALUES
('Red Vehicle', 1),
('White Vehicle', 3),
('Blue Vehicle', 2);