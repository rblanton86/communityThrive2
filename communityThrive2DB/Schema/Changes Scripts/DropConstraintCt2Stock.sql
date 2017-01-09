USE [communityThrive2DB]
GO

ALTER TABLE [dbo].[ct2Stock] DROP CONSTRAINT [FK__ct2Stock__invent__5CD6CB2B]
GO

ALTER TABLE ct2Stock
DROP COLUMN inventoryIDFK
GO