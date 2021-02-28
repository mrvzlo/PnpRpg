CREATE TABLE [dbo].[Rooms] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [Date] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

