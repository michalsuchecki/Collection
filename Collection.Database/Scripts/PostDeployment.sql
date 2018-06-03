/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Common
--:r .\Common\Category.Table.sql
--GO
--:r .\Common\Producer.Table.sql
--GO

-- Items
--:r .\Item\ItemRarity.Table.sql
--GO
--:r .\Item\ItemState.Table.sql
--GO
--:r .\Item\ItemCondition.Table.sql
--GO
--:r .\Item\ItemDescription.Table.sql
--GO
--:r .\Item\Item.Table.sql
--GO
--:r .\Item\ItemImage.Table.sql
--GO

-- User
--:r .\User\UserRole.Table.sql
--GO
--:r .\User\User.Table.sql
--GO
--:r .\User\UserItem.Table.sql
--GO

