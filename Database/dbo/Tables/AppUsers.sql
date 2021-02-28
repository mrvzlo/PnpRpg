CREATE TABLE [dbo].[AppUsers] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [Role]     INT            NOT NULL,
    [RoomId]   INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

