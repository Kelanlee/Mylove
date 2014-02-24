CREATE TABLE [dbo].[Tracking] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [UserId]       INT           NULL,
    [Tracking]     VARCHAR (MAX) NULL,
    [TrackingType] INT           NOT NULL,
    CONSTRAINT [PK_Tracking] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Tracking_TrackingType] FOREIGN KEY ([TrackingType]) REFERENCES [dbo].[TrackingType] ([TrackingTypeId]),
    CONSTRAINT [FK_Tracking_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

