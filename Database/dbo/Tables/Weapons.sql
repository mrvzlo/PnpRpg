CREATE TABLE [dbo].[Weapons] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Level]   INT            NOT NULL,
    [SkillId] INT            NOT NULL,
    [Weight]  INT            NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [MajorId] INT            CONSTRAINT [DF_Weapons_MajorId] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

