CREATE TABLE [dbo].[RaceBonuses] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [RaceId]  INT NOT NULL,
    [BonusId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

