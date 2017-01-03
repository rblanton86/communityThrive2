/*============================================= 
Description:      
ReadProcedurectUser
Author: Francisco Duran    
Date: 12-11-16
Change History:      
=============================================*/
USE communityThrive2DB;
GO
CREATE PROCEDURE sp_selectct2User
    @userID int
AS
BEGIN 

    DECLARE @v_error VARCHAR(255),
    @v_errorNo INT

    BEGIN TRY

        SELECT  usr.userID
		,usr.roleIDFK
	   ,usr.companyIDFK
	   ,usr.userTypeIDFK
	   ,usr.emailaddress
	   ,usr.userPassword
	   ,usr.firstName
	   ,usr.lastName
	   ,usr.phoneNumber
	   ,usr.streetAddress
	   ,usr.cityIDFK
	   ,usr.stateIDFK
	   ,zipcode
		FROM ct2User usr
		--- Joins role,company,usertype,city, and stateIDFK foreign keys to primary keys
		LEFT JOIN ct2Role rl ON usr.roleIDFK = rl.roleID
		LEFT JOIN ct2Company com ON usr.companyIDFK = com.companyID
		LEFT JOIN ct2UserType ut ON usr.userTypeIDFK = ut.userTypeID
		LEFT JOIN ct2City cy ON usr.cityIDFK = cy.cityID
		LEFT JOIN ct2State st ON usr.stateIDFK = st.StateID
		
		ORDER BY usr.userID, usr.firstName, usr.lastName
    END TRY
    BEGIN CATCH

        SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END