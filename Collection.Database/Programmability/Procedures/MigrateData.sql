CREATE PROCEDURE [dbo].[MigrateData]
AS


-- Cleanup

DELETE FROM [UserItem]
DELETE FROM [User]
DELETE FROM [UserRole]

DELETE FROM ItemImage;
DELETE FROM Item;
DELETE FROM Category;
DELETE FROM Producer;
DELETE FROM ItemState;
DELETE FROM ItemRarity;
DELETE FROM ItemCondition;

-- Categories

SET IDENTITY_INSERT Category ON

INSERT INTO Category(CategoryID, Name, Level, ParentID) 
SELECT Id, Name, 0, NULL FROM Collection.dbo.Categories

SET IDENTITY_INSERT Category OFF

-- Producers

SET IDENTITY_INSERT Producer ON

INSERT INTO Producer(ProducerID, Name, Url)
SELECT Id, Name, URL FROM Collection.dbo.Producers;

SET IDENTITY_INSERT Producer OFF

-- Item State

SET IDENTITY_INSERT [dbo].[ItemState] ON 

INSERT [dbo].[ItemState] ([ItemStateID], [Name]) VALUES (0, N'None')
INSERT [dbo].[ItemState] ([ItemStateID], [Name]) VALUES (1, N'Wanted')
INSERT [dbo].[ItemState] ([ItemStateID], [Name]) VALUES (2, N'In Collection')
INSERT [dbo].[ItemState] ([ItemStateID], [Name]) VALUES (3, N'For Sale')
INSERT [dbo].[ItemState] ([ItemStateID], [Name]) VALUES (4, N'Sold')

SET IDENTITY_INSERT [dbo].[ItemState] OFF

-- Item Rarity

SET IDENTITY_INSERT [dbo].[ItemRarity] ON 

INSERT [dbo].[ItemRarity] ([ItemRarityID], [Name]) VALUES (1, N'Common')
INSERT [dbo].[ItemRarity] ([ItemRarityID], [Name]) VALUES (2, N'Rare')

SET IDENTITY_INSERT [dbo].[ItemRarity] OFF

-- Item Condition

SET IDENTITY_INSERT [dbo].[ItemCondition] ON 

INSERT [dbo].[ItemCondition] ([ItemConditionID], [Name]) VALUES (1, N'New')
INSERT [dbo].[ItemCondition] ([ItemConditionID], [Name]) VALUES (2, N'Used')
INSERT [dbo].[ItemCondition] ([ItemConditionID], [Name]) VALUES (3, N'New (Damaged)')
INSERT [dbo].[ItemCondition] ([ItemConditionID], [Name]) VALUES (4, N'Used (Damaged)')

SET IDENTITY_INSERT [dbo].[ItemCondition] OFF

-- Item Description

-- NONE

-- Items

SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT INTO [dbo].[Item] (ItemID, Name, ItemDescriptionID, [Index], ProductionYear, CategoryID, ProducerID, RarityID, MarketPrice)
SELECT
	ToyID
	,Name
	,NULL
	,[Index]
	,NULL
	,CategoryId
	,ProducerId
	,(SELECT ItemRarityID from ItemRarity where Name = 'Common') -- Rarity
	,COALESCE(Price, SoldPrice)
FROM [Collection].[dbo].[Toys];

SET IDENTITY_INSERT [dbo].[Item] OFF 

-- Item Images

SET IDENTITY_INSERT [dbo].[ItemImage] ON

INSERT INTO [dbo].[ItemImage] (ItemImageID, Name, ItemID)
SELECT 
	GalleryID
	,FileName
	,ToyID
	FROM [Collection].[dbo].[Gallery]

SET IDENTITY_INSERT [dbo].[ItemImage] OFF 

-- User Roles

SET IDENTITY_INSERT [dbo].[UserRole] ON

INSERT [dbo].[UserRole] ([UserRoleID], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([UserRoleID], [Name]) VALUES (2, N'User')

SET IDENTITY_INSERT [dbo].[UserRole] OFF

-- User 

SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [Email], [Username], [Password], [UserRoleID], [IsActive], [Salt]) VALUES (10000, N'harukapl@gmail.com', N'Abigail', N'secret123', 1, 1, N'')

SET IDENTITY_INSERT [dbo].[User] OFF

-- User Items

--SET IDENTITY_INSERT [dbo].[UserItem] ON 

INSERT INTO [dbo].[UserItem] (UserID, ItemID, PriceBuy, PriceSell, BuyDate, SellDate, StateID, ConditionID)
SELECT 
	(SELECT UserID FROM [dbo].[User] WHERE Username = 'Abigail') 
	,T.ToyID
	,T.Price
	,T.SoldPrice
	,T.PurchaseDate
	,T.SoldDate
	,CASE 
		WHEN T.InCollection = 0 AND T.Sold = 0 AND T.ForSale = 0 THEN 1 -- Wanted
		WHEN T.InCollection = 1 AND T.Sold = 0 AND T.ForSale = 0 THEN 2 -- In Collection
		WHEN T.InCollection = 1 AND T.Sold = 0 AND T.ForSale = 1 THEN 3 -- For Sale
		WHEN T.InCollection = 0 AND T.Sold = 1 AND T.ForSale = 0 THEN 4 -- Sold
		ELSE 0 -- None
	END
	,CASE
		WHEN T.IsDamaged = 0 AND T.Condition = 0 THEN 1	-- New
		WHEN T.IsDamaged = 0 AND T.Condition = 1 THEN 2 -- Used
		WHEN T.IsDamaged = 1 AND T.Condition = 0 THEN 3 -- New (Damaged)
		WHEN T.IsDamaged = 1 AND T.Condition = 1 THEN 4 -- Used (Damaged)
	END
FROM [Collection].[dbo].[Toys] T
WHERE T.ForSale = 1 OR T.InCollection = 1 OR T.InCollection = 1 OR T.Sold = 1
 

--SET IDENTITY_INSERT [dbo].[UserItem] OFF

RETURN 0
