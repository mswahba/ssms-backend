-- CREATE TABLE [dbo].[mediaCategories] (
-- 	[categoryId] [tinyint] PRIMARY KEY,
-- 	[categoryNameAr] [nvarchar](100) NOT NULL,
--   [categoryNameEn] [nvarchar](100) NOT NULL,
--   [categoryType] [varchar](100) NOT NULL,
-- )
-- GO

-- insert into mediaCategories values (1, 'أخبار','News', 'articles')
-- insert into mediaCategories values (2, 'مقالات','Articles', 'articles')
-- insert into mediaCategories values (3, 'أنشطة','Activities', 'articles')
-- insert into mediaCategories values (4, 'برامج','Programs', 'articles')
-- insert into mediaCategories values (5, 'ألبوم','Albums', 'albums')
-- insert into mediaCategories values (6, 'الشرائح الرئيسية','Hero Slider', 'albums')
-- insert into mediaCategories values (7, 'روابط مواقع التواصل','Social Media Links', 'about')
-- insert into mediaCategories values (8, 'بيانات اساسية','Basic Info', 'about')

-- CREATE TABLE [dbo].[about] (
-- 	[aboutId] [int] identity(1,1) PRIMARY KEY,
-- 	[aboutTitle] [nvarchar](100) NOT NULL,
-- 	[aboutText] [nvarchar](max) NOT NULL,
-- 	[aboutDate] [smalldatetime] NOT NULL,
-- 	[photoURL] [varchar](max) NULL,
--   [isGlobal] [bit] NOT NULL,
--   [schoolId] [tinyint] NULL,
-- 	[stageId] [tinyint] NULL,
--   [empJobId] [int] NULL,
-- 	[categoryId] [tinyint] NULL,
-- )
-- GO

-- add 4 relations [employeesJobs - departments - schools - mediaCategories]
----------------------------------------------------------
-- ALTER TABLE [dbo].[about]
-- ADD CONSTRAINT [FK_employeesJobs_about] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[about]
-- ADD CONSTRAINT [FK_departments_about] FOREIGN KEY([stageId])
-- REFERENCES [dbo].[departments] ([departmentId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[about]
-- ADD CONSTRAINT [FK_schools_about] FOREIGN KEY([schoolId])
-- REFERENCES [dbo].[schools] ([schoolId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[about] ALTER COLUMN [categoryId] [tinyint] NULL

-- ALTER TABLE [dbo].[about]
-- ADD CONSTRAINT [FK_mediaCategories_about] FOREIGN KEY([categoryId])
-- REFERENCES [dbo].[mediaCategories] ([categoryId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-----------------------------------------------------------------
-- ALTER TABLE [dbo].[articles] ADD [isImportant] [bit] NOT NULL
-- ALTER TABLE [dbo].[albums] ADD [isImportant] [bit] NOT NULL
-- ALTER TABLE [dbo].[articles] DROP COLUMN [isImportant]
-- ALTER TABLE [dbo].[albums] DROP COLUMN [isImportant]
-- ALTER TABLE [dbo].[articles] ADD [displayAlsoAt] [varchar](10) NOT NULL DEFAULT('none')
-- ALTER TABLE [dbo].[albums] ADD [displayAlsoAt] [varchar](10) NOT NULL DEFAULT('none')
-- sp_rename 'dbo.articles.isGlobal', 'forCompany', 'COLUMN'
-- GO
-- sp_rename 'dbo.albums.isGlobal', 'forCompany', 'COLUMN'
-- GO
-----------------------------------------------------------------
-- -- displayAlsoAt: [company - school - both - none]
-- -- to specify which [article and/or album] should be displayed at a higher rank [global - school]
----------------------------------------------------------------------------------------------------
-- CREATE TABLE [dbo].[articles] (
-- 	[articleId] [int] identity(1,1) PRIMARY KEY,
-- 	[articleTitle] [nvarchar](100) NOT NULL,
-- 	[articleText] [nvarchar](max) NOT NULL,
-- 	[articleDate] [smalldatetime] NOT NULL,
--  [authorName] [nvarchar](100) NULL,
-- 	[mainPhotoURL] [varchar](max) NULL,
-- 	[photosURLs] [varchar](max) NULL,
-- 	[videosURLs] [varchar](max) NULL,
--  [displayAlsoAt] [varchar](10) NOT NULL,
--  [isGlobal] [bit] NOT NULL,
--  [schoolId] [tinyint] NULL,
-- 	[stageId] [tinyint] NULL,
--  [empJobId] [int] NULL,
-- 	[categoryIds] [varchar](max) NULL,
--  [approved] [bit] NOT NULL,
--  [enabled] [bit] NOT NULL,
--  [keywords] [nvarchar](max) NULL,
-- )
-- GO

-- add 3 relations [employeesJobs - departments - schools]
----------------------------------------------------------
-- ALTER TABLE [dbo].[articles]
-- ADD CONSTRAINT [FK_employeesJobs_articles] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[articles]
-- ADD CONSTRAINT [FK_departments_articles] FOREIGN KEY([stageId])
-- REFERENCES [dbo].[departments] ([departmentId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[articles]
-- ADD CONSTRAINT [FK_schools_articles] FOREIGN KEY([schoolId])
-- REFERENCES [dbo].[schools] ([schoolId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- CREATE TABLE [dbo].[albums] (
-- 	[albumId] [int] identity(1,1) PRIMARY KEY,
-- 	[albumTitleAr] [nvarchar](100) NOT NULL,
--   [albumTitleEn] [nvarchar](100) NOT NULL,
--   [descriptionAr] [nvarchar](max) NULL,
--   [descriptionEn] [nvarchar](max) NULL,
--   [albumDate] [smalldatetime] NOT NULL,
--   [keywords] [nvarchar](max) NULL,
--   [displayAlsoAt] [varchar](10) NOT NULL,
--   [forCompany] [bit] NOT NULL,
--   [approved] [bit] NOT NULL,
--   [enabled] [bit] NOT NULL,
--   [schoolId] [tinyint] NULL,
-- 	 [stageId] [tinyint] NULL,
--   [empJobId] [int] NULL,
--   [categoryId] [tinyint] NULL,
-- )
-- GO

-- add 4 relations [employeesJobs - departments - schools - mediaCategories]
----------------------------------------------------------------------------
-- ALTER TABLE [dbo].[albums]
-- ADD CONSTRAINT [FK_employeesJobs_albums] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[albums]
-- ADD CONSTRAINT [FK_departments_albums] FOREIGN KEY([stageId])
-- REFERENCES [dbo].[departments] ([departmentId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[albums]
-- ADD CONSTRAINT [FK_schools_albums] FOREIGN KEY([schoolId])
-- REFERENCES [dbo].[schools] ([schoolId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[albums]
-- ADD CONSTRAINT [FK_mediaCategories_albums] FOREIGN KEY([categoryId])
-- REFERENCES [dbo].[mediaCategories] ([categoryId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- CREATE TABLE [dbo].[photos] (
-- 	[photoId] [int] identity(1,1) PRIMARY KEY,
-- 	[photoTitleAr] [nvarchar](100) NOT NULL,
--   [photoTitleEn] [nvarchar](100) NOT NULL,
--   [descriptionAr] [nvarchar](max) NULL,
--   [descriptionEn] [nvarchar](max) NULL,
--   [photoURL] [varchar](max) NOT NULL,
--   [thumbURL] [varchar](max) NOT NULL,
--   [moreURL] [varchar](max) NULL,
--   [photoDate] [smalldatetime] NOT NULL,
--   [approved] [bit] NOT NULL,
--   [enabled] [bit] NOT NULL,
--   [empJobId] [int] NULL,
--   [albumId] [int] NULL,
-- )
-- GO

-- insert photos instructions
------------------------------
-- inset photo in table
-- generate photo name before save it in host: [albumId]_[photoId]_[photo|thumb]
-- save it to host
-- update the photoURL & thumbURL

-- add 2 relations [employeesJobs - albums]
----------------------------------------------------------------------------
-- ALTER TABLE [dbo].[photos]
-- ADD CONSTRAINT [FK_employeesJobs_photos] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[photos]
-- ADD CONSTRAINT [FK_albums_photos] FOREIGN KEY([albumId])
-- REFERENCES [dbo].[albums] ([albumId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO
-------------------------------------------------------------------------------------------

-- List columns in all tables whose name is like 'articles'
-- SELECT
--   TableName = tbl.TABLE_SCHEMA + '.' + tbl.TABLE_NAME,
--   ColumnName = col.COLUMN_NAME,
--   DataType = col.DATA_TYPE,
--   [IsNull] = col.IS_NULLABLE
-- FROM INFORMATION_SCHEMA.TABLES tbl
-- INNER JOIN INFORMATION_SCHEMA.COLUMNS col
--   ON col.TABLE_NAME = tbl.TABLE_NAME
--   AND col.TABLE_SCHEMA = tbl.TABLE_SCHEMA
-- WHERE tbl.TABLE_TYPE = 'BASE TABLE' and tbl.TABLE_NAME = 'articles'
-- GO

-- SELECT
--   TableName = tbl.TABLE_SCHEMA + '.' + tbl.TABLE_NAME,
--   ColumnName = col.COLUMN_NAME,
--   DataType = col.DATA_TYPE,
--   [IsNull] = col.IS_NULLABLE
-- FROM INFORMATION_SCHEMA.TABLES tbl
-- INNER JOIN INFORMATION_SCHEMA.COLUMNS col
--   ON col.TABLE_NAME = tbl.TABLE_NAME
--   AND col.TABLE_SCHEMA = tbl.TABLE_SCHEMA
-- WHERE tbl.TABLE_TYPE = 'BASE TABLE' and col.COLUMN_NAME = 'stageId'
-- GO

-- sp_fkeys 'stages'
---------------------
-- FK_grades_stages
-- FK_schoolDayEvents_stages

-- Add a new column 'isStage' to table 'departments' in schema 'dbo'
-- ALTER TABLE dbo.departments ADD isStage [bit] NOT NULL DEFAULT(0)
-- GO

-- replace the relation between grades and stages with one between grades and departments
-- ALTER TABLE [dbo].[grades] DROP CONSTRAINT [FK_grades_stages]
-- GO
-- ALTER TABLE [dbo].[grades]
-- ADD CONSTRAINT [FK_departments_grades] FOREIGN KEY([stageId])
-- REFERENCES [dbo].[departments] ([departmentId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- replace the relation between schoolDayEvents and stages with one between schoolDayEvents and departments
-- ALTER TABLE [dbo].[schoolDayEvents] DROP CONSTRAINT [FK_schoolDayEvents_stages]
-- GO
-- ALTER TABLE [dbo].[schoolDayEvents]
-- ADD CONSTRAINT [FK_departments_schoolDayEvents] FOREIGN KEY([stageId])
-- REFERENCES [dbo].[departments] ([departmentId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- delete the stages table
-- DROP TABLE [stages]

-- ALTER TABLE [dbo].[departments] ADD [branchId] [tinyint] NULL
-- DELETE FROM [dbo].[departments]
-- DELETE FROM [dbo].[grades]
-- DELETE FROM [dbo].[schoolDayEvents]

-- SELECT * from [dbo].[mediaCategories]