CREATE TABLE [dbo].[Creatures] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Level]       INT            NOT NULL,
    [Group]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [MajorId]     INT            CONSTRAINT [DF_Creatures_MajorId] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Creatures] PRIMARY KEY CLUSTERED ([Id] ASC)
);

