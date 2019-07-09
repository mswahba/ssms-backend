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
-- 	[articleTitleAr] [nvarchar](100) NOT NULL,
-- 	[articleTitleEn] [nvarchar](100) NOT NULL,
-- 	[articleTextAr] [nvarchar](max) NOT NULL,
-- 	[articleTextEn] [nvarchar](max) NOT NULL,
--  [authorNameAr] [nvarchar](100) NULL,
--  [authorNameEn] [nvarchar](100) NULL,
-- 	[articleDate] [smalldatetime] NOT NULL,
-- 	[mainPhotoURL] [varchar](max) NULL,
-- 	[photosURLs] [varchar](max) NULL,
-- 	[videosURLs] [varchar](max) NULL,
--  [displayAlsoAt] [varchar](10) NOT NULL,
--  [forCompany] [bit] NOT NULL,
--  [schoolId] [tinyint] NULL,
-- 	[stageId] [tinyint] NULL,
--  [empJobId] [int] NULL,
-- 	[categoryIds] [varchar](max) NULL,
--  [approved] [bit] NOT NULL,
--  [enabled] [bit] NOT NULL,
--  [keywords] [nvarchar](max) NULL,
-- )
-- GO

-- Insert rows into table '[dbo].[articles]'
INSERT INTO [dbo].[articles]
( -- columns to insert data into
  [articleTitleAr],
  [articleTitleEn],
  [articleTextAr],
  [articleTextEn],
  [authorNameAr],
  [authorNameEn],
  [mainPhotoURL],
  [articleDate],
  [displayAlsoAt],
  [forCompany],
  [schoolId],
  [stageId],
  [categoryIds],
  [approved],
  [enabled],
  [keywords]
)
VALUES
( -- first row: values for the columns in the list above
  'حفل تخرج طلاب مدارس الصدارة الأهليه',
  'Graduation Ceremony for students of Assadara schools',
  'حفل تخرج وتكريم طلاب الصف الثالث الثانوي بمدارس الصدارة الأهليه وكان حفل مميز بحضور مالك المدارس الأستاذ/خالد الرسيني وقائدها /الإستاذ مساعد الفهد وجميع منسوبيها واولياء الامور وجميع الخريجين الف مبروك للجميع.
تضمن الحفل العديد من الفقرات التي شارك بها الطلاب الخريجين بالإضافة إلى كلمة قائد المدرسة والتي رحب فيها بالسادة الضيوف وأولياء أمور الطلاب كما قام بتكريم الطلاب وتوزيع الجوائز والدروع عليهم. تضمن الحفل فقرات باللغتين العربية والإنجليزية بالإضافة إلى مسيرة الطلاب الخريجين ثم انتهى بالعشاء الذي شارك فيها طلاب المدارس وأولياء الأمور ومنسوبي المدارس.
',
  'A ceremony was held in the presence of the owner of the schools, Mr. Khalid Al-Risini, and its leader / Mr. Al-Fahad, all its employees, parents and all graduates. Congratulations to all.The ceremony included several sections in which the graduate students participated in addition to the speech of the school leader, in which he welcomed the guests and parents of the students. He also honored the students and distributed prizes and shields to them. The ceremony included sections in Arabic and English in addition to the march of graduate students and ended with a dinner attended by school students, parents and school staff.',
  'أحمد وهبة',
  'Ahmed Wahba',
  'https://previews.dropbox.com/p/thumb/AAY8d1Wp3yFGvsljOWZTXoxG8G9tTGcqRVDTLhiOrIvgKabxhBBXqMbiPOmaRbifjIpqt8WzueGnThvJJSKSd6wS34wMn1hV6DLGX60MknIzuz-qyy9I9R9FEDZm3EVGHud85bEQdxaL-FIkUvO_kTmNCWrMVeRcrIbKC5fQM0EhdkouK-LkeFRY2QpYpeuuaZIYO3BG_nX3cPGRaQ20wYpnVBQpdf_b2MUoxC7fpCRgTHa6xXH4tq1iLN_VHMXXYMmTh5OAXiRUjj2-6uGuG6vBQurSFiZ5DeJhmYcFMwwGyaopFw6JtD5Bir8NNmXfOTJ7gdlg5W-52__dcft-tM11/p.jpeg',
  GETUTCDATE(),
  'both',
  0,
  1,
  1,
  '1',
  1,
  1,
  'assadara schools graduation'
)
INSERT INTO [dbo].[articles]
( -- columns to insert data into
  [articleTitleAr],
  [articleTitleEn],
  [articleTextAr],
  [articleTextEn],
  [authorNameAr],
  [authorNameEn],
  [mainPhotoURL],
  [articleDate],
  [displayAlsoAt],
  [forCompany],
  [schoolId],
  [stageId],
  [categoryIds],
  [approved],
  [enabled],
  [keywords]
)
VALUES
( -- first row: values for the columns in the list above
  'تمثيل مدارس الصدارة الاهليه في مسابقة فيرست ليقو لي',
  'Representing the premier private schools in the First Lego Le Competition',
  'شارك طلاب مدارس الصدارة الاهليه في مسابقة (Fll) فرست ليقو لي وحصلوا على المركز الثالث في التقييم على مستوى مدارس الرياض ولله الحمد. كانت المسابقه جميله حصد فيها طلابنا العلم والمعرفه وكأس المركز الثالث والعديد من الميداليات.
أشرف على تدريب وإعداد الطلاب للمسابقة معلموا الحاسب الآلي والروبوت حيث كان الطلاب يشاركون في ورشة عمل لمدة شهر تدربوا فيه على تنفيذ العديد من العمليات المتقدمة في التعامع مع الروبوت. ',
  'The students of the private schools participated in the Fll competition, and they won the third place in the assessment at the level of the schools of Riyadh and all praise. It was a beautiful race where our students won the science and knowledge, the third place trophy and many medals.
The training and preparation of students for the competition was supervised by computer and robot teachers where students participated in a one-month workshop where they practiced many advanced robotics operations.',
  'أحمد وهبة',
  'Ahmed Wahba',
  'https://previews.dropbox.com/p/thumb/AAY8d1Wp3yFGvsljOWZTXoxG8G9tTGcqRVDTLhiOrIvgKabxhBBXqMbiPOmaRbifjIpqt8WzueGnThvJJSKSd6wS34wMn1hV6DLGX60MknIzuz-qyy9I9R9FEDZm3EVGHud85bEQdxaL-FIkUvO_kTmNCWrMVeRcrIbKC5fQM0EhdkouK-LkeFRY2QpYpeuuaZIYO3BG_nX3cPGRaQ20wYpnVBQpdf_b2MUoxC7fpCRgTHa6xXH4tq1iLN_VHMXXYMmTh5OAXiRUjj2-6uGuG6vBQurSFiZ5DeJhmYcFMwwGyaopFw6JtD5Bir8NNmXfOTJ7gdlg5W-52__dcft-tM11/p.jpeg',
  GETUTCDATE(),
  'none',
  0,
  1,
  2,
  '1',
  1,
  1,
  'assadara schools graduation'
),
( -- first row: values for the columns in the list above
  'احتفال اليوم الوطني',
  'National Day Celebration',
  'احتفلت مدارس الصدارة الأهلية باليوم الوطني الـ88 للملكة العربية السعودية بحضور قادة الأقسام والمعلمين والإداريين وذلك يوم الثلاثاء الموافق : 1440/1/8 هـ حيث تزنينت المدرسة بالأعلام الخضراء والشعارات والكلمات الوطنية بمشاركة الطلاب والمعلمين
وتنوعت احتفالات المدرسة بالفقرات الوطنية والبرامج المتنوعة ، التى من شأنها أن تساهم في تعزيز الوطنية لدى طلاب المدارس وتعريفهم بقيمة الولاء للوطن وبأهمية التعليم ودوره الكبير في نهضة الوطن وتقدمه',
  'Al-Sidra National Schools celebrated the 88th National Day of the Kingdom of Saudi Arabia in the presence of the heads of departments, teachers and administrators on Tuesday 1440/1/8 H. The school was decorated with green flags, slogans and national words with the participation of students and teachers.
The school celebrations varied with national chapters and various programs, which would contribute to enhancing patriotism among school students and introducing them to the value of loyalty to the nation and the importance of education and its great role in the renaissance and progress of the country.',
  'أحمد وهبة',
  'Ahmed Wahba',
  'https://previews.dropbox.com/p/thumb/AAY8d1Wp3yFGvsljOWZTXoxG8G9tTGcqRVDTLhiOrIvgKabxhBBXqMbiPOmaRbifjIpqt8WzueGnThvJJSKSd6wS34wMn1hV6DLGX60MknIzuz-qyy9I9R9FEDZm3EVGHud85bEQdxaL-FIkUvO_kTmNCWrMVeRcrIbKC5fQM0EhdkouK-LkeFRY2QpYpeuuaZIYO3BG_nX3cPGRaQ20wYpnVBQpdf_b2MUoxC7fpCRgTHa6xXH4tq1iLN_VHMXXYMmTh5OAXiRUjj2-6uGuG6vBQurSFiZ5DeJhmYcFMwwGyaopFw6JtD5Bir8NNmXfOTJ7gdlg5W-52__dcft-tM11/p.jpeg',
  GETUTCDATE(),
  'both',
  1,
  null,
  null,
  '1',
  1,
  1,
  'assadara schools graduation'
),
( -- first row: values for the columns in the list above
  'نادي الروبوت',
  'The Robot Club',
  'تأسس نادي الروبوت التابع لمدارس الصدارة في الفصل الأول من العام 1434/ 1435 هـ وقد شارك النادي في بطولات الروبوت على مستوى الرياض وعلى مستوى المملكة وحقق بفضل الله العديد من الإنجازات منها :
- الحصول على المركز الأول في مسابقة Robocop على مستوى الرياض 1436/ 1437 هـ
- الحصول على المركز الثاني في مسابقة VEXعلى مستوى الرياض 2014م وتأهله للتصفيات النهائية على مستوى المملكة وحصوله على المركز الثالث .
- الجدير بالذكر أن المدارس تقدم حصة إثرائية أسبوعية في الروبوت لطلاب المرحلة الابتدائية والمتوسطة يتعلم من خلالها الطالب أساسيات',
  'The robot club of the top schools was founded in the first quarter of the year 1434/1435 H. The club has participated in the robotics championships in Riyadh and Kingdom level.
- Obtained the first place in the competition Robocop at the level of Riyadh 1436/1437 e
- Get the second place in the competition VEX at the level of Riyadh 2014 and qualify for the finalists in the Kingdom and get the third place.
- It is worth noting that the schools offer a weekly enrichment lesson in robot for primary and middle school students through which the student learns the basics',
  'أحمد وهبة',
  'Ahmed Wahba',
  'https://previews.dropbox.com/p/thumb/AAY8d1Wp3yFGvsljOWZTXoxG8G9tTGcqRVDTLhiOrIvgKabxhBBXqMbiPOmaRbifjIpqt8WzueGnThvJJSKSd6wS34wMn1hV6DLGX60MknIzuz-qyy9I9R9FEDZm3EVGHud85bEQdxaL-FIkUvO_kTmNCWrMVeRcrIbKC5fQM0EhdkouK-LkeFRY2QpYpeuuaZIYO3BG_nX3cPGRaQ20wYpnVBQpdf_b2MUoxC7fpCRgTHa6xXH4tq1iLN_VHMXXYMmTh5OAXiRUjj2-6uGuG6vBQurSFiZ5DeJhmYcFMwwGyaopFw6JtD5Bir8NNmXfOTJ7gdlg5W-52__dcft-tM11/p.jpeg',
  GETUTCDATE(),
  'both',
  0,
  1,
  3,
  '1',
  1,
  1,
  'assadara schools graduation'
),
( -- first row: values for the columns in the list above
  'مدارس الصدارة و الـآيلتس العالمي لتعليم اللغة الإنجليزية و اختباراتها',
  'IELTS International Language Schools and their tests',
  'نظام تقييم اللغة الإنجليزية الدولي الـ "IELTS" هو امتحان اللغة الإنجليزية الأكثر شهرة على مستوى العالم، حيث يقدم أكثر من مليوني شخص حول العالم الامتحان كل عام.

الأنشطة :
تدريب الطلاب على المحادثة بأعلى مستوى مع الناطقين بها
تهيئة الطالب وتدريبه لاجتياز الاختبار العالمي الـ "IELTS .
إعداد الطالب لمتطلبات سوق العمل مستقبلا .
إعداد الطالب دراسيا لاجتياز اختباراته بسهولة
مناهج إضافية عن الاختبارات الدولية الـ "IELTS

المميزات
قاعات تدريب بأعلى المستويات العالمية في التعليم
محاضرون متخصصون في تعليم اللغة الإنجليزية بمعايير عالمية
إقامة ورش عمل وزيارات خارجية للمتميزين داخل وخارج المملكة
 برمجة الروبوت بالاستعانة بمجموعة من الروبوتات التعليمية التي توفرها المدارس لطلبة النادي',
  'IELTS is the world most widely recognized English exam, with more than 2 million people taking the exam each year.

Activities:
Train students to converse at the highest level with their native speakers
Train and train the student to pass the IELTS Global Test.
Preparing the student for the requirements of the labor market in the future.
Prepare the student to pass the tests easily
Additional approaches to IELTS international tests

Advantages
World-class training halls in education
Specialists in teaching English language with international standards
Organizing workshops and external visits for distinguished individuals inside and outside the Kingdom
 Programming robots using a set of educational robots provided by schools to club students',
  'أحمد وهبة',
  'Ahmed Wahba',
  'https://previews.dropbox.com/p/thumb/AAY8d1Wp3yFGvsljOWZTXoxG8G9tTGcqRVDTLhiOrIvgKabxhBBXqMbiPOmaRbifjIpqt8WzueGnThvJJSKSd6wS34wMn1hV6DLGX60MknIzuz-qyy9I9R9FEDZm3EVGHud85bEQdxaL-FIkUvO_kTmNCWrMVeRcrIbKC5fQM0EhdkouK-LkeFRY2QpYpeuuaZIYO3BG_nX3cPGRaQ20wYpnVBQpdf_b2MUoxC7fpCRgTHa6xXH4tq1iLN_VHMXXYMmTh5OAXiRUjj2-6uGuG6vBQurSFiZ5DeJhmYcFMwwGyaopFw6JtD5Bir8NNmXfOTJ7gdlg5W-52__dcft-tM11/p.jpeg',
  GETUTCDATE(),
  'both',
  0,
  1,
  4,
  '1',
  1,
  1,
  'assadara schools graduation'
)
-- add more rows here
GO

-- ALTER TABLE [dbo].[articles] DROP COLUMN [articleTitle]
-- ALTER TABLE [dbo].[articles] ADD [articleTitleAr] [nvarchar](100) NOT NULL
-- ALTER TABLE [dbo].[articles] ADD [articleTitleEn] [nvarchar](100) NOT NULL

-- ALTER TABLE [dbo].[articles] DROP COLUMN [articleText]
-- ALTER TABLE [dbo].[articles] ADD [articleTextAr] [nvarchar](max) NOT NULL
-- ALTER TABLE [dbo].[articles] ADD [articleTextEn] [nvarchar](max) NOT NULL

-- ALTER TABLE [dbo].[articles] DROP COLUMN [authorName]
-- ALTER TABLE [dbo].[articles] ADD [authorNameAr] [nvarchar](100) NOT NULL
-- ALTER TABLE [dbo].[articles] ADD [authorNameEn] [nvarchar](100) NOT NULL

-- SELECT * FROM [dbo].[articles]

-- fields meaning
-- =================
-- [schoolId], [stageId], [forCompany] reflects artical dependency
-- [displayAlsoAt] reflects other contexts to be displayed at in addition to its original context

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


-- SELECT * FROM [dbo].[branches]
-- SELECT * FROM [dbo].[stages]
-- GO
-- SELECT * FROM [dbo].[schools]
-- GO

-- CREATE TABLE [dbo].[stages] (
-- 	[stageId] [tinyint] PRIMARY KEY,
-- 	[stageNameAr] [nvarchar](25) NOT NULL,
--   [stageNameEn] [nvarchar](25) NOT NULL,
--   [branchId] [tinyint] NULL,
--   [isDeleted] [bit] NOT NULL DEFAULT(0)
-- )
-- GO
-- ALTER TABLE [dbo].[stages]
-- ADD CONSTRAINT [FK_stages_branches] FOREIGN KEY([branchId])
-- REFERENCES [dbo].[branches] ([branchId])
-- ON UPDATE NO ACTION
-- ON DELETE NO ACTION
-- GO

-- ALTER TABLE [dbo].[stages] DROP CONSTRAINT [FK_stages_branches]
-- DROP TABLE [dbo].[stages]

-- Insert rows into table '[dbo].[stages]'
-- insert into [dbo].[stages] values (1, 'ابتدائي', 'Primary', 1, 0)
-- insert into [dbo].[stages] values (2, 'متوسط', 'Intermediate', 1, 0)
-- insert into [dbo].[stages] values (3, 'ثانوي', 'Secondary', 1, 0)

-- insert into [dbo].[stages] values (4, 'رياض أطفال', 'Kindergarten', 2, 0)
-- insert into [dbo].[stages] values (5, 'ابتدائي', 'Primary', 2, 0)
-- insert into [dbo].[stages] values (6, 'متوسط', 'Intermediate', 2, 0)
-- insert into [dbo].[stages] values (7, 'ثانوي', 'Secondary', 2, 0)

-- Select rows from a Table or View 'TableOrViewName' in schema 'SchemaName'
-- insert into departments
-- ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted], [issuerId], [isStage], [branchId])
-- values (1, 'ابتدائي', 'Primary', 0, '1122112211', 1, 1)
-- insert into departments
-- ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted], [issuerId], [isStage], [branchId])
-- values (2, 'متوسط', 'Intermediate', 0, '1122112211', 1, 1)
-- insert into departments
-- ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted], [issuerId], [isStage], [branchId])
-- values (3, 'ثانوي', 'Secondary', 0, '1122112211', 1, 1)

-- insert into departments
-- ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted], [issuerId], [isStage], [branchId])
-- values
-- (4, 'رياض أطفال', 'Kindergarten', 0, '1122112211', 1, 2),
-- (5, 'ابتدائي', 'Primary', 0, '1122112211', 1, 2),
-- (6, 'متوسط', 'Intermediate', 0, '1122112211', 1, 2),
-- (7, 'ثانوي', 'Secondary', 0, '1122112211', 1, 2)

-- Select rows from a Table or View 'departments' in schema 'SchemaName'
-- SELECT * FROM [dbo].[articles]
-- GO