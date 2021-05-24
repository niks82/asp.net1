CREATE DATABASE ProductDB
go
Use ProductDB
go

CREATE TABLE Category
(
	[CategoryId] TINYINT CONSTRAINT pk_CategoryId PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(20) CONSTRAINT uq_CategoryName UNIQUE NOT NULL,
        [CategoryDescription] VARCHAR(50) 
)
GO

CREATE TABLE Product
(
	[Id] INT CONSTRAINT pk_Id PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) CONSTRAINT uq_Name UNIQUE NOT NULL,
        [Description] VARCHAR(50),
        [Price] NUMERIC(8) CONSTRAINT chk_Price CHECK(Price>0) NOT NULL,
	[CategoryId] TINYINT CONSTRAINT fk_CategoryId REFERENCES Category(CategoryId)
)
GO

CREATE PROCEDURE usp_SelectProduct
AS

			BEGIN
                              Select * From Product
			END
GO

ALTER PROCEDURE usp_AddProduct
(
	@Id INT,
	@Name VARCHAR(50),
        @Description VARCHAR(50),
	@Price NUMERIC(10,2),
	@CategoryId TINYINT
)
AS
BEGIN
	DECLARE @retval int
	BEGIN TRY
			BEGIN
				INSERT INTO Product VALUES 
				(@Id, @Name, @Description, @Price, @CategoryId)
				SET @retval = 1
			END
		SELECT @retval 
	END TRY
	BEGIN CATCH
		SET @retval = -99
		SELECT @retval 
	END CATCH
END
GO

ALTER PROCEDURE usp_UpdateProduct
(
	@Id INT,
	@Name VARCHAR(50),
        @Description VARCHAR(50),
	@Price NUMERIC(10,2),
	@CategoryId TINYINT
)
AS

			BEGIN
                              UPDATE Product  
                                    SET    [Name] = @Name,  
                                           [Description] = @Description,  
                                           Price = @Price,  
                                           CategoryId = @CategoryId  
                                    WHERE  Id = @Id  
			END

GO

-- insertion script for Category
SET IDENTITY_INSERT Category ON
INSERT INTO Category (CategoryId, CategoryName, CategoryDescription) VALUES (1, 'Mobiles','A mobile phone')
INSERT INTO Category (CategoryId, CategoryName, CategoryDescription) VALUES (2, 'Fashion','Fashion Clothes')
INSERT INTO Category (CategoryId, CategoryName, CategoryDescription) VALUES (3, 'Electronics','Electronic items')
INSERT INTO Category (CategoryId, CategoryName, CategoryDescription) VALUES (4, 'Books','Books')
SET IDENTITY_INSERT Category OFF

GO


-- insertion script for Product
INSERT INTO Product(Id, [Name], [Description], Price,CategoryId) VALUES(1,'Iphone','Mobile Phone',60000,1)
INSERT INTO Product(Id,Name,Description,Price,CategoryId) VALUES(22,'OnePlus','Mobile Phone',40000,1)
INSERT INTO Product(Id,Name,Description,Price,CategoryId) VALUES(2,'Jeans','Clothes',2500.00,2)
INSERT INTO Product(Id,Name,Description,Price,CategoryId) VALUES(3,'Samsung Refrigerator','Refrigerator',30000,3)
INSERT INTO Product(Id,Name,Description,Price,CategoryId) VALUES(5,'LG Microwave','Microwave',50000,3)
GO

select * from Product
go
Select * from Category
go

ALTER TABLE Product
ALTER COLUMN Price NUMERIC(10,2)
GO



