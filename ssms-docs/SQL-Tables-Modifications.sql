-- add new table relations
-- CREATE TABLE [dbo].[relations](
-- 	[relationId] [tinyint] PRIMARY KEY,
-- 	[relationNameAr] [nvarchar](30) NOT NULL,
-- 	[relationNameEn] [nvarchar](30) NOT NULL
-- )
-- GO
-- add new table studentStatuses
-- Create table [dbo].[studentStatuses] (
-- 	[statusId] [tinyint] PRIMARY KEY,
-- 	[statusNameAr] [nvarchar](20) NOT NULL,
-- 	[statusNameEn] [nvarchar](20) NOT NULL,
-- 	notes [nvarchar](max)
-- )
-- Go
-- insert into studentStatuses values (1, 'تسجيل جديد', 'New', 'تم التسجيل من قبل ولي الأمر')
-- insert into studentStatuses values (2, 'قبول مبدئي', 'Initial Acceptance', 'تم التسجيل من قبل إدارة القسم')
-- insert into studentStatuses values (3, 'منتظم', 'Attending', 'الطالب يداوم على الدراسة بانتظام')
-- insert into studentStatuses values (4, 'منقطع', 'Discontinued', 'الطالب منقطع عن الدراسة')
-- insert into studentStatuses values (5, 'منسحب', 'Transported', 'تم سحب ملف الطالب من المدرسة')
-- insert into studentStatuses values (6, 'متخرج', 'Graduated', 'أنهى الطالب سنوات الدراسة بالقسم')
-- Go

-- modify parents table:
-- sp_rename to rename table from [parents] to [guardians]
-- add these fields
-------------------
-- jobEmployer
-- jobTitle
-- jobPhone
-- jobAddress
-- notes

-- remove these fields
----------------------
-- relativeName
-- relativeMobile
-- relativePhone
-- relativeAddress
-- relativeRelation

-- alter table parents drop column [job]
-- alter table parents drop column [workAddress]
-- alter table parents drop column [workPhone]
-- alter table parents drop column [relativeName]
-- alter table parents drop column [relativeMobile]
-- alter table parents drop column [relativePhone]
-- alter table parents drop column [relativeAddress]
-- alter table parents drop column [relativeRelation]

-- alter table parents add [jobEmployer] [nvarchar](100) NULL
-- alter table parents add [jobTitle] [nvarchar](50) NULL
-- alter table parents add [jobPhone] [varchar](20) NULL
-- alter table parents add [jobAddress] [nvarchar](max) NULL
-- alter table parents add [notes] [nvarchar](max) NULL

-- modify students table:
-- add column mobileMother2
-- add column healthIssuesIds
-- add column healthNeedsIds
-- add column addressId
-- add column statusId

-- alter table students add [healthIssuesIds] [varchar](max) NULL
-- alter table students add [healthNeedsIds] [varchar](max) NULL
-- alter table students add [mobileMother2] [varchar](20) NULL
-- alter table students add [addressId] [int] NULL
-- alter table students add [statusId] [tinyint] NULL

-- add the 2 relations [addressId - statusId]
-- --------------------
-- ALTER TABLE [dbo].[students]
-- ADD CONSTRAINT [FK_parentsAddresses_students] FOREIGN KEY([addressId])
-- REFERENCES [dbo].[parentsAddresses] ([addressId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[students]
-- ADD CONSTRAINT [FK_studentStatuses_students] FOREIGN KEY([statusId])
-- REFERENCES [dbo].[studentStatuses] ([statusId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- add new table relatives
-- CREATE TABLE [dbo].[relatives](
-- 	[relativeId] [int] identity(1,1) PRIMARY KEY,
-- 	[relativeName] [nvarchar](50) NOT NULL,
-- 	[mobile1] [nvarchar](15) NOT NULL,
-- 	[mobile2] [nvarchar](15) NULL,
-- 	[phone] [nvarchar](10) NULL,
-- 	[address] [nvarchar](max) NULL,
-- 	[parentId] [char](10) NOT NULL,
-- 	[createdAt] [smalldatetime] NULL
-- )
-- GO
-- ALTER TABLE [dbo].[relatives] Alter column [parentId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
-- ALTER TABLE [dbo].[relatives]
-- ADD CONSTRAINT [FK_parents_relatives] FOREIGN KEY([parentId])
-- REFERENCES [dbo].[parents] ([parentId])
-- ON UPDATE No Action
-- ON DELETE No Action

-- add new table studentsRelatives
-- CREATE TABLE [dbo].[studentsRelatives](
-- 	[studentRelativeId] [int] identity(1,1) PRIMARY KEY,
-- 	[studentId] [char](10) NOT NULL,
-- 	[relativeId] [int] NOT NULL,
-- 	[relationId] [tinyint] NOT NULL,
-- 	[priority] [tinyint] NULL,
--  [sysStartTime] datetime2 (2) GENERATED ALWAYS AS ROW START,
--  [sysEndTime] datetime2 (2) GENERATED ALWAYS AS ROW END,
--  PERIOD FOR SYSTEM_TIME (sysStartTime, sysEndTime)
--  ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.studentsRelativesHistory));
-- GO
-- add relations and issuerId column
-- Alter table [dbo].[studentsRelatives] drop column [createdAt]
-- ALTER TABLE [dbo].[studentsRelatives] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS

-- ALTER TABLE [dbo].[studentsRelatives]
-- ADD CONSTRAINT [FK_users_studentsRelatives] FOREIGN KEY([issuerId])
-- REFERENCES [dbo].[users] ([userId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsRelatives]
-- ADD CONSTRAINT [FK_students_studentsRelatives] FOREIGN KEY([studentId])
-- REFERENCES [dbo].[students] ([studentId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsRelatives]
-- ADD CONSTRAINT [FK_relatives_studentsRelatives] FOREIGN KEY([relativeId])
-- REFERENCES [dbo].[relatives] ([relativeId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsRelatives]
-- ADD CONSTRAINT [FK_relations_studentsRelatives] FOREIGN KEY([relationId])
-- REFERENCES [dbo].[relations] ([relationId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- add new table HealthIssues
-- CREATE TABLE [dbo].[healthIssues](
-- 	[healthIssueId] [nvarchar](10) NULL,
-- 	[healthIssueNameAr] [nvarchar](100) NULL,
-- 	[healthIssueNameEn] [nvarchar](100) NULL
-- )
-- GO

-- alter table HealthIssues alter column [healthIssueId] [smallint] NULL
-- alter table HealthNeeds alter column [healthNeedId] [smallint] NULL

-- add new table HealthNeeds
-- CREATE TABLE [dbo].[healthNeeds](
-- 	[healthNeedId] [nvarchar](10) NULL,
-- 	[healthNeedNameAr] [nvarchar](100) NULL,
-- 	[healthNeedNameEn] [nvarchar](100) NULL
-- )
-- GO
-- add new table cities
-- create table [dbo].[cities] (
-- 	cityId [smallint] PRIMARY KEY,
-- 	cityNameAr nvarchar(100) NOT NULL,
-- 	cityNameEn nvarchar(100) NOT NULL,
-- )
-- GO
-- add new table districts
-- create table [dbo].[districts] (
-- 	districtId [smallint] PRIMARY KEY,
-- 	districtNameAr nvarchar(100) NOT NULL,
-- 	districtNameEn nvarchar(100) NOT NULL,
-- 	cityId [smallint] NULL
-- )
-- GO
-- add new table parentsAddresses
-- CREATE TABLE [dbo].[parentsAddresses](
-- 	[addressId] [int] identity(1,1) PRIMARY KEY,
-- 	[parentId] [char](10) NULL,
-- 	[cityId] [smallint] NULL,
-- 	[districtId] [smallint] NULL,
-- 	[streetName] [nvarchar](max) NULL,
-- 	[houseNumber] [smallint] NULL,
-- 	[extraDetails] [nvarchar](max) NULL,
-- 	[coords] [varchar](50) NULL,
-- 	[phone] [nvarchar](20) NULL,
-- 	[isMain] bit null,
--  	[sysStartTime] datetime2 (2) GENERATED ALWAYS AS ROW START,
--  	[sysEndTime] datetime2 (2) GENERATED ALWAYS AS ROW END,
--  	PERIOD FOR SYSTEM_TIME (sysStartTime, sysEndTime)
--  ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.parentsAddressesHistory));
--  GO

-- ALTER TABLE [dbo].[parentsAddresses] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
-- ALTER TABLE [dbo].[parentsAddresses] DROP COLUMN [parentId]
-- ALTER TABLE [dbo].[parentsAddresses] ADD [parentId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS

-- add the relations
--------------------
-- ALTER TABLE [dbo].[parentsAddresses]
-- ADD CONSTRAINT [FK_users_parentsAddresses] FOREIGN KEY([issuerId])
-- REFERENCES [dbo].[users] ([userId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[parentsAddresses]
-- ADD CONSTRAINT [FK_parents_parentsAddresses] FOREIGN KEY([parentId])
-- REFERENCES [dbo].[parents] ([parentId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[parentsAddresses]
-- ADD CONSTRAINT [FK_cities_parentsAddresses] FOREIGN KEY([cityId])
-- REFERENCES [dbo].[cities] ([cityId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[parentsAddresses]
-- ADD CONSTRAINT [FK_districts_parentsAddresses] FOREIGN KEY([districtId])
-- REFERENCES [dbo].[districts] ([districtId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- add 2 new lookup tables:  violationsDegrees - violationsTypes
-------------------------------------
-- CREATE TABLE [dbo].[violationsDegrees](
-- 	[degreeId] [tinyint] PRIMARY KEY,
-- 	[degreeNameAr] [nvarchar](50) NOT NULL,
-- 	[degreeNameEn] [nvarchar](50) NOT NULL
-- )
-- GO
--------------------------------------
-- insert into violationsDegrees values (1, 'الدرجة الأولى')
-- insert into violationsDegrees values (2, 'الدرجة الثانية')
-- insert into violationsDegrees values (3, 'الدرجة الثالثة')
-- insert into violationsDegrees values (4, 'الدرجة الرابعة')
-- insert into violationsDegrees values (5, 'الدرجة الخامسة')
-- insert into violationsDegrees values (6, 'الدرجة السادسة')
-- insert into violationsDegrees values (7, 'الدرجة السابعة')
-- GO
-------------------------------------------
-- select * from violationsTypes
-- create table [dbo].[violationsTypes] (
-- 	typeId [tinyint] PRIMARY KEY,
-- 	typeNameAr nvarchar(50) NOT NULL,
-- 	typeNameEn nvarchar(50) NOT NULL
-- )
-- GO
-------------------------------
-- insert into violationsTypes values (1, 'مخالفة سلوكية')
-- insert into violationsTypes values (2, 'مخالفة تعليمية')
-- insert into violationsTypes values (3, 'مخالفة نظامية')
-- GO
-------------------------------
-- modify behavioralViolations table and rename it to violations
-- add column degreeId
-- add column typeId
-- remove column categoryId
-- add relationship with 2 lookup table

-- sp_rename 'dbo.behavioralViolations', 'violations';
-- ALTER TABLE [dbo].[violations] ADD [typeId] tinyint null
-- ALTER TABLE [dbo].[violations] ADD [degreeId] tinyint null
-- ALTER TABLE [dbo].[violations] DROP COLUMN categoryId

-- ALTER TABLE [dbo].[violations]
-- ADD CONSTRAINT [FK_violationsTypes_violations] FOREIGN KEY([typeId])
-- REFERENCES [dbo].[violationsTypes] ([typeId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[violations]
-- ADD CONSTRAINT [FK_violationsDegrees_violations] FOREIGN KEY([degreeId])
-- REFERENCES [dbo].[violationsDegrees] ([degreeId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- modify table classesStudents
-- rename table classesStudents to studentsClasses OR studentsEdu
-- remove startDate - endDate
-- make it historical table

-- sp_rename 'dbo.classesStudents', 'studentsClasses';
-- sp_rename 'dbo.studentsClasses.classStudentId', 'studentClassId';
-- ALTER TABLE [dbo].[studentsClasses] DROP COLUMN startDate
-- ALTER TABLE [dbo].[studentsClasses] DROP COLUMN endDate

-- ALTER TABLE [dbo].[studentsClasses] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
-- GO
-- ALTER TABLE [dbo].[studentsClasses]
-- ADD CONSTRAINT [FK_users_studentsClasses] FOREIGN KEY([issuerId])
-- REFERENCES [dbo].[users] ([userId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsClasses] DROP CONSTRAINT [FK_classesStudents_academicYears]
-- GO
-- ALTER TABLE [dbo].[studentsClasses]
-- ADD CONSTRAINT [FK_academicYears_studentsClasses] FOREIGN KEY([yearId])
-- REFERENCES [dbo].[academicYears] ([yearId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsClasses] DROP CONSTRAINT [FK_classesStudents_classrooms]
-- GO
-- ALTER TABLE [dbo].[studentsClasses]
-- ADD CONSTRAINT [FK_classrooms_studentsClasses] FOREIGN KEY([classroomId])
-- REFERENCES [dbo].[classrooms] ([classroomId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsClasses] DROP CONSTRAINT [FK_classesStudents_students]
-- GO
-- ALTER TABLE [dbo].[studentsClasses]
-- ADD CONSTRAINT [FK_students_studentsClasses] FOREIGN KEY([studentId])
-- REFERENCES [dbo].[students] ([studentId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsClasses]
-- ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
--     sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
--     PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
-- GO
-- ALTER TABLE [dbo].[studentsClasses]
-- SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[studentsClassesHistory]))
-- GO

-- add new table studentsViolations
-- CREATE TABLE [dbo].[studentsViolations](
-- 	[studentViolationId] [int] PRIMARY KEY,
-- 	[violationId] [smallint] NULL,
-- 	[studentId] [char](10) NULL,
-- 	[studentClassId] [int] NULL,
-- 	[empJobId] [int] NULL,
-- 	[violationDate] [date] NULL,
--  	[sysStartTime] datetime2 (2) GENERATED ALWAYS AS ROW START,
--  	[sysEndTime] datetime2 (2) GENERATED ALWAYS AS ROW END,
--  	PERIOD FOR SYSTEM_TIME (sysStartTime, sysEndTime)
--  ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.studentsViolationsHistory));
-- GO
-- add issuerId
-- ALTER TABLE [dbo].[studentsViolations] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS

-- add relation with all 5 tables
---------------------------------
-- users
-- students
-- violations
-- studentsClasses
-- employeesJobs

-- ALTER TABLE [dbo].[studentsViolations]
-- ADD CONSTRAINT [FK_users_studentsViolations] FOREIGN KEY([issuerId])
-- REFERENCES [dbo].[users] ([userId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsViolations]
-- ADD CONSTRAINT [FK_students_studentsViolations] FOREIGN KEY([studentId])
-- REFERENCES [dbo].[students] ([studentId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsViolations]
-- ADD CONSTRAINT [FK_violations_studentsViolations] FOREIGN KEY([violationId])
-- REFERENCES [dbo].[violations] ([violationId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsViolations]
-- ADD CONSTRAINT [FK_studentsClasses_studentsViolations] FOREIGN KEY([studentClassId])
-- REFERENCES [dbo].[studentsClasses] ([studentClassId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsViolations]
-- ADD CONSTRAINT [FK_employeesJobs_studentsViolations] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- modify table remedialProcedures and rename it to procedures
-- remove categoryId column
-- add column atViolationDegreeId [tinyint] NOT NULL
-- add column atRepetiton [tinyint] NOT NULL
-- add column notesAr [nvarchar](max) NULL
-- add column notesEn [nvarchar](max) NULL
-- add the relation between violationsDegrees and procedures

-- sp_rename 'dbo.remedialProcedures', 'procedures';
-- -- alter table [dbo].[procedures] drop column categoryId
-- alter table [dbo].[procedures] add atViolationDegreeId [tinyint] null
-- alter table [dbo].[procedures] add atRepetiton [tinyint] not null
-- alter table [dbo].[procedures] add notesAr [nvarchar](max) null
-- alter table [dbo].[procedures] add notesEn [nvarchar](max) null

-- ALTER TABLE [dbo].[procedures]
-- ADD CONSTRAINT [FK_violationsDegrees_procedures] FOREIGN KEY([atViolationDegreeId])
-- REFERENCES [dbo].[violationsDegrees] ([degreeId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- data sample
-- insert into procedures values (1, 'تنبيه شفوي انفرادي للمرة الأولى', 'نظراً لارتكابك مخالفة من مخالفات الدرجة الأولى فإننا ننبهك تنبيهاً شفوياً للمرة الأولى', 1, 1)
-- insert into procedures values (2, 'تنبيه شفوي انفرادي للمرة الثانية', 'نظراً لارتكابك مخالفة من مخالفات الدرجة الأولى فإننا ننبهك تنبيهاً شفوياً للمرة الثانية.',1, 2)
-- insert into procedures values (3, 'تدوين المخالفة وتوقيع الطالب','نظراً لارتكابك لمخالفة من الدرجة الأولى وجب توقيعك على إثبات المخالفة.', 1, 3)
-- insert into procedures values (4, 'إشعار ولي الأمر','تسليم الطالب إشعار لولي الأمر بمخالفته ومحادثة ولي الأمر هاتفياً والتنسيق معه لتعديل السلوك. )توقيع من قام بالاتصال(', 1, 4)
-- insert into procedures values (5, 'الإحالة للمرشد','نظر اً لمخالفتك فقد حولت إلى المرشد الطلابي لدراسة حالتك.', 1, 4)

-- insert into procedures values (6, 'أخذ تعهد خطي على الطالب','أتعهد بالانضباط السلوكي وعدم تكرار المخالفة', 1, 5)
-- insert into procedures values (7, 'استدعاء ولي الأمر','تسليم الطالب خطاب استدعاء لولي أمره وإخطاره بمخالفة الطالب', 1, 5)
-- insert into procedures values (8, 'حسم درجة واحدة من السلوك','نظراً لاستنفاذ جميع الإجراءات وجب حسم درجة واحدة من درجات السلوك حسب ما نصت علية القواعد.', 1, 5)
-- insert into procedures values (9, 'إشعار ولي الأمر بالحسم','تسليم الطالب إشعار لولي الأمر توضح فيه الدرجات المحسومة.', 1, 5)
-- insert into procedures values (10, 'إحالة الطالب إلى لجنة التوجيه والإرشاد','توجه الحالة إلى لجنة التوجيه والإرشاد للمساعدة في علاج وضع الطالب المخالف وفقًا لتقرير دراسة الحالة من المرشد الطلابي في المدرسة ', 1, 5)
--------------------
-- insert into procedures values (11, 'أخذ تعهد خطي من الطالب بعدم تكرار المخالفة','', 2, 1)
-- insert into procedures values (12, 'إشعار ولي الأمر خطيًا بالمخالفة والإجراءات المتخذة','', 2, 1)
-- insert into procedures values (13, 'إلزام الطالب بإصلاح ما أتلفه أو إحضار بديل عنه','', 2, 1)
-- insert into procedures values (14, 'إحالة الطالب إلى المرشد الطلابي لدراسة حالته','', 2, 1)
-- insert into procedures values (15, 'دعوة ولي أمر الطالب وأخذ تعهد خطي على الطالب المخالف بعدم تكرار المخالفة وتوقيع ولي أمره بالعلم والتنسيق معه بتعديل السلوك المخالف','', 2, 2)
-- insert into procedures values (16, 'إلزام الطالب بإصلاح ما أتلفه أو إحضار بديل عنه','', 2, 2)
-- insert into procedures values (17, 'حسم درجتين من درجات سلوك الطالب مع تمكينه من فرص التعويض لتعديل سلوكه وتعويض الدرجات المحسومة وإشعار ولي الأمر بذلك','', 2, 2)
-- insert into procedures values (18, 'إحالة الطالب المخالف للمرشد الطلابي لدراسة حالته','', 2, 2)
-------------------
--  insert into procedures values (19, 'نقل الطالب إلى فصل آخر','', 2, 3)
--  insert into procedures values (20, 'إحالة الطالب إلى لجنة التوجيه والإرشاد','', 2, 3)
 -----------------
--  insert into procedures values (21, 'دعوة ولي الأمر بالحضور للمدرسة وإشعاره خطيًا بأنه في حال تكرار ابنه للمخالفة سيصدر بحقه قرار بالنقل إلى مدرسة أخرى','', 2, 4)
--  insert into procedures values (22, 'إحالة الطالب إلى وحدة الخدمات الإرشادية للمساعدة في العلاج مع استمراره في الدراسة ومتابعة المرشد لحالته','', 2, 4)
--  insert into procedures values (23, 'إحالة الطالب إلى إدارة المدرسة','', 2, 5)
--  insert into procedures values (24, 'الرفع لإدارة التعليم بنقل الطالب لمدرسة أخرى مع استمراره بالدراسة حتى ينقل وإشعار ولي الأمر','', 2, 5)
 ----deg3--p38-------------------------
-- insert into procedures values (25, '','', 3, 1)

 -- add new table studentsProcedures
--  CREATE TABLE [dbo].[studentsProcedures](
-- 	[studentProcedureId] [int] PRIMARY KEY,
-- 	[studentViolationId] [int] NULL,
-- 	[procedureId] [smallint] NULL,
-- 	[empJobId] [int] NULL,
-- 	[procedureDate] [smalldatetime] NULL,
--  [sysStartTime] datetime2 (2) GENERATED ALWAYS AS ROW START,
--  [sysEndTime] datetime2 (2) GENERATED ALWAYS AS ROW END,
--  PERIOD FOR SYSTEM_TIME (sysStartTime, sysEndTime)
--  ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.studentsProceduresHistory));
-- GO

-- ALTER TABLE [dbo].[studentsProcedures] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS

-- ALTER TABLE [dbo].[studentsProcedures]
-- ADD CONSTRAINT [FK_users_studentsProcedures] FOREIGN KEY([issuerId])
-- REFERENCES [dbo].[users] ([userId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsProcedures]
-- ADD CONSTRAINT [FK_studentsViolations_studentsProcedures] FOREIGN KEY([studentViolationId])
-- REFERENCES [dbo].[studentsViolations] ([studentViolationId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsProcedures]
-- ADD CONSTRAINT [FK_procedures_studentsProcedures] FOREIGN KEY([procedureId])
-- REFERENCES [dbo].[procedures] ([procedureId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO

-- ALTER TABLE [dbo].[studentsProcedures]
-- ADD CONSTRAINT [FK_employeesJobs_studentsProcedures] FOREIGN KEY([empJobId])
-- REFERENCES [dbo].[employeesJobs] ([empJobId])
-- ON UPDATE No Action
-- ON DELETE No Action
-- GO