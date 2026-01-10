CREATE DATABASE db_store;
GO
USE db_store;
GO

CREATE TABLE [audits] (
    [id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [action] NVARCHAR(150) NOT NULL,
    [description] NVARCHAR(500) NOT NULL,
    [date] SMALLDATETIME NOT NULL,
);

CREATE TABLE [users] (
    [id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [name] NVARCHAR(150) NOT NULL,
    [password] NVARCHAR(150) NOT NULL,
    [active] BIT NOT NULL,
);

CREATE TABLE [types] (
    [id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [name] NVARCHAR(150) NOT NULL,
);

CREATE TABLE [products] (
    [id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [name] NVARCHAR(150) NOT NULL,
    [price] DECIMAL(10,2) NOT NULL,
    [expire] SMALLDATETIME NOT NULL,
    [type] INT NOT NULL REFERENCES [types]([id]),
    [active] BIT NOT NULL,
    [image] NVARCHAR(MAX) NULL,
);

INSERT INTO [users] ([name],[password],[active])
VALUES ('Admin', '6s5d4f6534465465g4d6fg', 1);
INSERT INTO [types] ([name])
VALUES ('Instruments');
INSERT INTO [products] ([name],[price],[expire],[type],[active])
VALUES ('Guitar Ibanez', 3400000.00, GETDATE(),1, 1);

SELECT * FROM [audits];
SELECT * FROM [users];
SELECT * FROM [types];
SELECT * FROM [products];