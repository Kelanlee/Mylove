CREATE TABLE [dbo].[Wishs] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [Wishcontent] VARCHAR (MAX) NULL,
    [WishStateId] INT           NULL,
    [WishTitle]   VARCHAR (50)  NULL,
    CONSTRAINT [PK_Wishs] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Wishs_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Wishs_WishState] FOREIGN KEY ([WishStateId]) REFERENCES [dbo].[WishState] ([WishStateId])
);

