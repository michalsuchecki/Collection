CREATE TABLE [dbo].[Producer] (
    [ProducerID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [Url]        NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([ProducerID] ASC)
);

