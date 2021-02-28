CREATE TABLE [dbo].[Bonuses] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Icon]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Type]        INT            NOT NULL,
    [MajorId]     INT            CONSTRAINT [DF_Bonuses_MajorId] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

