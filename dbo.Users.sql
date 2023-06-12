CREATE TABLE [dbo].[Users] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [lastName]    NVARCHAR (50) NOT NULL,
    [firstName]   NVARCHAR (50) NOT NULL,
    [middleName]  NVARCHAR (50) NOT NULL,
    [phoneNumber] NVARCHAR (50) NULL,
    [email]       NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

