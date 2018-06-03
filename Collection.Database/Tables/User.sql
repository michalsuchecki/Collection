CREATE TABLE [dbo].[User] (
    [UserID]     INT            IDENTITY (10000, 1) NOT NULL,
    [Email]      NVARCHAR (100) NOT NULL,
    [Username]   NVARCHAR (100) NOT NULL,
    [Password]   NVARCHAR (100) NOT NULL,
	[Salt]		 NVARCHAR (32)	NOT NULL,
    [UserRoleID] INT            NOT NULL,
    [IsActive]   BIT            NOT NULL,
	[Activation] NVARCHAR (32)	NULL,
	[Birthday]	 DATE			NULL,
	[LastLogin]	 DATETIME2		NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_UserRole] FOREIGN KEY ([UserRoleID]) REFERENCES [dbo].[UserRole] ([UserRoleID])
);

