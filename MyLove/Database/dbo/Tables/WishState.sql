CREATE TABLE [dbo].[WishState] (
    [WishStateId] INT          IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (50) NULL,
    CONSTRAINT [PK_WishState] PRIMARY KEY CLUSTERED ([WishStateId] ASC)
);

