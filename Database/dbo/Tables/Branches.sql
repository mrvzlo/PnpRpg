CREATE TABLE [dbo].[Branches] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [Color]            NCHAR (6)      NOT NULL,
    [Description]      NVARCHAR (MAX) NULL,
    [ShortDescription] NVARCHAR (MAX) NULL,
    [MajorId]          INT            CONSTRAINT [DF_Branches_MajorId] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

