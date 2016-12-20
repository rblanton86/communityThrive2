USE [communityThrive2DB]
GO

ALTER TABLE [dbo].[ct2Inventory] DROP CONSTRAINT [FK__ct2Invent__categ__46E78A0C]
GO

ALTER TABLE ct2Inventory
DROP COLUMN categoryIDFK;
GO