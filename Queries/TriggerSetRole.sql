--====================================
--  Create database trigger template 
--====================================
CREATE TRIGGER SetRole on [User]
	AFTER INSERT
AS 
   	DECLARE @UserrID int = (SELECT TOP 1 [ID] FROM [User] ORDER BY ID DESC)
BEGIN
	INSERT INTO dbo.UserRole
	VALUES('1', @UserrID)
END
GO


