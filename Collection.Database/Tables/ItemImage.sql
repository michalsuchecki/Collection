CREATE TABLE [dbo].[ItemImage] (
    [ItemImageID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [ItemID]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ItemImageID] ASC),
    CONSTRAINT [FK_ItemImageItem] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ItemID])
);

