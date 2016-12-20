USE [communityThrive2DB]
GO

ALTER TABLE [dbo].[ct2Inventory] ADD  DEFAULT ((0)) FOR [inventoryQuantity]
GO