USE communityThrive2DB


GO

CREATE TABLE ct2RolePrivilege(
	roleIDFK INT FOREIGN KEY REFERENCES ct2Role(roleID) NOT NULL,
	privilegeIDFK INT FOREIGN KEY REFERENCES ct2Privilege(privilegeID) NOT NULL
	
	
)

GO


