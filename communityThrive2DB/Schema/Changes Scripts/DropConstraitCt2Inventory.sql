USE [communityThrive2DB]
GO

ALTER TABLE [dbo].[ct2Inventory] DROP CONSTRAINT [FK__ct2Invent__categ__49C3F6B7]
GO

ALTER TABLE ct2Inventory
DROP COLUMN categoryIDFK;
GO