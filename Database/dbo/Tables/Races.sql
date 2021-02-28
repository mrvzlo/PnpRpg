CREATE TABLE [dbo].[Races] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Karma]       INT            DEFAULT ((0)) NOT NULL,
    [MajorId]     INT            CONSTRAINT [DF_Races_MajorId] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

