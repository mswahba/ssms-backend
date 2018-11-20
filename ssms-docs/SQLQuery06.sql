--CREATE VIEW [dbo].[v_StudentsFullNameEn]
--AS
--SELECT studentId, fNameEn + ' ' + mNameEn + ' ' + gNameEn + ' ' + lNameEn AS studentNameEn
--FROM   dbo.students

--SELECT * FROM [dbo].[v_StudentsFullNameEn]

--/****** Object:  View [dbo].[v_StudentsFullName]    Script Date: 20/11/2018 10:14:26 AM ******/
--DROP VIEW [dbo].[v_StudentsFullName]
--GO

--CREATE VIEW [dbo].[v_StudentsFullNameAr]
--AS
--SELECT studentId, fNameAr + ' ' + mNameAr + ' ' + gNameAr + ' ' + lNameAr AS studentNameAr
--FROM   dbo.students

--SELECT * FROM [dbo].[v_StudentsFullNameAr]

--CREATE VIEW [dbo].[v_EmployeesFullNameEn]
--AS
--SELECT empId, fNameEn + ' ' + mNameEn + ' ' + gNameEn + ' ' + lNameEn AS empNameEn
--FROM   dbo.employees
--GO

--SELECT * FROM [dbo].[v_EmployeesFullNameEn]

--/****** Object:  View [dbo].[v_EmployeesFullName]    Script Date: 20/11/2018 10:08:03 AM ******/
--DROP VIEW [dbo].[v_EmployeesFullName]
--GO

--CREATE VIEW [dbo].[v_EmployeesFullNameAr]
--AS
--SELECT empId, fNameAr + ' ' + mNameAr + ' ' + gNameAr + ' ' + lNameAr AS empNameAr
--FROM   dbo.employees
--GO

--SELECT * FROM [dbo].[v_EmployeesFullNameAr]

--CREATE VIEW [dbo].[v_ParentsFullNameEn]
--AS
--SELECT parentId, fNameEn + ' ' + mNameEn + ' ' + gNameEn + ' ' + lNameEn AS parentNameEn
--FROM   dbo.parents
--GO

--SELECT * FROM [dbo].[v_ParentsFullNameEn]

--/****** Object:  View [dbo].[v_ParentsFullName]    Script Date: 20/11/2018 09:58:32 AM ******/
--DROP VIEW [dbo].[v_ParentsFullName]
--GO

--CREATE VIEW [dbo].[v_ParentsFullNameAr]
--AS
--SELECT parentId, fNameAr + ' ' + mNameAr + ' ' + gNameAr + ' ' + lNameAr AS parentNameAr
--FROM   dbo.parents
--GO

--SELECT * FROM [dbo].[v_ParentsFullNameAr]

--SELECT * FROM [dbo].[v_EmpActions]


--ALTER VIEW [dbo].[v_BaseEduData]
--AS
--SELECT dbo.schools.schoolID, dbo.schools.schoolNameAr, dbo.schools.schoolNameEn, dbo.branches.branchId, dbo.branches.branchNameAr, dbo.branches.branchNameEn, dbo.stages.stageId, dbo.stages.stageNameAr, dbo.stages.stageNameEn, dbo.grades.gradeId, 
--             dbo.grades.gradeNameAr, dbo.grades.gradeNameEn
--FROM   dbo.schools INNER JOIN
--             dbo.branches ON dbo.schools.schoolID = dbo.branches.schoolId INNER JOIN
--             dbo.stages ON dbo.branches.branchId = dbo.stages.branchId INNER JOIN
--             dbo.grades ON dbo.stages.stageId = dbo.grades.stageId
--GO

--ALTER VIEW [dbo].[v_ClassroomsData]
--AS
--SELECT dbo.schools.schoolID, dbo.schools.schoolNameAr, dbo.schools.schoolNameEn, dbo.branches.branchId, dbo.branches.branchNameAr, dbo.branches.branchNameEn, dbo.stages.stageId, dbo.stages.stageNameAr, dbo.stages.stageNameEn, dbo.grades.gradeId, 
--             dbo.grades.gradeNameAr, dbo.grades.gradeNameEn, dbo.classrooms.classroomId, dbo.classrooms.classNameAr, dbo.classrooms.classNameEn
--FROM   dbo.schools INNER JOIN
--             dbo.branches ON dbo.schools.schoolID = dbo.branches.schoolId INNER JOIN
--             dbo.stages ON dbo.branches.branchId = dbo.stages.branchId INNER JOIN
--             dbo.grades ON dbo.stages.stageId = dbo.grades.stageId INNER JOIN
--             dbo.classrooms ON dbo.grades.gradeId = dbo.classrooms.gradeId
--GO
