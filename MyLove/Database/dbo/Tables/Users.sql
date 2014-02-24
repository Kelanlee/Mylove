CREATE TABLE [dbo].[Users] (
    [UserId]       INT          IDENTITY (1, 1) NOT NULL,
    [Username]     VARCHAR (50) NOT NULL,
    [Gender]       VARCHAR (10) NOT NULL,
    [PhotoRef]     VARCHAR (50) NULL,
    [Relationship] INT          NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_User] FOREIGN KEY ([Relationship]) REFERENCES [dbo].[Users] ([UserId])
);

