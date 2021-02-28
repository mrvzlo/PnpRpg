CREATE TABLE [dbo].[BranchBonuses] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [BranchId] INT NOT NULL,
    [BonusId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

