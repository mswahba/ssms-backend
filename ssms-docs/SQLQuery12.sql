-- Add notifications FKs
------------------------
ALTER TABLE [dbo].notifications ALTER COLUMN userId CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].notifications
ADD CONSTRAINT [FK_users_notifications] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO

ALTER TABLE [dbo].notifications ALTER COLUMN notificationTypeId smallint null
GO
ALTER TABLE [dbo].notifications
ADD CONSTRAINT [FK_notificationTypes_notifications] FOREIGN KEY(notificationTypeId)
REFERENCES [dbo].[notificationTypes] (notificationTypeId)
ON UPDATE CASCADE
ON DELETE SET NULL
GO

-- Add notificationTypesUsers FKs
------------------------
ALTER TABLE [dbo].notificationTypesUsers ALTER COLUMN userId CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].notificationTypesUsers
ADD CONSTRAINT [FK_users_notificationTypesUsers] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO

ALTER TABLE [dbo].notificationTypesUsers
ADD CONSTRAINT [FK_notificationTypes_notificationTypesUsers] FOREIGN KEY(notificationTypeId)
REFERENCES [dbo].[notificationTypes] (notificationTypeId)
ON UPDATE CASCADE
ON DELETE SET NULL
GO