CREATE TABLE [dbo].[TrackingType] (
    [TrackingTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [Description]    VARCHAR (50) NULL,
    CONSTRAINT [PK_TrackingType] PRIMARY KEY CLUSTERED ([TrackingTypeId] ASC)
);

