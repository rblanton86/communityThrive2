-- =============================================
-- Author:		Alejandro C.
-- Create date: 12 December 2016
-- Description:	JOINS EventTYPE table to Event
-- =============================================

SELECT  evt.eventTypeID,
		evt.eventTypeDescription,
		evt.eventDesignation

FROM ct2Event eve

LEFT JOIN ct2EventType evt ON eve.eventTypeIDFK = evt.eventTypeID
--inner join ct2Event evt on don.eventIDFK = evt.EventID

ORDER BY eve.eventID


