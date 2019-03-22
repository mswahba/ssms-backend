-----select * from school_gender----------------------------------
use sumouDB
select * from stages
select * from grades
select * from classrooms
select * from cities
select * from districts
select * from violations
select * from violations_degrees
select * from violations_types
select * from procedures
select * from stProcedures

select * from guardians --where guardianID = '4436474'
select * from studentsPersonal
select * from Addresses
select * from stAddresses
select * from studentsEdu
select * from Relatives
select * from stRelatives
GO
--------------------------------------------------
CREATE TABLE [stages](
	[stageId] [tinyint] NOT NULL,
	[branchId] [tinyint] NULL,
	[stageNameAr] [nvarchar](25) NULL,
	[stageNameEn] [nvarchar](25) NULL,
)
-----------------------------------
CREATE TABLE [dbo].[grades](
	[gradeId] [tinyint] NOT NULL,
	[stageId] [tinyint] NULL,
	[gradeNameAr] [nvarchar](25) NULL,
	[gradeNameEn] [nvarchar](25) NULL,
)
Go
------------------------------------
--stageId	branchId	stageNameAr	stageNameEn	isDeleted
select * from stages
insert into stages values (1,	1,	'الإبتدائي'	, 'Primary'	)
insert into stages values (2,	1,	'المتوسط'	, 'Intermediate')
insert into stages values (3,	1,	'الثانوي'	, 'Secondary')
insert into stages values (4,	2,	'الإبتدائي'	, 'Primary')
insert into stages values (5,	2,	'المتوسط'	, 'Intermediate')
insert into stages values (6,	2,	'الثانوي'	, 'Secondary')
insert into stages values (7,	2,	'الروضة'	, 'Kindergarten')
Go
--------------------------------------------
select * from grades
--gradeId	stageId	gradeNameAr	gradeNameEn

insert into grades values (1	, 1,	'أول ابتدائي'	, 'Grade 1')
insert into grades values (2	, 1,	'ثاني ابتدائي'	, 'Grade 2')
insert into grades values (3	, 1,	'ثالث ابتدائي'	, 'Grade 3')
insert into grades values (4	, 1,	'رابع ابتدائي'	, 'Grade 4')
insert into grades values (5	, 1,	'خامس ابتدائي'	, 'Grade 5')
insert into grades values (6	, 1,	'سادس ابتدائي'	, 'Grade 6')
insert into grades values (7	, 2,	'أول متوسط'	, 'Grade 7')
insert into grades values (8	, 2,	'ثاني متوسط'	, 'Grade 8')
insert into grades values (9	, 2,	'ثالث متوسط'	, 'Grade 9')
insert into grades values (10	, 3,	'أول ثانوي'	, 'Grade 10')
insert into grades values (11	, 3,	'ثاني ثانوي' 	, 'Grade 11')
insert into grades values (12	, 3,	'ثالث ثانوي'	, 'Grade 12')
------------------
insert into grades values (13	, 7,	'الروضة 1'		, 'Kindergarten 1')
insert into grades values (14	, 7,	'الروضة 2'		, 'Kindergarten 2')
insert into grades values (15	, 7,	'الروضة 3'		, 'Kindergarten 3')

insert into grades values (16	, 4,	'أول ابتدائي'	, 'Grade 1')
insert into grades values (17	, 4,	'ثاني ابتدائي'	, 'Grade 2')
insert into grades values (18	, 4,	'ثالث ابتدائي'	, 'Grade 3')
insert into grades values (19	, 4,	'رابع ابتدائي'	, 'Grade 4')
insert into grades values (20	, 4,	'خامس ابتدائي'	, 'Grade 5')
insert into grades values (21	, 4,	'سادس ابتدائي'	, 'Grade 6')
insert into grades values (22	, 5,	'أول متوسط'	, 'Grade 7')
insert into grades values (23	, 5,	'ثاني متوسط'	, 'Grade 8')
insert into grades values (24	, 5,	'ثالث متوسط'	, 'Grade 9')
insert into grades values (25	, 6,	'أول ثانوي'	, 'Grade 10')
insert into grades values (26	, 6,	'ثاني ثانوي' 	, 'Grade 11')
insert into grades values (27	, 6,	'ثالث ثانوي'	, 'Grade 12')
Go
-----------------------------------------------------------------
--drop table classrooms
CREATE TABLE [dbo].[classrooms](
	[classroomId] [smallint] NOT NULL,
	[gradeId] [tinyint] NULL,
	[classNameAr] [nvarchar](25) NULL,
	[classNameEn] [nvarchar](25) NULL,
	[isActive] bit null
	)
Go
select * from classrooms
select classroomid, stageNameAr,  gradeNameAr, classNameAr, classNameEn, isActive
from classrooms inner join grades on classrooms.gradeID = grades.gradeID
inner join stages on stages.stageID = grades.stageID
and stages.stageId in (select stageId from empstages where emp_id = 0)
------------------------------
--select * from class
insert into classrooms	values (1, 1, 'أول-أ', '1-A', 1)
insert into classrooms	values (2, 1, 'أول-ب', '1-B', 1)
insert into classrooms	values (3, 1, 'أول-ج', '1-C', 0)
insert into classrooms	values (4, 2, 'ثاني-أ', '2-A', 1)
insert into classrooms	values (5, 2, 'ثاني-ب', '2-B', 1)
insert into classrooms	values (6, 2, 'ثاني-ج', '2-C', 0)
-----------------------------------
CREATE TABLE [relations](
	[relationID] [tinyint] NULL,
	[relation] [nvarchar](50) NULL
) ON [PRIMARY]
GO
--------------------------------
drop table empStages
Create table empStages(
emp_id int not null,
branchID tinyint not null,     -- 1 = 'بنين' ,
stageID tinyint not null,      -- 1= 'ابتدائي'
joinDate date null,
leaveDate date null,				-- null means emp is still in there
notes nvarchar(max) null
)
Go
insert into empStages values (0, 1, 1, GETDATE(), null,'')
insert into empStages values (0, 1, 3, GETDATE(), null,'')
Go
---------------------------------
select branchID, stageID from empStages where emp_id= 0
select stages.stageId, stageNameAr  from stages inner join empStages on stages.stageId = empStages.stageID and emp_id = 0
select * from empStages
select studentsPersonal.studentID, firstName + ' ' + middleName + ' ' + grandName + ' ' + familyName as studentName
from studentsPersonal inner join studentsEdu on studentsPersonal.studentID = studentsEdu.studentID
and stageID = 1 and leaveDate is null
select  violation_id, violation from violations
Go
-------------------------------
-- select * from studentStatus
-- drop table studentStatus
Create table studentStatus (
statusId tinyint not null,
statusName nvarchar(15) null ,
notes nvarchar(max)
)
Go
insert into studentStatus values (1, 'تسجيل جديد', 'تم التسجيل من قبل ولي الأمر')
insert into studentStatus values (2, 'قبول مبدئي', 'تم التسجيل من قبل إدارة القسم')
insert into studentStatus values (3, 'منتظم', 'الطالب يداوم على الدراسة بانتظام')
insert into studentStatus values (4, 'منقطع', 'الطالب منقطع عن الدراسة')
insert into studentStatus values (5, 'منسحب', 'تم سحب ملف الطالب من المدرسة')
insert into studentStatus values (6, 'متخرج', 'أنهى الطالب سنوات الدراسة بالقسم')
Go
-------------------------------
--drop TABLE [guardians]
CREATE TABLE [guardians](
	[guardianID] [nvarchar](10) NULL,
	[firstName] [nvarchar](20) NULL,
	[middleName] [nvarchar](20) NULL,
	[grandName] [nvarchar](20) NULL,
	[familyName] [nvarchar](20) NULL,
	[nationalityID] [tinyint] NULL,
	[mobile1] [nvarchar](15) NULL,
	[mobile2] [nvarchar](15) NULL,
	[email] [nvarchar](50) NULL,
	[jobName] [nvarchar](50) NULL,
	[jobPlace] [nvarchar](max) NULL,
	[jobAddress] [nvarchar](max) NULL,
	[jobPhone] [nvarchar](10) NULL,
	[isDeleted] [bit] NULL,
	[addDate] [date] NULL,
	[notes] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
---------------------------------------
--drop TABLE studentsPersonal
CREATE TABLE studentsPersonal(
	[studentID] [nvarchar](10) NULL,
	[firstName] [nvarchar](20) NULL,
	[middleName] [nvarchar](20) NULL,
	[grandName] [nvarchar](20) NULL,
	[familyName] [nvarchar](20) NULL,
	[genderID] [tinyint] null,
	[nationalityID] [tinyint] NULL,
	[dobG] [date] NULL,
	[dobH] [nvarchar](10) NULL,
	birthPlace nvarchar(100) null,
	[guardianID] [nvarchar](10) NULL,
	[relationID] [tinyint] NULL,
	[mobileMother1] [nvarchar](15) NULL,
	[mobileMother2] [nvarchar](15) NULL,
	[mobile] [nvarchar](15) NULL,
	[email] [nvarchar](30) NULL,
	[lastSchool] [nvarchar](35) NULL,
	[isDeleted] [bit] NULL,
	[addDate] [date] NULL
) ON [PRIMARY]
GO
------DELETED--stGuardians----------
--CREATE TABLE [stGuardians](
--	[studentID] [nvarchar](10) NULL,
--	[guardianID] [nvarchar](10) NULL,
--	[relationID] [tinyint] NULL
--) ON [PRIMARY]
--GO
------------------------------------
create view v_guardianNumOfStudents
As
select guardians.guardianid, COUNT(studentID) as NumOfStudents from studentsPersonal
right join guardians on studentsPersonal.guardianID = guardians.guardianID
group by guardians.guardianid

-----------------------------
--drop table [relatives]
CREATE TABLE [relatives](
	[relativeID] [int] identity(1,1),
	[relativeName] [nvarchar](50) NULL,
	[relativeMobile1] [nvarchar](15) NULL,
	[relativeMobile2] [nvarchar](15) NULL,
	[relativePhone] [nvarchar](10) NULL,
	[relativeAddress] [nvarchar](max) NULL,
	[guardianID] [nvarchar](10) NULL,
	[addDate] [date] NULL
) ON [PRIMARY]
GO
-------------------------------------------
CREATE TABLE [stRelatives](
	[studentID] [nvarchar](10) NULL,
	[relativeID] [int] NULL,
	[relationID] [tinyint] NULL,
	[priority] [tinyint] NULL,
	[addDate] [date] NULL
) ON [PRIMARY]
GO
-----------------TABLE [addresses]-----------------
-- drop TABLE [addresses]
CREATE TABLE [addresses](
	[addressID] [int] identity(1,1) ,
	[guardianID] [nvarchar](10) NULL,
	[cityID] [smallint] NULL,
	[districtID] [smallint] NULL,
	[streetName] [nvarchar](max) NULL,
	[houseNumber] [smallint] NULL,
	[extraDetails] [nvarchar](max) NULL,
	[phone] [nvarchar](20) NULL,
	[addDate] [date] NULL,
	[isMain] bit null
) ON [PRIMARY]
GO
--Alter table addresses  add [isMain] bit null
------------------------------------------
CREATE TABLE [stAddresses](
	[studentID] [nvarchar](10) NULL,
	[addressID] [nvarchar](10) NULL,
	[addDate] [date] NULL
) ON [PRIMARY]
GO
----------------------------------------
drop table [studentsEdu]
CREATE TABLE [studentsEdu](
	[studentID] [nvarchar](10) NULL,
	[yearID] [tinyint] NULL,
	[genderID] tinyint null,
	[stageID] [tinyint] NULL,
	[gradeID] [tinyint] NULL,
	[classID] [smallint] NULL,
	[joinDate] [date] NULL,
	[leaveDate] [date] NULL
) ON [PRIMARY]
GO
--select yearID, genderID, stageID, gradeID, classID from studentsEdu where studentID = @studentID and leaveDate is null and
----------------------------------------
Create table stStatus (
studentID [nvarchar](10) NULL,
statusId tinyint  null,
notes nvarchar(max) null,
statusDate date null
)
Go
-------------------------------------
CREATE TABLE [violations_degrees](
	[degreeID] [tinyint] NULL,
	[degreeName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
--------------------------------------
insert into violations_degrees values (1, 'الدرجة الأولى')
insert into violations_degrees values (2, 'الدرجة الثانية')
insert into violations_degrees values (3, 'الدرجة الثالثة')
insert into violations_degrees values (4, 'الدرجة الرابعة')
insert into violations_degrees values (5, 'الدرجة الخامسة')
insert into violations_degrees values (6, 'الدرجة السادسة')
insert into violations_degrees values (7, 'الدرجة السابعة')
GO
-------------------------------------------
select * from violations_types
create table violations_types (
typeID tinyint null,
typeName nvarchar(50) null
)
GO
-------------------------------
insert into violations_types values (1, 'مخالفة سلوكية')
insert into violations_types values (2, 'مخالفة تعليمية')
insert into violations_types values (3, 'مخالفة نظامية')
GO
-------------------------------
CREATE TABLE [violations](
	[violation_id] [smallint] NULL,
	[violation_degree] [tinyint] NULL,
	[violation_type] [tinyint] NULL,
	[violation] [nvarchar](max) NULL
) ON [PRIMARY]
GO
-------------------------------------
drop table [stViolations]
CREATE TABLE [stViolations](
	[stViolationID] [int] NULL,
	[violationID] [smallint] NULL,
	[studentID] [nvarchar](10) NULL,
	[yearID] tinyint null,
	[stageID] [tinyint] NULL,
	[gradeID] [tinyint] NULL,
	[classID] [smallint] NULL,
	[empID] [int] NULL,
	[vDate] [date] NULL
) ON [PRIMARY]
GO
------------------------------
drop table [procedures]
CREATE TABLE [dbo].[procedures](
	[procedureID] [smallint] NULL,
	[procedureName] [nvarchar](max) NULL,
	[notes] [nvarchar](max) NULL,
	[degreeID] [tinyint] NULL,
	[atRepetiton] [tinyint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
-------------------------------------
insert into procedures values (1, 'تنبيه شفوي انفرادي للمرة الأولى', 'نظراً لارتكابك مخالفة من مخالفات الدرجة الأولى فإننا ننبهك تنبيهاً شفوياً للمرة الأولى', 1, 1)
insert into procedures values (2, 'تنبيه شفوي انفرادي للمرة الثانية', 'نظراً لارتكابك مخالفة من مخالفات الدرجة الأولى فإننا ننبهك تنبيهاً شفوياً للمرة الثانية.',1, 2)
insert into procedures values (3, 'تدوين المخالفة وتوقيع الطالب','نظراً لارتكابك لمخالفة من الدرجة الأولى وجب توقيعك على إثبات المخالفة.', 1, 3)
insert into procedures values (4, 'إشعار ولي الأمر','تسليم الطالب إشعار لولي الأمر بمخالفته ومحادثة ولي الأمر هاتفياً والتنسيق معه لتعديل السلوك. )توقيع من قام بالاتصال(', 1, 4)
insert into procedures values (5, 'الإحالة للمرشد','نظر اً لمخالفتك فقد حولت إلى المرشد الطلابي لدراسة حالتك.', 1, 4)

insert into procedures values (6, 'أخذ تعهد خطي على الطالب','أتعهد بالانضباط السلوكي وعدم تكرار المخالفة', 1, 5)
insert into procedures values (7, 'استدعاء ولي الأمر','تسليم الطالب خطاب استدعاء لولي أمره وإخطاره بمخالفة الطالب', 1, 5)
insert into procedures values (8, 'حسم درجة واحدة من السلوك','نظراً لاستنفاذ جميع الإجراءات وجب حسم درجة واحدة من درجات السلوك حسب ما نصت علية القواعد.', 1, 5)
insert into procedures values (9, 'إشعار ولي الأمر بالحسم','تسليم الطالب إشعار لولي الأمر توضح فيه الدرجات المحسومة.', 1, 5)
insert into procedures values (10, 'إحالة الطالب إلى لجنة التوجيه والإرشاد','توجه الحالة إلى لجنة التوجيه والإرشاد للمساعدة في علاج وضع الطالب المخالف وفقًا لتقرير دراسة الحالة من المرشد الطلابي في المدرسة ', 1, 5)
--------------------
insert into procedures values (11, 'أخذ تعهد خطي من الطالب بعدم تكرار المخالفة','', 2, 1)
insert into procedures values (12, 'إشعار ولي الأمر خطيًا بالمخالفة والإجراءات المتخذة','', 2, 1)
insert into procedures values (13, 'إلزام الطالب بإصلاح ما أتلفه أو إحضار بديل عنه','', 2, 1)
insert into procedures values (14, 'إحالة الطالب إلى المرشد الطلابي لدراسة حالته','', 2, 1)
insert into procedures values (15, 'دعوة ولي أمر الطالب وأخذ تعهد خطي على الطالب المخالف بعدم تكرار المخالفة وتوقيع ولي أمره بالعلم والتنسيق معه بتعديل السلوك المخالف','', 2, 2)
insert into procedures values (16, 'إلزام الطالب بإصلاح ما أتلفه أو إحضار بديل عنه','', 2, 2)
insert into procedures values (17, 'حسم درجتين من درجات سلوك الطالب مع تمكينه من فرص التعويض لتعديل سلوكه وتعويض الدرجات المحسومة وإشعار ولي الأمر بذلك','', 2, 2)
insert into procedures values (18, 'إحالة الطالب المخالف للمرشد الطلابي لدراسة حالته','', 2, 2)
-------------------
 insert into procedures values (19, 'نقل الطالب إلى فصل آخر','', 2, 3)
 insert into procedures values (20, 'إحالة الطالب إلى لجنة التوجيه والإرشاد','', 2, 3)
 -----------------
 insert into procedures values (21, 'دعوة ولي الأمر بالحضور للمدرسة وإشعاره خطيًا بأنه في حال تكرار ابنه للمخالفة سيصدر بحقه قرار بالنقل إلى مدرسة أخرى','', 2, 4)
 insert into procedures values (22, 'إحالة الطالب إلى وحدة الخدمات الإرشادية للمساعدة في العلاج مع استمراره في الدراسة ومتابعة المرشد لحالته','', 2, 4)
 insert into procedures values (23, 'إحالة الطالب إلى إدارة المدرسة','', 2, 5)
 insert into procedures values (24, 'الرفع لإدارة التعليم بنقل الطالب لمدرسة أخرى مع استمراره بالدراسة حتى ينقل وإشعار ولي الأمر','', 2, 5)
 ----deg3--p38-------------------------
 insert into procedures values (25, '','', 3, 1)
--------------------------------------
CREATE TABLE [dbo].[stProcedures](
	[stProcedureID] [int] NULL,
	[stViolationID] [int] NULL,
	[procedureID] [smallint] NULL,
	[empID] [int] NULL,
	[pDate] [date] NULL
) ON [PRIMARY]
GO
----------------------------------------
select * from relations
insert into relations values (1, 'أب')
insert into relations values (2, 'أم')
insert into relations values (3, 'أخ')
insert into relations values (4, 'عم')
insert into relations values (5, 'خال')
insert into relations values (6, 'جد- للأب')
insert into relations values (7, 'جد- للأم')
insert into relations values (8, 'ابن عم')
insert into relations values (9, 'ابن خال')
insert into relations values (10, 'جدة')
insert into relations values (11, 'خالة')
insert into relations values (12, 'عمة')
--------------------------------
create table cities (
cityID tinyint null,
cityName nvarchar(100) null
)
GO
--------------------------------
SELECT * FROM cities
insert into cities values (1, 'الرياض')
insert into cities values (2, 'الخرج')
insert into cities values (3, 'المجمعة')
insert into cities values (4, 'الدوادمي')
insert into cities values (5, 'مكة')
insert into cities values (6, 'المدينة المنورة')
insert into cities values (7, 'بريدة')
insert into cities values (8, 'تبوك')
insert into cities values (9, 'الدمام')
insert into cities values (10, 'الاحساء')
insert into cities values (11, 'القطيف')
insert into cities values (12, 'خميس مشيط')
insert into cities values (13, 'الطائف')
insert into cities values (14, 'نجران')
insert into cities values (15, 'حفر الباطن')
insert into cities values (16, 'الجبيل')
insert into cities values (17, 'ضباء')
insert into cities values (18, 'الثقبة')
insert into cities values (19, 'ينبع البحر')
insert into cities values (20, 'الخبر')
insert into cities values (21, 'عرعر')
insert into cities values (22, 'الحوية')
insert into cities values (23, 'عنيزة')
insert into cities values (24, 'سكاكا')
insert into cities values (25, 'جيزان')
insert into cities values (26, 'القريات')
insert into cities values (27, 'الظهران')
insert into cities values (28, 'الباحة')
insert into cities values (29, 'الزلفي')
insert into cities values (30, 'الرس')
insert into cities values (31, 'وادي الدواسر')
insert into cities values (32, 'بيشه')
insert into cities values (33, 'سيهات')
insert into cities values (34, 'شروره')
insert into cities values (35, 'بحره')
insert into cities values (36, 'تاروت')
insert into cities values (37, 'صبياء')
insert into cities values (38, 'بيش')
insert into cities values (39, 'أحد رفيدة')
insert into cities values (40, 'الفريش')
insert into cities values (41, 'بارق')
insert into cities values (42, 'الحوطة')
insert into cities values (43, 'الأفلاج')
--------------------------------
create table districts (
districtID tinyint null,
districtName nvarchar(100) null,
cityID tinyint null
)
GO
------------------------------------
select * from districts order by 1
delete from districts where districtID=69
update districts set districtName= 'الصالحية' where districtID=36

insert into districts values (1 , 'الملقا', 1)
insert into districts values (2, 'الصحافة', 1)
insert into districts values (3 , 'المصيف', 1)
insert into districts values (4, 'الياسمين', 1)
insert into districts values (5, 'النفل', 1)
insert into districts values (6 , 'الازدهار', 1)
insert into districts values (7 , 'غرناطة', 1)
insert into districts values (8 , 'المغرزات', 1)
insert into districts values (9 , 'الواحة', 1)
insert into districts values (10, 'المرسلات', 1)
insert into districts values (11 , 'الورود', 1)
insert into districts values (12 , 'المروج', 1)
insert into districts values (13 , 'الغدير', 1)
insert into districts values (14 , 'الربيع', 1)
insert into districts values (15 , 'الرائد', 1)
insert into districts values (16 , 'العقيق', 1)
insert into districts values (17 , 'الدرعية', 1)
insert into districts values (18 , 'النخيل', 1)
insert into districts values (19 , 'الفلاح', 1)
insert into districts values (20 , 'الروضة', 1)
insert into districts values (21, 'النسيم', 1)
insert into districts values (22, 'النظيم', 1)
insert into districts values (23, 'السلي', 1)
insert into districts values (24, 'القدس', 1)
insert into districts values (25, 'الحمراء', 1)
insert into districts values (26, 'الجزيرة', 1)
insert into districts values (27, 'النهضة', 1)
insert into districts values (28, 'الخليج', 1)
insert into districts values (29, 'الملز', 1)
insert into districts values (30, 'الرواد', 1)
insert into districts values (31, 'الربوه', 1)
insert into districts values (32, 'إشبيليا', 1)
insert into districts values (33 , 'اليرموك', 1)
insert into districts values (34, 'قرطبة', 1)
insert into districts values (35 , 'الريان', 1)
insert into districts values (36 , 'الصالحية', 1)
insert into districts values (37 , 'الشهداء', 1)
insert into districts values (38 , 'الملز', 1)
insert into districts values (39 , 'البديعة', 1)
insert into districts values (40 , 'ظهرة البديعة', 1)
insert into districts values (41 , 'عرقة', 1)
insert into districts values (42 , 'لبن', 1)
insert into districts values (43 , 'السويدي', 1)
insert into districts values (44 , 'شبرا', 1)
insert into districts values (45 , 'العريجاء', 1)
insert into districts values (46 , 'جامعة الملك سعود', 1)
insert into districts values (47 , 'الشفاء', 1)
insert into districts values (48 , 'بدر', 1)
insert into districts values (49 , 'المروة', 1)
insert into districts values (50 , 'الفواز', 1)
insert into districts values (51 , 'الحزم', 1)
insert into districts values (52 , 'العزيزية', 1)
insert into districts values (53 , 'الدار البيضاء', 1)
insert into districts values (54 , 'المنصورة', 1)
insert into districts values (55 , 'نمار', 1)
insert into districts values (56 , 'الدريهمية', 1)
insert into districts values (57 , 'الفاخرية', 1)
insert into districts values (58 , 'اليمامة', 1)
insert into districts values (59 , 'المصانع', 1)
insert into districts values (60 , 'بن تركي', 1)
insert into districts values (61 , 'الشميسي', 1)
insert into districts values (62 , 'الحاير', 1)
insert into districts values (63 , 'الشعلان', 1)
insert into districts values (64 , 'المربع', 1)
insert into districts values (65 , 'المرقب', 1)
insert into districts values (66 , 'البطحاء', 1)
insert into districts values (67 , 'الديرة', 1)
insert into districts values (68 , 'منفوحة', 1)
--------------------------------
/*
Create view v_violationCount
As
select  studentID,yearID, violationID , count(violationID) vCount from stViolations
group by studentID , yearID, violationID
*/
Go
--------------------------
/*
Create view AllViolationsProceduresData
As
select sp.studentID, CONCAT( sp.firstName, ' ', sp.middleName, ' ' , sp.grandName, ' ' , sp.familyName  ) as studentName
, stageNameAr, gradeNameAr, classrooms.classNameAr
 violation, stViolations.stViolationID, stViolations.violationID, v_violationCount.yearID, vCount, vDate,stViolations.empID as vIssuerID, vIssuers.emp_name as vIssuerName,
 stProcedureID, pDate, stProcedures.empID pIssuerID, pIssuers.emp_name  as pIssuerName
 from studentsPersonal sp
inner join stViolations on sp.studentID = stViolations.studentID
inner join violations on violations.violation_id = stViolations.violationID
left join stages on stages.stageId = stViolations.stageID
left join grades on grades.gradeId= stViolations.gradeID
left join classrooms on classrooms.classroomId= stViolations.classID
inner join employees vIssuers on vIssuers.emp_id = stViolations.empID
left join stProcedures on stProcedures.stViolationID = stViolations.stViolationID
inner join v_violationCount on v_violationCount.studentID = stViolations.studentID
														and v_violationCount.violationID= stViolations.violationID
														and v_violationCount.yearID = stViolations.yearID
left join employees pIssuers on pIssuers.emp_id = stProcedures.empID
where stProcedureID is null
*/
Go
---------------------------------------
-- Get Procedures for a specific violation where same degree procs and at repetirion or less
---------------------------------------
select  distinct procedures.procedureID, procedureName from procedures
inner join violations on procedures.degreeID = violations.violation_degree
inner join stViolations on stViolations.violationID = violations.violation_id
inner join v_violationCount on v_violationCount.studentID = stViolations.studentID
		and v_violationCount.violationID=stViolations.violationID
		and stViolations.yearID = (select year_id from academic_years where GETUTCDATE() between [start_date] and [end_date])
where stViolationID=12  and   atRepetiton<= vCount
order by procedureID
--------------------------------
Go
Create procedure [sp_stProcedure_add]
(
	@stViolationID int ,
	@procedureID smallint ,
	@empID [int] ,
	@pDate [date]
)
As
begin
Declare @p_id int
set @p_id = (select top(1) stProcedureID from stProcedures order by stProcedureID desc)
if @p_id is null set @p_id = 0
set @p_id = @p_id + 1

insert into stProcedures  values (
	 @p_id
	,@stViolationID
	,@procedureID
	,@empID
	,@pDate
)
end
GO
-------------------------------
