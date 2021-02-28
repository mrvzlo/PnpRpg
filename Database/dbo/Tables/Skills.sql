CREATE TABLE [dbo].[Skills] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [AbilityId]  INT           NOT NULL,
    [BranchId]   INT           NOT NULL,
    [Difficulty] INT           DEFAULT ((1)) NOT NULL,
    [Type]       INT           DEFAULT ((0)) NOT NULL,
    [MajorId]    INT           CONSTRAINT [DF_Skills_MajorId] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SkillInfoes_Abilities] FOREIGN KEY ([AbilityId]) REFERENCES [dbo].[Abilities] ([Id])
);

