CREATE TABLE [dbo].[News] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    [Date]    DATETIME       NOT NULL,
    CONSTRAINT [PK__News__3214EC0738F0DD23] PRIMARY KEY CLUSTERED ([Id] ASC)
);

