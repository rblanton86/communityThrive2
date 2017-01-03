-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	JOINS Donation and Category table to Inventory
-- =============================================
 
SELECT  dona.donationID,
		dona.userIDFK,
		dona.eventIDFK,
		dona.dateSubmitted, 
		dona.donationNotes

FROM ct2Inventory invi

LEFT JOIN ct2Donation dona ON invi.donationIDFK = dona.donationID
--inner join ct2Event evt on don.eventIDFK = evt.EventID

order by invi.inventoryID


