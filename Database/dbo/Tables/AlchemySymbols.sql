CREATE TABLE [dbo].[AlchemySymbols] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Symbol]     NVARCHAR (50)  NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [Value]      INT            NOT NULL,
    [SymbolType] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

