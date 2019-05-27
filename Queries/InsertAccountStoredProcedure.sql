USE [dbi408687]
GO
/****** Object:  StoredProcedure [dbo].[InsertAccount]    Script Date: 27-5-2019 09:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertAccount]
	@username nchar(50),
	@password nchar(100),
	@email nchar(50),
	@cdate datetime
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [User](username, email, password, CreationDate) VALUES (@username,@email,@password, @cdate)
END
