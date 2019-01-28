-- list of tables to be converted to Temporal ones:
---------------------------------------------------
/*
[dbo].[employees]
[dbo].[employeesFinance]
[dbo].[employeesHR]
[dbo].[employeesJobs]
[dbo].[employeesActions]
[dbo].[departments]
[dbo].[lessons]
[dbo].[lessonsFiles]
[dbo].[parents]
[dbo].[periods]
[dbo].[periodsDetails]
[dbo].[periodsFiles]
[dbo].[students]
[dbo].[subjects]
[dbo].[teachersEdu]
[dbo].[timeTables]
[dbo].[teachersQuorums]
[dbo].[users]
[dbo].[weeksPlans]
*/
GO
-- employyes => temporal table:
-------------------------------
/*
ALTER TABLE [dbo].[employees] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [FK_users_employees] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employees] DROP CONSTRAINT [FK_employees_countries]
GO
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [FK_employees_countries] FOREIGN KEY([countryId])
REFERENCES [dbo].[countries] ([countryId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employees] DROP CONSTRAINT [FK_employees_users]
GO
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [FK_employees_users] FOREIGN KEY([empId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO


ALTER TABLE [dbo].[employees]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[employees]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[employeesHistory]))
GO
*/

-- employeesFinance => temporal table:
-------------------------------------
/*
ALTER TABLE [dbo].[employeesFinance] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[employeesFinance]
ADD CONSTRAINT [FK_users_employeesFinance] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesFinance] DROP CONSTRAINT [FK_employeesFinance_employees]
GO
ALTER TABLE [dbo].[employeesFinance]
ADD CONSTRAINT [FK_employeesFinance_employees] FOREIGN KEY([empId])
REFERENCES [dbo].[employees] ([empId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesFinance]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[employeesFinance]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[employeesFinanceHistory]))
GO
*/

-- employeesHR => temporal table:
---------------------------------
/*
ALTER TABLE [dbo].[employeesHR] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[employeesHR]
ADD CONSTRAINT [FK_users_employeesHR] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesHR] DROP CONSTRAINT [FK_EmployeesHR_employees]
GO
ALTER TABLE [dbo].[employeesHR]
ADD CONSTRAINT [FK_EmployeesHR_employees] FOREIGN KEY([empId])
REFERENCES [dbo].[employees] ([empId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesHR]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[employeesHR]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[employeesHRHistory]))
GO
*/

-- employeesJobs => temporal table:
-----------------------------------
/*
ALTER TABLE [dbo].[employeesJobs] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[employeesJobs]
ADD CONSTRAINT [FK_users_employeesJobs] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesJobs] DROP CONSTRAINT [FK_employeesJobs_employees]
GO
ALTER TABLE [dbo].[employeesJobs]
ADD CONSTRAINT [FK_employeesJobs_employees] FOREIGN KEY([empId])
REFERENCES [dbo].[employees] ([empId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesJobs] DROP CONSTRAINT [FK_employeesJobs_departments]
GO
ALTER TABLE [dbo].[employeesJobs]
ADD  CONSTRAINT [FK_employeesJobs_departments] FOREIGN KEY([departmentId])
REFERENCES [dbo].[departments] ([departmentId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesJobs] DROP CONSTRAINT [FK_employeesJobs_jobs]
GO
ALTER TABLE [dbo].[employeesJobs]
ADD  CONSTRAINT [FK_employeesJobs_jobs] FOREIGN KEY([jobId])
REFERENCES [dbo].[jobs] ([jobId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesJobs]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[employeesJobs]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[employeesJobsHistory]))
GO
*/

-- employeesActions => temporal table:
--------------------------------------
/*
ALTER TABLE [dbo].[employeesActions] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[employeesActions]
ADD CONSTRAINT [FK_users_employeesActions] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesActions] DROP CONSTRAINT [FK_employeesActions_actions]
GO
ALTER TABLE [dbo].[employeesActions]
ADD  CONSTRAINT [FK_employeesActions_actions] FOREIGN KEY([actionId])
REFERENCES [dbo].[actions] ([actionId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesActions] DROP CONSTRAINT [FK_employeesActions_employeesJobs]
GO
ALTER TABLE [dbo].[employeesActions]
ADD  CONSTRAINT [FK_employeesActions_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[employeesActions]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[employeesActions]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[employeesActionsHistory]))
GO
*/

-- departments => temporal table:
---------------------------------
/*
ALTER TABLE [dbo].[departments] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[departments]
ADD CONSTRAINT [FK_users_departments] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[departments]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[departments]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[departmentsHistory]))
GO
*/

-- lessons => temporal table:
-----------------------------
/*
ALTER TABLE [dbo].[lessons] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[lessons]
ADD CONSTRAINT [FK_users_lessons] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[lessons]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[lessons]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[lessonsHistory]))
GO
*/

-- lessonsFiles => temporal table:
----------------------------------
/*
ALTER TABLE [dbo].[lessonsFiles] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[lessonsFiles]
ADD CONSTRAINT [FK_users_lessonsFiles] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[lessonsFiles] DROP CONSTRAINT [FK_lessonsFiles_lessons]
GO
ALTER TABLE [dbo].[lessonsFiles]
ADD CONSTRAINT [FK_lessonsFiles_lessons] FOREIGN KEY([lessonId])
REFERENCES [dbo].[lessons] ([lessonId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[lessonsFiles] DROP CONSTRAINT [FK_lessonsFiles_docTypes]
GO
ALTER TABLE [dbo].[lessonsFiles]
ADD CONSTRAINT [FK_lessonsFiles_docTypes] FOREIGN KEY([docTypeId])
REFERENCES [dbo].[docTypes] ([docTypeId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[lessonsFiles]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[lessonsFiles]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[lessonsFilesHistory]))
GO
*/

-- parents => temporal table:
-----------------------------
/*
ALTER TABLE [dbo].[parents] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[parents]
ADD CONSTRAINT [FK_users_parents] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[parents] DROP CONSTRAINT [FK_parents_users]
GO
ALTER TABLE [dbo].[parents]
ADD  CONSTRAINT [FK_parents_users] FOREIGN KEY([parentId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[parents] DROP CONSTRAINT [FK_parents_countries]
GO
ALTER TABLE [dbo].[parents]
ADD  CONSTRAINT [FK_parents_countries] FOREIGN KEY([countryId])
REFERENCES [dbo].[countries] ([countryId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[parents]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[parents]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[parentsHistory]))
GO
*/

-- periods => temporal table:
-----------------------------
/*
ALTER TABLE [dbo].[periods] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[periods]
ADD CONSTRAINT [FK_users_periods] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periods] DROP CONSTRAINT [FK_periods_academicSemesters]
GO
ALTER TABLE [dbo].[periods]
ADD  CONSTRAINT [FK_periods_academicSemesters] FOREIGN KEY([semesterId])
REFERENCES [dbo].[academicSemesters] ([semesterId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periods] DROP CONSTRAINT [FK_periods_classrooms]
GO
ALTER TABLE [dbo].[periods]
ADD  CONSTRAINT [FK_periods_classrooms] FOREIGN KEY([classeroomId])
REFERENCES [dbo].[classrooms] ([classroomId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periods] DROP CONSTRAINT [FK_periods_employeesJobs]
GO
ALTER TABLE [dbo].[periods]
ADD  CONSTRAINT [FK_periods_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periods] DROP CONSTRAINT [FK_periods_gradesSubjects]
GO
ALTER TABLE [dbo].[periods]
ADD  CONSTRAINT [FK_periods_gradesSubjects] FOREIGN KEY([gradeSubjectId])
REFERENCES [dbo].[gradesSubjects] ([gradeSubjectId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periods] DROP CONSTRAINT [FK_periods_schoolDayEvents]
GO
ALTER TABLE [dbo].[periods]
ADD  CONSTRAINT [FK_periods_schoolDayEvents] FOREIGN KEY([schoolDayEventId])
REFERENCES [dbo].[schoolDayEvents] ([schoolDayEventId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periods]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[periods]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[periodsHistory]))
GO
*/

-- periodsDetails => temporal table:
------------------------------------
/*
ALTER TABLE [dbo].[periodsDetails] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[periodsDetails]
ADD CONSTRAINT [FK_users_periodsDetails] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periodsDetails] DROP CONSTRAINT [FK_periodsDetails_periods]
GO
ALTER TABLE [dbo].[periodsDetails]
ADD CONSTRAINT [FK_periodsDetails_periods] FOREIGN KEY([periodId])
REFERENCES [dbo].[periods] ([periodId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periodsDetails] DROP CONSTRAINT [FK_periodsDetails_students]
GO
ALTER TABLE [dbo].[periodsDetails]
ADD CONSTRAINT [FK_periodsDetails_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([studentId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periodsDetails]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[periodsDetails]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[periodsDetailsHistory]))
GO
*/

-- periodsFiles => temporal table:
----------------------------------
/*
ALTER TABLE [dbo].[periodsFiles] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[periodsFiles]
ADD CONSTRAINT [FK_users_periodsFiles] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periodsFiles] DROP CONSTRAINT [FK_periodsFiles_docTypes]
GO
ALTER TABLE [dbo].[periodsFiles]
ADD  CONSTRAINT [FK_periodsFiles_docTypes] FOREIGN KEY([docTypeId])
REFERENCES [dbo].[docTypes] ([docTypeId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periodsFiles] DROP CONSTRAINT [FK_periodsFiles_weeksPlans]
GO
ALTER TABLE [dbo].[periodsFiles]
ADD CONSTRAINT [FK_periodsFiles_weeksPlans] FOREIGN KEY([weekPlanId])
REFERENCES [dbo].[weeksPlans] ([weekPlanId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[periodsFiles]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[periodsFiles]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[periodsFilesHistory]))
GO
*/

-- students => temporal table:
----------------------------------
/*
ALTER TABLE [dbo].[students] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [FK_users_students] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[students] DROP CONSTRAINT [FK_students_countries]
GO
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [FK_students_countries] FOREIGN KEY([countryId])
REFERENCES [dbo].[countries] ([countryId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[students] DROP CONSTRAINT [FK_students_parents]
GO
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [FK_students_parents] FOREIGN KEY([parentId])
REFERENCES [dbo].[parents] ([parentId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[students] DROP CONSTRAINT [FK_students_users]
GO
ALTER TABLE [dbo].[students]
ADD  CONSTRAINT [FK_students_users] FOREIGN KEY([studentId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[students]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[students]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[studentsHistory]))
GO
*/
-- subjects => temporal table:
------------------------------
/*
ALTER TABLE [dbo].[subjects] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[subjects]
ADD CONSTRAINT [FK_users_subjects] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[subjects] DROP CONSTRAINT [FK_subjects_majors]
GO
ALTER TABLE [dbo].[subjects]
ADD CONSTRAINT [FK_subjects_majors] FOREIGN KEY([majorId])
REFERENCES [dbo].[majors] ([majorId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[subjects]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[subjects]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[subjectsHistory]))
GO
*/
-- teachersEdu => temporal table:
---------------------------------
/*
ALTER TABLE [dbo].[teachersEdu] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[teachersEdu]
ADD CONSTRAINT [FK_users_teachersEdu] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[teachersEdu] DROP CONSTRAINT [FK_teachersEdu_employeesJobs]
GO
ALTER TABLE [dbo].[teachersEdu]
ADD CONSTRAINT [FK_teachersEdu_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[teachersEdu] DROP CONSTRAINT [FK_teachersEdu_gradesSubjects]
GO
ALTER TABLE [dbo].[teachersEdu]
ADD CONSTRAINT [FK_teachersEdu_gradesSubjects] FOREIGN KEY([gradeSubjectId])
REFERENCES [dbo].[gradesSubjects] ([gradeSubjectId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[teachersEdu]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[teachersEdu]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[teachersEduHistory]))
GO
*/
-- teachersQuorums => temporal table:
-------------------------------------
/*
ALTER TABLE [dbo].[teachersQuorums] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[teachersQuorums]
ADD CONSTRAINT [FK_users_teachersQuorums] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[teachersQuorums] DROP CONSTRAINT [FK_teachersQuorums_academicSemesters]
GO
ALTER TABLE [dbo].[teachersQuorums]
ADD  CONSTRAINT [FK_teachersQuorums_academicSemesters] FOREIGN KEY([semesterId])
REFERENCES [dbo].[academicSemesters] ([semesterId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[teachersQuorums] DROP CONSTRAINT [FK_teachersQuorums_employeesJobs]
GO
ALTER TABLE [dbo].[teachersQuorums]
ADD  CONSTRAINT [FK_teachersQuorums_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[teachersQuorums]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[teachersQuorums]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[teachersQuorumsHistory]))
GO
*/
-- timeTables => temporal table:
--------------------------------
/*
ALTER TABLE [dbo].[timeTables] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[timeTables]
ADD CONSTRAINT [FK_users_timeTables] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[timeTables] DROP CONSTRAINT [FK_timeTable_employeesJobs]
GO
ALTER TABLE [dbo].[timeTables]
ADD  CONSTRAINT [FK_timeTable_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[timeTables] DROP CONSTRAINT [FK_timeTable_gradesSubjects]
GO
ALTER TABLE [dbo].[timeTables]
ADD CONSTRAINT [FK_timeTable_gradesSubjects] FOREIGN KEY([gradeSubjectId])
REFERENCES [dbo].[gradesSubjects] ([gradeSubjectId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[timeTables] DROP CONSTRAINT [FK_timeTable_schoolDayEvents]
GO
ALTER TABLE [dbo].[timeTables]
ADD  CONSTRAINT [FK_timeTable_schoolDayEvents] FOREIGN KEY([schoolDayEventId])
REFERENCES [dbo].[schoolDayEvents] ([schoolDayEventId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[timeTables]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[timeTables]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[timeTablesHistory]))
GO
*/
-- users => temporal table:
---------------------------
/*
ALTER TABLE [dbo].[users] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [FK_usersA_usersB] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[users] DROP CONSTRAINT [FK_users_accountStatus]
GO
ALTER TABLE [dbo].[users]
ADD  CONSTRAINT [FK_users_accountStatus] FOREIGN KEY([accountStatusId])
REFERENCES [dbo].[accountStatus] ([statusId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[users] DROP CONSTRAINT [FK_users_userTypes]
GO
ALTER TABLE [dbo].[users]
ADD  CONSTRAINT [FK_users_userTypes] FOREIGN KEY([userTypeId])
REFERENCES [dbo].[userTypes] ([userTypeId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[users]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[users]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[usersHistory]))
GO
*/
-- weeksPlans => temporal table:
--------------------------------
/*
ALTER TABLE [dbo].[weeksPlans] ADD [issuerId] CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER TABLE [dbo].[weeksPlans]
ADD CONSTRAINT [FK_users_weeksPlans] FOREIGN KEY([issuerId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[weeksPlans] DROP CONSTRAINT [FK_weeksPlans_academicWeeks]
GO
ALTER TABLE [dbo].[weeksPlans]
ADD  CONSTRAINT [FK_weeksPlans_academicWeeks] FOREIGN KEY([weekId])
REFERENCES [dbo].[academicWeeks] ([weekId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[weeksPlans] DROP CONSTRAINT [FK_weeksPlans_lessons]
GO
ALTER TABLE [dbo].[weeksPlans]
ADD  CONSTRAINT [FK_weeksPlans_lessons] FOREIGN KEY([lessonId])
REFERENCES [dbo].[lessons] ([lessonId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[weeksPlans] DROP CONSTRAINT [FK_weeksPlans_timeTable]
GO
ALTER TABLE [dbo].[weeksPlans]
ADD  CONSTRAINT [FK_weeksPlans_timeTable] FOREIGN KEY([timeTableId])
REFERENCES [dbo].[timeTables] ([timeTableId])
ON UPDATE No Action
ON DELETE No Action
GO

ALTER TABLE [dbo].[weeksPlans]
ADD sysStartTime datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
    sysEndTime datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
GO
ALTER TABLE [dbo].[weeksPlans]
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[weeksPlansHistory]))
GO
*/