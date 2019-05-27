SELECT [User].*, Role.Name
FROM [User]
LEFT JOIN UserRole
ON [User].ID = UserRole.UserID
INNER JOIN Role
ON [UserRole].RoleID = Role.ID
ORDER BY UserRole.RoleID DESC