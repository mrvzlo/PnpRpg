CREATE TABLE [dbo].[Majors] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Color]       NVARCHAR (6)   NULL,
    [Enabled]     BIT            CONSTRAINT [DF_Majors_Enabled] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Majors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

