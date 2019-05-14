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

-- CREATE TABLE [dbo].[abouts] (
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

-- ALTER TABLE [dbo].[abouts] ALTER COLUMN [categoryId] [tinyint] NULL

-- add 4 relations [employeesJobs - departments - schools - mediaCategories]
---------------------------------------------------------------------------

-- ALTER TABLE [dbo].[abouts] DROP CONSTRAINT [FK_employeesJobs_about]
-- ALTER TABLE [dbo].[abouts]
-- ADD CONSTRAINT [FK_employeesJobs_abouts] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[abouts] DROP CONSTRAINT [FK_departments_about]
-- ALTER TABLE [dbo].[abouts]
-- ADD CONSTRAINT [FK_departments_abouts] FOREIGN KEY([stageId])
-- REFERENCES [dbo].[departments] ([departmentId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[abouts] DROP CONSTRAINT [FK_schools_about]
-- ALTER TABLE [dbo].[abouts]
-- ADD CONSTRAINT [FK_schools_abouts] FOREIGN KEY([schoolId])
-- REFERENCES [dbo].[schools] ([schoolId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[abouts] DROP CONSTRAINT [FK_mediaCategories_about]
-- ALTER TABLE [dbo].[abouts]
-- ADD CONSTRAINT [FK_mediaCategories_abouts] FOREIGN KEY([categoryId])
-- REFERENCES [dbo].[mediaCategories] ([categoryId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
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
-- sp_rename 'dbo.about', 'abouts'
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

-- ALTER TABLE [dbo].[articles] DROP CONSTRAINT [FK_employeesJobs_articles]
-- ALTER TABLE [dbo].[articles]
-- ADD CONSTRAINT [FK_employeesJobs_articles] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[articles] DROP CONSTRAINT [FK_departments_articles]
-- ALTER TABLE [dbo].[articles]
-- ADD CONSTRAINT [FK_departments_articles] FOREIGN KEY([stageId])
-- REFERENCES [dbo].[departments] ([departmentId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[articles] DROP CONSTRAINT [FK_schools_articles]
-- ALTER TABLE [dbo].[articles]
-- ADD CONSTRAINT [FK_schools_articles] FOREIGN KEY([schoolId])
-- REFERENCES [dbo].[schools] ([schoolId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-----------------------------------------------------------------------------

-- CREATE TABLE [dbo].[albums] (
-- 	[albumId] [int] identity(1,1) PRIMARY KEY,
-- 	[albumTitleAr] [nvarchar](100) NOT NULL,
--   [albumTitleEn] [nvarchar](100) NOT NULL,
--   [descriptionAr] [nvarchar](max) NULL,
--   [descriptionEn] [nvarchar](max) NULL,
--   [albumDate] [smalldatetime] NOT NULL,
--   [keywords] [nvarchar](max) NULL,
--   [displayAlsoAt] [varchar](10) NOT NULL,
--   [approved] [bit] NOT NULL,
--   [enabled] [bit] NOT NULL,
--   [forCompany] [bit] NOT NULL,
--   [schoolId] [tinyint] NULL,
-- 	 [stageId] [tinyint] NULL,
--   [empJobId] [int] NULL,
--   [categoryId] [tinyint] NULL,
-- )
-- GO

-- Insert rows into table '[dbo].[albums]'
-- INSERT INTO [dbo].[albums]
-- ( -- columns to insert data into
--  [albumTitleAr], [albumTitleEn], [descriptionAr], [descriptionEn],
--  [albumDate], [displayAlsoAt], [forCompany], [approved], [enabled], [categoryId]
-- )
-- VALUES
-- ( -- values for the columns in the list above
--  'ألبوم الصفحة الرئيسية', 'Hero Slider', 'الألبوم الذي يعرض في أول الصفحة الرئيسية', 'The home page Hero Slider',
--  GETUTCDATE(), 'company', 1, 1, 1, 6
-- )
-- GO

-- SELECT * from [dbo].[albums]

-- add 4 relations [employeesJobs - departments - schools - mediaCategories]
----------------------------------------------------------------------------

-- ALTER TABLE [dbo].[albums] DROP CONSTRAINT [FK_employeesJobs_albums]
-- ALTER TABLE [dbo].[albums]
-- ADD CONSTRAINT [FK_employeesJobs_albums] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[albums] DROP CONSTRAINT [FK_departments_albums]
-- ALTER TABLE [dbo].[albums]
-- ADD CONSTRAINT [FK_departments_albums] FOREIGN KEY([stageId])
-- REFERENCES [dbo].[departments] ([departmentId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[albums] DROP CONSTRAINT [FK_schools_albums]
-- ALTER TABLE [dbo].[albums]
-- ADD CONSTRAINT [FK_schools_albums] FOREIGN KEY([schoolId])
-- REFERENCES [dbo].[schools] ([schoolId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[albums] DROP CONSTRAINT [FK_mediaCategories_albums]
-- ALTER TABLE [dbo].[albums]
-- ADD CONSTRAINT [FK_mediaCategories_albums] FOREIGN KEY([categoryId])
-- REFERENCES [dbo].[mediaCategories] ([categoryId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-------------------------------------------------------------------------------------
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

-- Insert rows into table '[dbo].[photos]'
-- INSERT INTO [dbo].[photos]
-- ( -- columns to insert data into
--  [photoTitleAr],
--  [photoTitleEn],
--  [descriptionAr],
--  [descriptionEn],
--  [photoURL],
--  [thumbURL],
--  [photoDate], [approved], [enabled], [albumId]
-- )
-- VALUES
-- ( -- values for the columns in the list above
--  'حفل خريجي مدارس الصدارة',
--  'Assadarah Graduation Party',
--  'تكريم خريجي مدارس الصدارة الدفعة السابعة',
--  'Honoring Assadarah Graduates for Intake 7',
--  'https://previews.dropbox.com/p/thumb/AAY8d1Wp3yFGvsljOWZTXoxG8G9tTGcqRVDTLhiOrIvgKabxhBBXqMbiPOmaRbifjIpqt8WzueGnThvJJSKSd6wS34wMn1hV6DLGX60MknIzuz-qyy9I9R9FEDZm3EVGHud85bEQdxaL-FIkUvO_kTmNCWrMVeRcrIbKC5fQM0EhdkouK-LkeFRY2QpYpeuuaZIYO3BG_nX3cPGRaQ20wYpnVBQpdf_b2MUoxC7fpCRgTHa6xXH4tq1iLN_VHMXXYMmTh5OAXiRUjj2-6uGuG6vBQurSFiZ5DeJhmYcFMwwGyaopFw6JtD5Bir8NNmXfOTJ7gdlg5W-52__dcft-tM11/p.jpeg',
--  'https://previews.dropbox.com/p/thumb/AAY8d1Wp3yFGvsljOWZTXoxG8G9tTGcqRVDTLhiOrIvgKabxhBBXqMbiPOmaRbifjIpqt8WzueGnThvJJSKSd6wS34wMn1hV6DLGX60MknIzuz-qyy9I9R9FEDZm3EVGHud85bEQdxaL-FIkUvO_kTmNCWrMVeRcrIbKC5fQM0EhdkouK-LkeFRY2QpYpeuuaZIYO3BG_nX3cPGRaQ20wYpnVBQpdf_b2MUoxC7fpCRgTHa6xXH4tq1iLN_VHMXXYMmTh5OAXiRUjj2-6uGuG6vBQurSFiZ5DeJhmYcFMwwGyaopFw6JtD5Bir8NNmXfOTJ7gdlg5W-52__dcft-tM11/p.jpeg',
--  GETUTCDATE(), 1, 1, 1
-- ),
-- ( -- values for the columns in the list above
--  'الزيارات الخارجية',
--  'Outer Visit',
--  'زيارة طلاب ابتدائية الصدارة إلي مشكاه',
--  'Assadarah Primary stage students visit to Mishkah',
--  'https://previews.dropbox.com/p/thumb/AAYE6RSrWVql4kJe6ZbQMAtQRZxU4KamNkVrn-PuuF12KnSl-5y_qPRA3Eh_nePZpwsH-qHwuf2yLWdBpI701eTuV5iJkVM_vbZp9ynt2Lm1T_MhrXEuscoP1yZTuuBqvnVskiXwdExB4LsgTNfswlaEa4BqnQyqFCNvAsxiCp-sqCTzhJR3Ms1x2E5ekbbGrpfoqw72FbHQP_sRSbCUTIAdzvkQvnK9kReR4EYV7bMH82zHQcE9o4zm7MDpjFOBT6tzT2muBWHRjJh8cPwSYZolONYKPA36XzbfyRPgk3uQ72trcvAyl67_f5DFHIgB8GHjxo7TRiN4ORSRMGKWHlpT/p.jpeg',
--  'https://previews.dropbox.com/p/thumb/AAYE6RSrWVql4kJe6ZbQMAtQRZxU4KamNkVrn-PuuF12KnSl-5y_qPRA3Eh_nePZpwsH-qHwuf2yLWdBpI701eTuV5iJkVM_vbZp9ynt2Lm1T_MhrXEuscoP1yZTuuBqvnVskiXwdExB4LsgTNfswlaEa4BqnQyqFCNvAsxiCp-sqCTzhJR3Ms1x2E5ekbbGrpfoqw72FbHQP_sRSbCUTIAdzvkQvnK9kReR4EYV7bMH82zHQcE9o4zm7MDpjFOBT6tzT2muBWHRjJh8cPwSYZolONYKPA36XzbfyRPgk3uQ72trcvAyl67_f5DFHIgB8GHjxo7TRiN4ORSRMGKWHlpT/p.jpeg',
--  GETUTCDATE(), 1, 1, 1
-- ),
-- ( -- values for the columns in the list above
--  'المسابقات المحلية',
--  'Local Competitions',
--  'مشاركة طلاب ثانوية الصدارة في ماراثون الرياضيات',
--  'Assadarah Secondary stage students participate in Math Marathon ',
--  'https://previews.dropbox.com/p/thumb/AAaxuQCFfZD2_9Ea_P7jldQ-4PhpRkcjyWhdG8Ucn1kHstdoXkDSxHc2hDNhHH6ssNgXbqAXF96V38GoCrTNBa4-eqc2JYFgneghvuvACs2SlJA_xuu3SfNjBugsSZEf3OSUOuCHBeIfgiouAXblbbqeaqXYhDZcEVKIRonbP6qRyzc_j3aYYKoCd9pF8IopUa5qujiQzSccDtrF9TnW8OX2uNsoqcXjVNx0e1Dg2nUEhZrYahgGYmoeQ4zdIGozqCJDfI8Wfw0WIGjDf5XDcG7HIPxLsYQ1ASuYcwlcMQ8KhfVnWYmntL6Jzg2eN2UmbtC33alobk8EehevyRZaEiym/p.jpeg',
--  'https://previews.dropbox.com/p/thumb/AAaxuQCFfZD2_9Ea_P7jldQ-4PhpRkcjyWhdG8Ucn1kHstdoXkDSxHc2hDNhHH6ssNgXbqAXF96V38GoCrTNBa4-eqc2JYFgneghvuvACs2SlJA_xuu3SfNjBugsSZEf3OSUOuCHBeIfgiouAXblbbqeaqXYhDZcEVKIRonbP6qRyzc_j3aYYKoCd9pF8IopUa5qujiQzSccDtrF9TnW8OX2uNsoqcXjVNx0e1Dg2nUEhZrYahgGYmoeQ4zdIGozqCJDfI8Wfw0WIGjDf5XDcG7HIPxLsYQ1ASuYcwlcMQ8KhfVnWYmntL6Jzg2eN2UmbtC33alobk8EehevyRZaEiym/p.jpeg',
--  GETUTCDATE(), 1, 1, 1
-- ),
-- ( -- values for the columns in the list above
--  'مصادر التعليم',
--  'Learning Resources',
--  'حث الطلاب على الاطلاع والقراءة واستخدام مصادر المعرفة',
--  'Urging student to look for knowledge through Reading and Other Information resources',
--  'https://previews.dropbox.com/p/thumb/AAb4IKmnaLPAwYHjGo8sgoFpuAclY_1BT-HAzuivKhR7Nezjc74WxRLIdQPBuxJ2y4lw4044fu_l558beC0b0DDxu83XHK3OS0cH1J4rCC8oyONKLUZIYKvUX7Sv8BX1scbJ6otU-nCdbC883gaBUdrO0wHIuRjXUIL_vFlIuJeCUfx-MzJJ_pcfkL45gRBi-vG7fS_SFxPKvETKIEtfPGVJDKj6aUEelKBxaGWsABjRRQEyuTFIIxd26Ilh8F3bYv2f7FwJAqshwqkjTiHv50AYjHYMKLc9m-uCjGjqyIyQcLaRzPEaM9Z-5YN5XxhDn8LXMZQkiMwjah3b_ciJPQ3j/p.jpeg',
--  'https://previews.dropbox.com/p/thumb/AAb4IKmnaLPAwYHjGo8sgoFpuAclY_1BT-HAzuivKhR7Nezjc74WxRLIdQPBuxJ2y4lw4044fu_l558beC0b0DDxu83XHK3OS0cH1J4rCC8oyONKLUZIYKvUX7Sv8BX1scbJ6otU-nCdbC883gaBUdrO0wHIuRjXUIL_vFlIuJeCUfx-MzJJ_pcfkL45gRBi-vG7fS_SFxPKvETKIEtfPGVJDKj6aUEelKBxaGWsABjRRQEyuTFIIxd26Ilh8F3bYv2f7FwJAqshwqkjTiHv50AYjHYMKLc9m-uCjGjqyIyQcLaRzPEaM9Z-5YN5XxhDn8LXMZQkiMwjah3b_ciJPQ3j/p.jpeg',
--  GETUTCDATE(), 1, 1, 1
-- ),
-- ( -- values for the columns in the list above
--  'الملاعب والصالات',
--  'Playgrounds, Gyms and activity rooms',
--  'ملاعب كرة القدم والسلة والطائرة وحمام السباحة وصالة اللياقة',
--  'Playgrounds for football, vollyball and basektball. Swimming pool and Gym',
--  'https://previews.dropbox.com/p/thumb/AAaCqqDD8Ro5zi3uJuDqNK9OHT9PUw343RPGwBkdWe4fRtgFNzuYYnMa7DQ0UiFLL3f0YGboi7NizVVFSPYhH0eJA4LB_O6puCtgTu33C2tImvgyzSjokGQxEGbeEY9nYdf_XmuuRbDyNyrS2IVZqUX6D-L8E2G9mCOPkPgYZLDyg6k50Vzu3Vkl-w5NhExyovvUbS7tlCVSagBtnqKh_pN-IPIejSpyvQ7NgkHFIp66zQMRsGaMphVYoIN4qr-htYlcrcJEtChk_1JDOf9vkWWF_lGwi6oD0qTMmWRy1eHXGrc4gIdGGG7Wr7b1-Xujml0CN8KVfqz_Aax_dSWTw8vr/p.jpeg',
--  'https://previews.dropbox.com/p/thumb/AAaCqqDD8Ro5zi3uJuDqNK9OHT9PUw343RPGwBkdWe4fRtgFNzuYYnMa7DQ0UiFLL3f0YGboi7NizVVFSPYhH0eJA4LB_O6puCtgTu33C2tImvgyzSjokGQxEGbeEY9nYdf_XmuuRbDyNyrS2IVZqUX6D-L8E2G9mCOPkPgYZLDyg6k50Vzu3Vkl-w5NhExyovvUbS7tlCVSagBtnqKh_pN-IPIejSpyvQ7NgkHFIp66zQMRsGaMphVYoIN4qr-htYlcrcJEtChk_1JDOf9vkWWF_lGwi6oD0qTMmWRy1eHXGrc4gIdGGG7Wr7b1-Xujml0CN8KVfqz_Aax_dSWTw8vr/p.jpeg',
--  GETUTCDATE(), 1, 1, 1
-- ),
-- ( -- values for the columns in the list above
--  'الإنجازات والجوائز',
--  'Trophies',
--  'يشارك طلابنا في العديد من المسابقات والمنافسات المحلية والدولية ويحصلون على العديد من المراكز المتقدمة والجوائز',
--  'Our students participate in national and international competitions and get a lot of prizes and advanced positions',
--  'https://previews.dropbox.com/p/thumb/AAaMIwLQRi9mhFUfedYjLcPQaxqUF6rZtfVbm62kubT81i2JigsyDC4QEUiVStZ1hZkesilZBsUFQ-6QEr_-22Q6LYnQAUc4KmSBu711lhjjcP_Ctmu914wH82UpPRFhHae51ggJEx8i6_fk3pQNb6U0G5Kg-Rg1Kv2VZsBn9kRAS2W899OmTIEJd1yozNVBJeqiTctgLLb8dKpWlh31fBVqMQp13XauJAoiM_IPHKhYfyNNFUSO9DMk0iUM2NE874P8KkAK9aCN1CoDvvV_kq_RPvRBRdG4fnphRwME2XpYRE6J2JZqONsd6pMTOh7QcHX7GUxYlHzBd1qfuTqa079b/p.jpeg',
--  'https://previews.dropbox.com/p/thumb/AAaMIwLQRi9mhFUfedYjLcPQaxqUF6rZtfVbm62kubT81i2JigsyDC4QEUiVStZ1hZkesilZBsUFQ-6QEr_-22Q6LYnQAUc4KmSBu711lhjjcP_Ctmu914wH82UpPRFhHae51ggJEx8i6_fk3pQNb6U0G5Kg-Rg1Kv2VZsBn9kRAS2W899OmTIEJd1yozNVBJeqiTctgLLb8dKpWlh31fBVqMQp13XauJAoiM_IPHKhYfyNNFUSO9DMk0iUM2NE874P8KkAK9aCN1CoDvvV_kq_RPvRBRdG4fnphRwME2XpYRE6J2JZqONsd6pMTOh7QcHX7GUxYlHzBd1qfuTqa079b/p.jpeg',
--  GETUTCDATE(), 1, 1, 1
-- )
-- GO

-- SELECT * from [dbo].[photos]

-- insert photos instructions
------------------------------
-- inset photo in table
-- generate photo name before save it in host: [albumId]_[photoId]_[photo|thumb]
-- save it to host
-- update the photoURL & thumbURL

-- add 2 relations [employeesJobs - albums]
----------------------------------------------------------------------------

-- ALTER TABLE [dbo].[photos] DROP CONSTRAINT [FK_employeesJobs_photos]
-- ALTER TABLE [dbo].[photos]
-- ADD CONSTRAINT [FK_employeesJobs_photos] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE CASCADE
-- ON DELETE SET NULL
-- GO

-- ALTER TABLE [dbo].[photos] DROP CONSTRAINT [FK_albums_photos]
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
-- sp_fkeys 'employeesJobs'
