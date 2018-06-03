CREATE TABLE [dbo].[Category] (
    [CategoryID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [Level]      INT           NOT NULL DEFAULT(1),
    [ParentID]   INT           NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [FK_CategoryCategory] FOREIGN KEY ([ParentID]) REFERENCES [dbo].[Category] ([CategoryID])
);

