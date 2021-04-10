/*Seed Initial Values for ContactMethodType*/

--Declare a temp table to hold values being inserted
DECLARE @TempTable TABLE (Id int identity, ContactMethodTypeID int, ContactMethodTypeName varchar(100))

INSERT INTO @TempTable (ContactMethodTypeID, ContactMethodTypeName) VALUES (1, 'Email')
INSERT INTO @TempTable (ContactMethodTypeID, ContactMethodTypeName) VALUES (2, 'Home Phone')
INSERT INTO @TempTable (ContactMethodTypeID, ContactMethodTypeName) VALUES (3, 'Mobile Phone')
INSERT INTO @TempTable (ContactMethodTypeID, ContactMethodTypeName) VALUES (4, 'Work Phone')
INSERT INTO @TempTable (ContactMethodTypeID, ContactMethodTypeName) VALUES (5, 'Fax Phone')

--Declare Loop variables
DECLARE @CTR INT = 1
DECLARE @MAX INT = (SELECT COUNT(*) FROM @TempTable)
--Declare table placeholder variables
DECLARE @ID INT
DECLARE @NAME VARCHAR(100)
SET IDENTITY_INSERT [dbo].[ContactMethodType] ON;

WHILE @CTR <= @MAX

BEGIN
	--get the row from the temp table
	SELECT @ID = ContactMethodTypeID, @NAME = ContactMethodTypeName
	FROM @TempTable
	WHERE Id = @CTR

	--try to update if it exists, insert if it doesnt
	UPDATE [dbo].[ContactMethodType]
	SET [ContactMethodTypeName] = @NAME
	WHERE [ContactMethodTypeID] = @ID
	INSERT INTO [dbo].[ContactMethodType] ([ContactMethodTypeID], [ContactMethodTypeName])
	SELECT @ID, @NAME
	WHERE NOT EXISTS (SELECT [ContactMethodTypeID] FROM [dbo].[ContactMethodType] WHERE [ContactMethodTypeID] = @ID)

	--iterate counter
	SET @CTR = @CTR + 1
END
SET IDENTITY_INSERT [dbo].[ContactMethodType] OFF;