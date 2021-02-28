CREATE TABLE [dbo].[Perks] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [BranchId]    INT            NOT NULL,
    [Max]         INT            DEFAULT ((1)) NOT NULL,
    [Level]       INT            DEFAULT ((1)) NOT NULL,
    [MajorId]     INT            CONSTRAINT [DF_Perks_MajorId] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

