CREATE TABLE [dbo].[MemberShip] (
    [UserId]    INT          NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    [WrongTime] INT          NULL,
    CONSTRAINT [FK_MemberShip_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

