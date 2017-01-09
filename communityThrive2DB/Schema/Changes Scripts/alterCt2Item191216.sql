USE [communityThrive2DB]
GO

ALTER TABLE ct2Item ADD  DEFAULT ((0)) FOR itemPrice
GO