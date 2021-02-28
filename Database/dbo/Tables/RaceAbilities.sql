CREATE TABLE [dbo].[RaceAbilities] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [RaceId]    INT NOT NULL,
    [AbilityId] INT NOT NULL,
    [Value]     INT NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__3214EC0719EF08D3] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RaceAbilities_Abilities] FOREIGN KEY ([AbilityId]) REFERENCES [dbo].[Abilities] ([Id]),
    CONSTRAINT [FK_RaceAbilities_Races] FOREIGN KEY ([RaceId]) REFERENCES [dbo].[Races] ([Id])
);

