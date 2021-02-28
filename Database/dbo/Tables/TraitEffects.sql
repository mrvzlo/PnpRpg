CREATE TABLE [dbo].[TraitEffects] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Value]       INT            DEFAULT ((1)) NOT NULL,
    [TargetId]    INT            NOT NULL,
    [TargetType]  INT            DEFAULT ((0)) NOT NULL,
    [TraitId]     INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Type]        INT            CONSTRAINT [DF_TraitEffects_Type] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

