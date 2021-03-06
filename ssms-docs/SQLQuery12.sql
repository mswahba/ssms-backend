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

-- Renaming spell-error columns
-------------------------------
/*
sp_rename 'dbo.EmployeesHr.WorkStartDateG', 'workStartDateG', 'COLUMN';
select * from dbo.EmployeesHr;
*/
/*
sp_rename 'dbo.EmployeesHR', 'employeesHR';
select * from dbo.EmployeesHR;
*/
/*
sp_rename 'dbo.periods.classeroomId', 'classroomId', 'COLUMN';
select * from dbo.periods;
*/
/*
update users set accountStatusId = 2 where userId = '1133557799'
select * from users
*/
/*
update docTypes set isDeleted = 0
select * from docTypes
*/
/*
update countries set isDeleted = 0
select * from countries
*/
/*
select [name], [temporal_type_desc]
from sys.tables
order by [name]
select [name] from sys.views order by [name]
*/
/*
-- List Tables with its Columns
select TABLE_NAME, ORDINAL_POSITION, COLUMN_NAME, IS_NULLABLE, DATA_TYPE
from assadara_ssms.information_schema.columns
where TABLE_NAME not like '%History%' and TABLE_NAME not like 'v_%'
order by TABLE_NAME, ORDINAL_POSITION
*/