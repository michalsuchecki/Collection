SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [Email], [Username], [Password], [UserRoleID], [IsActive], [Salt]) VALUES (10000, N'harukapl@gmail.com', N'Abigail', N'secret123', 1, 1, N'')
SET IDENTITY_INSERT [dbo].[User] OFF
