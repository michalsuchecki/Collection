CREATE TABLE [dbo].[UserRole] (
    [UserRoleID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserRoleID] ASC)
);

