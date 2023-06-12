CREATE TABLE [dbo].[Goods] (
	[Id]       INT           IDENTITY (1, 1) NOT NULL,
    [email]    NVARCHAR (50) NOT NULL,
    [code]     INT           NOT NULL,
    [goodName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

