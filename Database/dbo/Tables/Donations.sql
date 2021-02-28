CREATE TABLE [dbo].[Donations] (
    [Id]      INT             IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX)  NOT NULL,
    [Current] DECIMAL (18, 2) NOT NULL,
    [Total]   DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

