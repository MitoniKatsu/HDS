/*Seed Initial Values for AddressType*/

--Declare a temp table to hold values being inserted
DECLARE @TempTable TABLE (Id int identity, AddressTypeID int, AddressTypeName varchar(50))

INSERT INTO @TempTable (AddressTypeID, AddressTypeName) VALUES (1, 'Home')
INSERT INTO @TempTable (AddressTypeID, AddressTypeName) VALUES (2, 'Business')
INSERT INTO @TempTable (AddressTypeID, AddressTypeName) VALUES (3, 'Mailing')

--Declare Loop variables
DECLARE @CTR INT = 1
DECLARE @MAX INT = (SELECT COUNT(*) FROM @TempTable)
--Declare table placeholder variables
DECLARE @ID INT
DECLARE @NAME VARCHAR(50)
SET IDENTITY_INSERT [dbo].[AddressType] ON;

WHILE @CTR <= @MAX

BEGIN
	--get the row from the temp table
	SELECT @ID = AddressTypeID, @NAME = AddressTypeName
	FROM @TempTable
	WHERE Id = @CTR

	--try to update if it exists, insert if it doesnt
	UPDATE [dbo].[AddressType]
	SET [AddressTypeName] = @NAME
	WHERE [AddressTypeID] = @ID
	INSERT INTO [dbo].[AddressType] ([AddressTypeID], [AddressTypeName])
	SELECT @ID, @NAME
	WHERE NOT EXISTS (SELECT [AddressTypeID] FROM [dbo].[AddressType] WHERE [AddressTypeID] = @ID)

	--iterate counter
	SET @CTR = @CTR + 1
END
SET IDENTITY_INSERT [dbo].[AddressType] OFF;