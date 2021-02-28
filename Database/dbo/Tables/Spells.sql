CREATE TABLE [dbo].[Spells] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Level]         INT            NOT NULL,
    [MagicSchoolId] INT            NOT NULL,
    [Damage]        INT            DEFAULT ((0)) NOT NULL,
    [Cost]          NVARCHAR (MAX) NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Effect]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

