-- CREATE TABLE [dbo].[trackers] (
-- 	[trackerId] [int] identity(1,1) PRIMARY KEY,
-- 	[tableName] [varchar](50) NOT NULL,
-- 	[operation] [varchar](10) NOT NULL,
-- 	[payload] [varchar](max) NOT NULL,
-- 	[committedBy] [char](10) NOT NULL,
--   [committedAt] [smalldatetime] NOT NULL
-- )
-- GO

-- select * from trackers
-- select * from countries

-- CREATE TABLE [dbo].[notificationTypes] (
-- 	[notificationTypeId] [smallint] PRIMARY KEY,
-- 	[notificationType] [varchar](50) NOT NULL,
-- 	[messageKey] [varchar](max) NOT NULL,
--   [isDeleted] [bit] NULL
-- )
-- GO

-- drop table [notificationTypes]

-- ALTER TABLE [notificationTypes] ALTER COLUMN [notificationTypeId] smallint

-- CREATE TABLE [dbo].[notificationTypesUsers] (
--  [notificationTypeUserId] [int] IDENTITY(1,1) PRIMARY KEY,
-- 	[notificationTypeId] [smallint] NOT NULL,
-- 	[userId] [char](10) NOT NULL,
--   [isDeleted] [bit] NULL
-- )
-- GO

-- ALTER TABLE [notificationTypes] ALTER COLUMN [notificationTypeId] [smallint] NOT NULL

-- CREATE TABLE [dbo].[notifications] (
--   [notificationId ] [int] IDENTITY(1,1) PRIMARY KEY,
-- 	[notificationTypeId] [smallint] NOT NULL,
-- 	[userId] [char](10) NOT NULL,
--   [createdAt] [smalldatetime] NOT NULL,
--   [isDeleted] [bit] NULL
-- )
-- GO

-- select * from notifications