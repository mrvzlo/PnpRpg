CREATE TABLE [dbo].[Abilities] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Symbol]      NCHAR (1)      NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Influence]   NVARCHAR (MAX) NOT NULL,
    [Color]       NVARCHAR (6)   NOT NULL,
    [MajorId]     INT            CONSTRAINT [DF_Abilities_MajorId] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

