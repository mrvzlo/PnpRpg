CREATE TABLE [dbo].[MagicSchools] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [GroupId]     INT            NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NOT NULL,
    [Color]       NCHAR (6)      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

