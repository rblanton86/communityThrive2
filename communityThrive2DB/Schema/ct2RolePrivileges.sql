USE communityThrive2DB


GO
CREATE TABLE ct2RolePrivilege(
	rolePrivilegeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	roleIDFK INT FOREIGN KEY REFERENCES ct2Role(roleID) NOT NULL,
	privilegeIDFK INT FOREIGN KEY REFERENCES ct2Privilege(privilegeID) NOT NULL
	
	
)

GO


