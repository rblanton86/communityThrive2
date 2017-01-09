USE [communityThrive2DB]
GO

ALTER TABLE ct2Stock ADD  DEFAULT ((0)) FOR stockQuantity
GO