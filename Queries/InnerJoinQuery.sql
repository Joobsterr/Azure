DECLARE @userID int = 1;
SELECT [name] FROM [Role] r INNER JOIN [UserRole] ur ON ur.[roleId] = r.id WHERE ur.userId = @userID