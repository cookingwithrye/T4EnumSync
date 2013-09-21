--We're going to store information about a car, both the color and vehicle type.
--Normally you could use an option like `SET IDENTITY_INSERT ON` and have hardcoded primary keys set for the values, but we're not going to do that.

--create the database (change paths as required for your local machine)
USE [master];
GO

CREATE DATABASE [T4EnumSync] ON PRIMARY
( NAME = N'T4EnumSync', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\T4EnumSync.mdf')
 LOG ON 
( NAME = N'T4EnumSync_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\T4EnumSync_log.ldf')
GO