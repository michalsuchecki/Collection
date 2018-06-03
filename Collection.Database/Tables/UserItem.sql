CREATE TABLE [dbo].[UserItem] (
    [UserItemID]  INT             IDENTITY (1, 1) NOT NULL,
    [UserID]      INT             NOT NULL,
    [ItemID]      INT             NOT NULL,
    [PriceBuy]    DECIMAL (18, 2) DEFAULT ((0)),
    [PriceSell]   DECIMAL (18, 2) DEFAULT ((0)),
	[BuyDate]	  DATE			  NULL,
	[SellDate]	  DATE			  NULL,
    [StateID]     INT             NOT NULL,
    [ConditionID] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([UserItemID] ASC),
    CONSTRAINT [FK_ItemCondition] FOREIGN KEY ([ConditionID]) REFERENCES [dbo].[ItemCondition] ([ItemConditionID]),
    CONSTRAINT [FK_ItemState] FOREIGN KEY ([StateID]) REFERENCES [dbo].[ItemState] ([ItemStateID]),
    CONSTRAINT [FK_UserItemItem] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ItemID]),
    CONSTRAINT [FK_UserItemUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID])
);

