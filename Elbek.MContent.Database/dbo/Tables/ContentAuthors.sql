CREATE TABLE[dbo].[ContentAuthors] (
[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
[AuthorId] UNIQUEIDENTIFIER NOT NULL,
[ContentId] UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY ([AuthorId]) REFERENCES[dbo].[Authors],
    FOREIGN KEY ([ContentId]) REFERENCES[dbo].[Contents])
