CREATE TABLE [dbo].[WeaponsBonuses] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [WeaponId] INT NOT NULL,
    [BonusId]  INT NOT NULL,
    CONSTRAINT [PK_WeaponsBonuses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

