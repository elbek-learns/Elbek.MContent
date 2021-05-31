﻿CREATE TABLE [dbo].[Advert]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[ContentId] UNIQUEIDENTIFIER NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT 1,
	[IsDeleted] BIT NOT NULL DEFAULT 0, 
	[PublishDate] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdateDate] DATETIME 
	FOREIGN KEY ([ContentId]) REFERENCES [dbo].[Contents]
)