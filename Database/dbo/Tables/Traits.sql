CREATE TABLE [dbo].[Traits] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [MajorId] INT           CONSTRAINT [DF_Traits_MajorId] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

