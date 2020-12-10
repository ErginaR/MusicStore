CREATE TABLE [dbo].[Albums] (
    [AlbumID] INT             IDENTITY (1, 1) NOT NULL,
    [Genre]   NVARCHAR (50)   NOT NULL,
    [Title]   NVARCHAR (50)   NOT NULL,
    [Artist]  NVARCHAR (50)   NOT NULL,
    [Price]   DECIMAL (16, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([AlbumID] ASC)
);

