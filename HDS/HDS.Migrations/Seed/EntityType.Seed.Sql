/*Seed Initial Values for EntityType*/

--Declare a temp table to hold values being inserted
DECLARE @TempTable TABLE (Id int identity, EntityTypeID int, EntityTypeName varchar(50))

INSERT INTO @TempTable (EntityTypeID, EntityTypeName) VALUES (1, 'Customer')
INSERT INTO @TempTable (EntityTypeID, EntityTypeName) VALUES (2, 'Employee')
INSERT INTO @TempTable (EntityTypeID, EntityTypeName) VALUES (3, 'Store')

--Declare Loop variables
DECLARE @CTR INT = 1
DECLARE @MAX INT = (SELECT COUNT(*) FROM @TempTable)
--Declare table placeholder variables
DECLARE @ID INT
DECLARE @NAME VARCHAR(50)
SET IDENTITY_INSERT [dbo].[EntityType] ON;

WHILE @CTR <= @MAX

BEGIN
	--get the row from the temp table
	SELECT @ID = EntityTypeID, @NAME = EntityTypeName
	FROM @TempTable
	WHERE Id = @CTR

	--try to update if it exists, insert if it doesnt
	UPDATE [dbo].[EntityType]
	SET [EntityTypeName] = @NAME
	WHERE [EntityTypeID] = @ID
	INSERT INTO [dbo].[EntityType] ([EntityTypeID], [EntityTypeName])
	SELECT @ID, @NAME
	WHERE NOT EXISTS (SELECT [EntityTypeID] FROM [dbo].[EntityType] WHERE [EntityTypeID] = @ID)

	--iterate counter
	SET @CTR = @CTR + 1
END
SET IDENTITY_INSERT [dbo].[EntityType] OFF;