CREATE TABLE [dbo].[Item] (
    [ItemID]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (MAX)  NOT NULL,
    [ItemDescriptionID] INT             NULL,
    [Index]             NVARCHAR (MAX)  NULL,
    [ProductionYear]    DATE            NULL,
    [CategoryID]        INT             NOT NULL,
    [ProducerID]        INT             NOT NULL,
    [RarityID]          INT             NOT NULL,
    [MarketPrice]       DECIMAL (18, 2) DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC),
    CONSTRAINT [FK_ItemCategory] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID]),
    CONSTRAINT [FK_ItemDescription] FOREIGN KEY ([ItemDescriptionID]) REFERENCES [dbo].[ItemDescription] ([ItemDescriptionID]),
    CONSTRAINT [FK_ItemProducer] FOREIGN KEY ([ProducerID]) REFERENCES [dbo].[Producer] ([ProducerID]),
    CONSTRAINT [FK_ItemRarity] FOREIGN KEY ([RarityID]) REFERENCES [dbo].[ItemRarity] ([ItemRarityID])
);

