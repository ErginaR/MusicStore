CREATE TABLE [dbo].[Users] (
    [UserID]   INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (50)  NOT NULL,
    [Email]    NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

