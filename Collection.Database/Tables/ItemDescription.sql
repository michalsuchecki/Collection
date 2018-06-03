CREATE TABLE [dbo].[ItemDescription] (
    [ItemDescriptionID] INT            IDENTITY (1, 1) NOT NULL,
    [Description]       NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([ItemDescriptionID] ASC)
);

