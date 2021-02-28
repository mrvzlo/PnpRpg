CREATE TABLE [dbo].[Reactions] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [Reagent]  INT NOT NULL,
    [Process]  INT NOT NULL,
    [PotionId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

