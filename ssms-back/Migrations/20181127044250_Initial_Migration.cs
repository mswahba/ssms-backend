using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSMS.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "academicYears",
                columns: table => new
                {
                    yearId = table.Column<byte>(nullable: false),
                    yearNameG = table.Column<string>(maxLength: 10, nullable: true),
                    yearNameH = table.Column<string>(maxLength: 10, nullable: true),
                    yearStartDateG = table.Column<DateTime>(type: "date", nullable: true),
                    yearStartDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    yearEndDateG = table.Column<DateTime>(type: "date", nullable: true),
                    yearEndDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicYears", x => x.yearId);
                });

            migrationBuilder.CreateTable(
                name: "accountStatus",
                columns: table => new
                {
                    statusId = table.Column<byte>(nullable: false),
                    statusAr = table.Column<string>(maxLength: 20, nullable: true),
                    statusEn = table.Column<string>(maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountStatus", x => x.statusId);
                });

            migrationBuilder.CreateTable(
                name: "actions",
                columns: table => new
                {
                    actionId = table.Column<short>(nullable: false),
                    actionNameAr = table.Column<string>(maxLength: 100, nullable: true),
                    actionNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    actionUrl = table.Column<string>(maxLength: 100, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.actionId);
                });

            migrationBuilder.CreateTable(
                name: "behavioralViolations",
                columns: table => new
                {
                    violationId = table.Column<short>(nullable: false),
                    violationNameAr = table.Column<string>(maxLength: 150, nullable: true),
                    violationNameEn = table.Column<string>(maxLength: 150, nullable: true),
                    categoryId = table.Column<byte>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_behavioralViolations", x => x.violationId);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    countryId = table.Column<byte>(nullable: false),
                    countryAr = table.Column<string>(maxLength: 50, nullable: true),
                    countryEn = table.Column<string>(maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.countryId);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    departmentId = table.Column<byte>(nullable: false),
                    departmentNameAr = table.Column<string>(maxLength: 100, nullable: true),
                    departmentNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.departmentId);
                });

            migrationBuilder.CreateTable(
                name: "docTypes",
                columns: table => new
                {
                    docTypeId = table.Column<byte>(nullable: false),
                    docTypeAr = table.Column<string>(maxLength: 50, nullable: true),
                    docTypeEn = table.Column<string>(maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docTypes", x => x.docTypeId);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    jobId = table.Column<short>(nullable: false),
                    jobNameAr = table.Column<string>(maxLength: 100, nullable: true),
                    jobNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    jobDescription = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.jobId);
                });

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    lessonId = table.Column<int>(nullable: false),
                    gradeSubjectId = table.Column<short>(nullable: true),
                    semesterId = table.Column<byte>(nullable: true),
                    lessonTitle = table.Column<string>(maxLength: 150, nullable: true),
                    lessonObjectives = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.lessonId);
                });

            migrationBuilder.CreateTable(
                name: "majors",
                columns: table => new
                {
                    majorId = table.Column<byte>(nullable: false),
                    majorNameAr = table.Column<string>(maxLength: 50, nullable: true),
                    majorNameEn = table.Column<string>(maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_majors", x => x.majorId);
                });

            migrationBuilder.CreateTable(
                name: "remedialProcedures",
                columns: table => new
                {
                    procedureId = table.Column<short>(nullable: false),
                    procedureNameAr = table.Column<string>(maxLength: 150, nullable: true),
                    procedureNameEn = table.Column<string>(maxLength: 150, nullable: true),
                    categoryId = table.Column<byte>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_remedialProcedures", x => x.procedureId);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                columns: table => new
                {
                    schoolID = table.Column<byte>(nullable: false),
                    schoolNameAr = table.Column<string>(maxLength: 150, nullable: true),
                    schoolNameEn = table.Column<string>(maxLength: 150, nullable: true),
                    startDate = table.Column<DateTime>(type: "date", nullable: true),
                    address = table.Column<string>(maxLength: 250, nullable: true),
                    comNum = table.Column<string>(maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.schoolID);
                });

            migrationBuilder.CreateTable(
                name: "userTypes",
                columns: table => new
                {
                    userTypeId = table.Column<byte>(nullable: false),
                    userTypeName = table.Column<string>(maxLength: 25, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTypes", x => x.userTypeId);
                });

            migrationBuilder.CreateTable(
                name: "verificationCodeTypes",
                columns: table => new
                {
                    codeTypeId = table.Column<byte>(nullable: false),
                    codeType = table.Column<string>(maxLength: 25, nullable: true),
                    description = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verificationCodeTypes", x => x.codeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "academicSemesters",
                columns: table => new
                {
                    semesterId = table.Column<byte>(nullable: false),
                    yearId = table.Column<byte>(nullable: true),
                    semesterNameAr = table.Column<string>(maxLength: 25, nullable: true),
                    semesterNameEn = table.Column<string>(maxLength: 25, nullable: true),
                    semesterStartDateG = table.Column<DateTime>(type: "date", nullable: true),
                    semesterStartDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    semesterEndDateG = table.Column<DateTime>(type: "date", nullable: true),
                    semesterEndDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicSemesters", x => x.semesterId);
                    table.ForeignKey(
                        name: "FK_academicSemesters_academicYears",
                        column: x => x.yearId,
                        principalTable: "academicYears",
                        principalColumn: "yearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "jobsActions",
                columns: table => new
                {
                    jobId = table.Column<short>(nullable: false),
                    actionId = table.Column<short>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobsActions", x => new { x.jobId, x.actionId });
                    table.ForeignKey(
                        name: "FK_jobsActions_actions",
                        column: x => x.actionId,
                        principalTable: "actions",
                        principalColumn: "actionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_jobsActions_jobs",
                        column: x => x.jobId,
                        principalTable: "jobs",
                        principalColumn: "jobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lessonsFiles",
                columns: table => new
                {
                    lessonFileId = table.Column<int>(nullable: false),
                    lessonId = table.Column<int>(nullable: true),
                    docTypeId = table.Column<byte>(nullable: true),
                    filePath = table.Column<string>(nullable: true),
                    createdBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    isExternalLink = table.Column<bool>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessonsFiles", x => x.lessonFileId);
                    table.ForeignKey(
                        name: "FK_lessonsFiles_docTypes",
                        column: x => x.docTypeId,
                        principalTable: "docTypes",
                        principalColumn: "docTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lessonsFiles_lessons",
                        column: x => x.lessonId,
                        principalTable: "lessons",
                        principalColumn: "lessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    subjectId = table.Column<byte>(nullable: false),
                    majorId = table.Column<byte>(nullable: true),
                    subjectNameAr = table.Column<string>(maxLength: 25, nullable: true),
                    subjectNameEn = table.Column<string>(maxLength: 25, nullable: true),
                    shortNameAr = table.Column<string>(maxLength: 5, nullable: true),
                    shortNameEn = table.Column<string>(maxLength: 5, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.subjectId);
                    table.ForeignKey(
                        name: "FK_subjects_majors",
                        column: x => x.majorId,
                        principalTable: "majors",
                        principalColumn: "majorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    branchId = table.Column<byte>(nullable: false),
                    branchNameAr = table.Column<string>(maxLength: 8, nullable: true),
                    branchNameEn = table.Column<string>(maxLength: 8, nullable: true),
                    schoolId = table.Column<byte>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.branchId);
                    table.ForeignKey(
                        name: "FK_branches_schools",
                        column: x => x.schoolId,
                        principalTable: "schools",
                        principalColumn: "schoolID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<string>(type: "char(10)", nullable: false),
                    passwordHash = table.Column<string>(maxLength: 50, nullable: true),
                    passwordSalt = table.Column<string>(maxLength: 50, nullable: true),
                    userTypeId = table.Column<byte>(nullable: true),
                    accountStatusId = table.Column<byte>(nullable: true),
                    subscribeDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    lastActive = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_users_accountStatus",
                        column: x => x.accountStatusId,
                        principalTable: "accountStatus",
                        principalColumn: "statusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_userTypes",
                        column: x => x.userTypeId,
                        principalTable: "userTypes",
                        principalColumn: "userTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "academicWeeks",
                columns: table => new
                {
                    weekId = table.Column<short>(nullable: false),
                    semesterId = table.Column<byte>(nullable: true),
                    weekNameAr = table.Column<string>(maxLength: 25, nullable: true),
                    weekNameEn = table.Column<string>(maxLength: 25, nullable: true),
                    weekStartDateG = table.Column<DateTime>(type: "date", nullable: true),
                    weekStartDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    WeekEndDateG = table.Column<DateTime>(type: "date", nullable: true),
                    WeekEndDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicWeeks", x => x.weekId);
                    table.ForeignKey(
                        name: "FK_academicWeeks_academicSemesters",
                        column: x => x.semesterId,
                        principalTable: "academicSemesters",
                        principalColumn: "semesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stages",
                columns: table => new
                {
                    stageId = table.Column<byte>(nullable: false),
                    branchId = table.Column<byte>(nullable: true),
                    stageNameAr = table.Column<string>(maxLength: 25, nullable: true),
                    stageNameEn = table.Column<string>(maxLength: 25, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stages", x => x.stageId);
                    table.ForeignKey(
                        name: "FK_stages_branches",
                        column: x => x.branchId,
                        principalTable: "branches",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    empId = table.Column<string>(type: "char(10)", nullable: false),
                    fNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    mNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    gNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    lNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    fNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    mNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    gNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    lNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    gender = table.Column<bool>(nullable: true),
                    IdType = table.Column<byte>(nullable: true),
                    IdIssuePlace = table.Column<string>(maxLength: 50, nullable: true),
                    IdExpireDateG = table.Column<DateTime>(type: "date", nullable: true),
                    idExpireDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    countryId = table.Column<byte>(nullable: true),
                    mobile = table.Column<string>(maxLength: 15, nullable: true),
                    mobile2 = table.Column<string>(maxLength: 15, nullable: true),
                    phone = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    birthDateG = table.Column<DateTime>(type: "date", nullable: true),
                    birthDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    birthPlace = table.Column<string>(maxLength: 50, nullable: true),
                    maritalStatus = table.Column<string>(maxLength: 10, nullable: true),
                    religion = table.Column<string>(maxLength: 15, nullable: true),
                    passportNum = table.Column<string>(maxLength: 15, nullable: true),
                    passpoerExpireDateG = table.Column<DateTime>(type: "date", nullable: true),
                    passpoerExpireDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    addressKsa = table.Column<string>(nullable: true),
                    addressHome = table.Column<string>(nullable: true),
                    certificateDegree = table.Column<byte>(nullable: true),
                    certificateName = table.Column<string>(nullable: true),
                    certificateDate = table.Column<string>(type: "nchar(7)", nullable: true),
                    certificateGrade = table.Column<byte>(nullable: true),
                    certificateMajor = table.Column<string>(maxLength: 50, nullable: true),
                    relativeName = table.Column<string>(maxLength: 60, nullable: true),
                    relativeAddress = table.Column<string>(nullable: true),
                    relativeMobile = table.Column<string>(maxLength: 15, nullable: true),
                    relativePhone = table.Column<string>(maxLength: 15, nullable: true),
                    poBox = table.Column<string>(maxLength: 10, nullable: true),
                    poCode = table.Column<string>(maxLength: 10, nullable: true),
                    hasDrivingLicense = table.Column<bool>(nullable: true),
                    isHandicapped = table.Column<bool>(nullable: true),
                    specialNeeds = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.empId);
                    table.ForeignKey(
                        name: "FK_employees_countries",
                        column: x => x.countryId,
                        principalTable: "countries",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employees_users",
                        column: x => x.empId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "parents",
                columns: table => new
                {
                    parentId = table.Column<string>(type: "char(10)", nullable: false),
                    fNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    mNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    gNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    lNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    fNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    mNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    gNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    lNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    IdType = table.Column<byte>(nullable: true),
                    IdIssuePlace = table.Column<string>(maxLength: 50, nullable: true),
                    IdExpireDateG = table.Column<DateTime>(type: "date", nullable: true),
                    idExpireDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    mobile1 = table.Column<string>(maxLength: 15, nullable: true),
                    mobile2 = table.Column<string>(maxLength: 15, nullable: true),
                    countryId = table.Column<byte>(maxLength: 15, nullable: true),
                    phone = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    houseNum = table.Column<string>(maxLength: 5, nullable: true),
                    street = table.Column<string>(nullable: true),
                    district = table.Column<string>(nullable: true),
                    cityId = table.Column<byte>(nullable: true),
                    job = table.Column<string>(nullable: true),
                    workAddress = table.Column<string>(nullable: true),
                    workPhone = table.Column<string>(maxLength: 15, nullable: true),
                    relativeName = table.Column<string>(maxLength: 60, nullable: true),
                    relativeMobile = table.Column<string>(maxLength: 15, nullable: true),
                    relativePhone = table.Column<string>(maxLength: 15, nullable: true),
                    relativeAddress = table.Column<string>(nullable: true),
                    relativeRelation = table.Column<string>(maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parents", x => x.parentId);
                    table.ForeignKey(
                        name: "FK_parents_countries",
                        column: x => x.countryId,
                        principalTable: "countries",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_parents_users",
                        column: x => x.parentId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "refreshTokens",
                columns: table => new
                {
                    tokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    token = table.Column<string>(maxLength: 32, nullable: true),
                    deviceInfo = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    userId = table.Column<string>(maxLength: 10, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshTokens", x => x.tokenId);
                    table.ForeignKey(
                        name: "FK_users_refreshTokens",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usersDocs",
                columns: table => new
                {
                    userDocId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(type: "char(10)", nullable: false),
                    docTypeId = table.Column<byte>(nullable: false),
                    filePath = table.Column<string>(maxLength: 15, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersDocs", x => x.userDocId);
                    table.ForeignKey(
                        name: "FK_usersDocs_docTypes",
                        column: x => x.docTypeId,
                        principalTable: "docTypes",
                        principalColumn: "docTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usersDocs_users",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "verificationCodes",
                columns: table => new
                {
                    codeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(maxLength: 10, nullable: true),
                    sentTime = table.Column<DateTime>(nullable: false),
                    codeTypeId = table.Column<byte>(nullable: true),
                    userId = table.Column<string>(maxLength: 10, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verificationCodes", x => x.codeId);
                    table.ForeignKey(
                        name: "FK_verificationCodeTypes_verificationCodes",
                        column: x => x.codeTypeId,
                        principalTable: "verificationCodeTypes",
                        principalColumn: "codeTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_verificationCodes",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    gradeId = table.Column<byte>(nullable: false),
                    stageId = table.Column<byte>(nullable: true),
                    gradeNameAr = table.Column<string>(maxLength: 25, nullable: true),
                    gradeNameEn = table.Column<string>(maxLength: 25, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => x.gradeId);
                    table.ForeignKey(
                        name: "FK_grades_stages",
                        column: x => x.stageId,
                        principalTable: "stages",
                        principalColumn: "stageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schoolDayEvents",
                columns: table => new
                {
                    schoolDayEventId = table.Column<short>(nullable: false),
                    dayId = table.Column<byte>(nullable: true),
                    stageId = table.Column<byte>(nullable: true),
                    eventNameAr = table.Column<string>(maxLength: 50, nullable: true),
                    eventNameEn = table.Column<string>(maxLength: 50, nullable: true),
                    startTime = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    endTime = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolDayEvents", x => x.schoolDayEventId);
                    table.ForeignKey(
                        name: "FK_schoolDayEvents_stages",
                        column: x => x.stageId,
                        principalTable: "stages",
                        principalColumn: "stageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employeesFinance",
                columns: table => new
                {
                    empId = table.Column<string>(type: "char(10)", nullable: false),
                    bankName = table.Column<string>(maxLength: 50, nullable: true),
                    bankAccount = table.Column<string>(maxLength: 50, nullable: true),
                    bankIban = table.Column<string>(maxLength: 50, nullable: true),
                    basicSalary = table.Column<decimal>(type: "smallmoney", nullable: true),
                    housingAllowance = table.Column<decimal>(type: "smallmoney", nullable: true),
                    experienceAllowance = table.Column<decimal>(type: "smallmoney", nullable: true),
                    transportAllowance = table.Column<decimal>(type: "smallmoney", nullable: true),
                    otherAllowance = table.Column<decimal>(type: "smallmoney", nullable: true),
                    totalSalary = table.Column<decimal>(type: "smallmoney", nullable: true),
                    loans = table.Column<decimal>(type: "smallmoney", nullable: true),
                    debts = table.Column<decimal>(type: "smallmoney", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesFinance", x => x.empId);
                    table.ForeignKey(
                        name: "FK_employeesFinance_employees",
                        column: x => x.empId,
                        principalTable: "employees",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employeesHR",
                columns: table => new
                {
                    empId = table.Column<string>(type: "char(10)", nullable: false),
                    jobInId = table.Column<string>(maxLength: 50, nullable: true),
                    contractType = table.Column<string>(maxLength: 15, nullable: true),
                    socialSecuritySubscription = table.Column<bool>(nullable: true),
                    socialSecurityNum = table.Column<int>(nullable: true),
                    ceoApproval = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    SalahiaNum = table.Column<int>(nullable: true),
                    SalahiaDateG = table.Column<DateTime>(type: "date", nullable: true),
                    SalahiaDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    wrokStartDateG = table.Column<DateTime>(type: "date", nullable: true),
                    workStartDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    noorRegistered = table.Column<bool>(nullable: true),
                    workStatus = table.Column<byte>(nullable: true),
                    hrNotes = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesHR", x => x.empId);
                    table.ForeignKey(
                        name: "FK_EmployeesHR_employees",
                        column: x => x.empId,
                        principalTable: "employees",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employeesJobs",
                columns: table => new
                {
                    empJobId = table.Column<int>(nullable: false),
                    empId = table.Column<string>(type: "char(10)", nullable: false),
                    jobId = table.Column<short>(nullable: false),
                    branchId = table.Column<byte>(nullable: true),
                    departmentId = table.Column<byte>(nullable: true),
                    startDate = table.Column<DateTime>(type: "date", nullable: true),
                    endDate = table.Column<DateTime>(type: "date", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesJobs", x => x.empJobId);
                    table.ForeignKey(
                        name: "FK_employeesJobs_departments",
                        column: x => x.departmentId,
                        principalTable: "departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employeesJobs_employees",
                        column: x => x.empId,
                        principalTable: "employees",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employeesJobs_jobs",
                        column: x => x.jobId,
                        principalTable: "jobs",
                        principalColumn: "jobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    studentId = table.Column<string>(type: "char(10)", nullable: false),
                    parentId = table.Column<string>(type: "char(10)", nullable: true),
                    fNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    mNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    gNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    lNameAr = table.Column<string>(maxLength: 20, nullable: true),
                    fNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    mNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    gNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    lNameEn = table.Column<string>(maxLength: 20, nullable: true),
                    gender = table.Column<bool>(nullable: true),
                    IdType = table.Column<byte>(nullable: true),
                    IdIssuePlace = table.Column<string>(maxLength: 50, nullable: true),
                    IdExpireDateG = table.Column<DateTime>(type: "date", nullable: true),
                    idExpireDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    mobile = table.Column<string>(maxLength: 15, nullable: true),
                    mobileMother = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    birthDateG = table.Column<DateTime>(type: "date", nullable: true),
                    birthDateH = table.Column<string>(type: "nchar(10)", nullable: true),
                    birthPlace = table.Column<string>(maxLength: 50, nullable: true),
                    specialNeeds = table.Column<string>(nullable: true),
                    previousSchool = table.Column<string>(maxLength: 100, nullable: true),
                    countryId = table.Column<byte>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_students_countries",
                        column: x => x.countryId,
                        principalTable: "countries",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_students_parents",
                        column: x => x.parentId,
                        principalTable: "parents",
                        principalColumn: "parentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_students_users",
                        column: x => x.studentId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "classrooms",
                columns: table => new
                {
                    classroomId = table.Column<short>(nullable: false),
                    gradeId = table.Column<byte>(nullable: true),
                    classNameAr = table.Column<string>(maxLength: 25, nullable: true),
                    classNameEn = table.Column<string>(maxLength: 25, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classrooms", x => x.classroomId);
                    table.ForeignKey(
                        name: "FK_classrooms_grades",
                        column: x => x.gradeId,
                        principalTable: "grades",
                        principalColumn: "gradeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gradesSubjects",
                columns: table => new
                {
                    gradeSubjectId = table.Column<short>(nullable: false),
                    gradeId = table.Column<byte>(nullable: false),
                    subjectId = table.Column<byte>(nullable: false),
                    periodsCount = table.Column<byte>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradesSubjects", x => x.gradeSubjectId);
                    table.ForeignKey(
                        name: "FK_gradesSubjects_grades",
                        column: x => x.gradeId,
                        principalTable: "grades",
                        principalColumn: "gradeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gradesSubjects_subjects",
                        column: x => x.subjectId,
                        principalTable: "subjects",
                        principalColumn: "subjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employeesActions",
                columns: table => new
                {
                    empJobId = table.Column<int>(nullable: false),
                    actionId = table.Column<short>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesActions", x => new { x.empJobId, x.actionId });
                    table.ForeignKey(
                        name: "FK_employeesActions_actions",
                        column: x => x.actionId,
                        principalTable: "actions",
                        principalColumn: "actionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employeesActions_employeesJobs",
                        column: x => x.empJobId,
                        principalTable: "employeesJobs",
                        principalColumn: "empJobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teachersQuorums",
                columns: table => new
                {
                    teacherQuorumId = table.Column<int>(nullable: false),
                    empJobId = table.Column<int>(nullable: true),
                    semesterId = table.Column<byte>(nullable: true),
                    periodsQuorum = table.Column<byte>(nullable: true),
                    substituteQuorum = table.Column<byte>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachersQuorums", x => x.teacherQuorumId);
                    table.ForeignKey(
                        name: "FK_teachersQuorums_employeesJobs",
                        column: x => x.empJobId,
                        principalTable: "employeesJobs",
                        principalColumn: "empJobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teachersQuorums_academicSemesters",
                        column: x => x.semesterId,
                        principalTable: "academicSemesters",
                        principalColumn: "semesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "studentsViolations",
                columns: table => new
                {
                    studentViolationId = table.Column<int>(nullable: false),
                    studentId = table.Column<string>(type: "char(10)", nullable: true),
                    violationId = table.Column<short>(nullable: true),
                    empJobId = table.Column<int>(nullable: true),
                    violationDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsViolations", x => x.studentViolationId);
                    table.ForeignKey(
                        name: "FK_studentsViolations_employeesJobs",
                        column: x => x.empJobId,
                        principalTable: "employeesJobs",
                        principalColumn: "empJobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studentsViolations_students",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studentsViolations_behavioralViolations",
                        column: x => x.violationId,
                        principalTable: "behavioralViolations",
                        principalColumn: "violationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "classesStudents",
                columns: table => new
                {
                    classStudentId = table.Column<int>(nullable: false),
                    studentId = table.Column<string>(type: "char(10)", nullable: false),
                    yearId = table.Column<byte>(nullable: true),
                    classroomId = table.Column<short>(nullable: true),
                    startDate = table.Column<DateTime>(type: "date", nullable: true),
                    endDate = table.Column<DateTime>(type: "date", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classesStudents", x => x.classStudentId);
                    table.ForeignKey(
                        name: "FK_classesStudents_classrooms",
                        column: x => x.classroomId,
                        principalTable: "classrooms",
                        principalColumn: "classroomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_classesStudents_students",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_classesStudents_academicYears",
                        column: x => x.yearId,
                        principalTable: "academicYears",
                        principalColumn: "yearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "periods",
                columns: table => new
                {
                    periodId = table.Column<int>(nullable: false),
                    semesterId = table.Column<byte>(nullable: true),
                    classeroomId = table.Column<short>(nullable: true),
                    gradeSubjectId = table.Column<short>(nullable: true),
                    empJobId = table.Column<int>(nullable: true),
                    schoolDayEventId = table.Column<short>(nullable: true),
                    periodDate = table.Column<DateTime>(type: "date", nullable: true),
                    startTime = table.Column<TimeSpan>(nullable: true),
                    endTime = table.Column<TimeSpan>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periods", x => x.periodId);
                    table.ForeignKey(
                        name: "FK_periods_classrooms",
                        column: x => x.classeroomId,
                        principalTable: "classrooms",
                        principalColumn: "classroomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_periods_employeesJobs",
                        column: x => x.empJobId,
                        principalTable: "employeesJobs",
                        principalColumn: "empJobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_periods_gradesSubjects",
                        column: x => x.gradeSubjectId,
                        principalTable: "gradesSubjects",
                        principalColumn: "gradeSubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_periods_schoolDayEvents",
                        column: x => x.schoolDayEventId,
                        principalTable: "schoolDayEvents",
                        principalColumn: "schoolDayEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_periods_academicSemesters",
                        column: x => x.semesterId,
                        principalTable: "academicSemesters",
                        principalColumn: "semesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teachersEdu",
                columns: table => new
                {
                    empJobId = table.Column<int>(nullable: false),
                    gradeSubjectId = table.Column<short>(nullable: false),
                    classroomIds = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachersEdu", x => new { x.empJobId, x.gradeSubjectId });
                    table.ForeignKey(
                        name: "FK_teachersEdu_employeesJobs",
                        column: x => x.empJobId,
                        principalTable: "employeesJobs",
                        principalColumn: "empJobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teachersEdu_gradesSubjects",
                        column: x => x.gradeSubjectId,
                        principalTable: "gradesSubjects",
                        principalColumn: "gradeSubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "timeTables",
                columns: table => new
                {
                    timeTableId = table.Column<int>(nullable: false),
                    classroomId = table.Column<short>(nullable: false),
                    schoolDayEventId = table.Column<short>(nullable: false),
                    gradeSubjectId = table.Column<short>(nullable: true),
                    empJobId = table.Column<int>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timeTables", x => x.timeTableId);
                    table.ForeignKey(
                        name: "FK_timeTable_employeesJobs",
                        column: x => x.empJobId,
                        principalTable: "employeesJobs",
                        principalColumn: "empJobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_timeTable_gradesSubjects",
                        column: x => x.gradeSubjectId,
                        principalTable: "gradesSubjects",
                        principalColumn: "gradeSubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_timeTable_schoolDayEvents",
                        column: x => x.schoolDayEventId,
                        principalTable: "schoolDayEvents",
                        principalColumn: "schoolDayEventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "studentsProcedures",
                columns: table => new
                {
                    studentProcedureId = table.Column<int>(nullable: false),
                    studentViolationId = table.Column<int>(nullable: true),
                    empJobId = table.Column<int>(nullable: true),
                    procedureId = table.Column<short>(nullable: true),
                    procedureDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsProcedures", x => x.studentProcedureId);
                    table.ForeignKey(
                        name: "FK_studentsProcedures_employeesJobs",
                        column: x => x.empJobId,
                        principalTable: "employeesJobs",
                        principalColumn: "empJobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studentsProcedures_remedialProcedures",
                        column: x => x.procedureId,
                        principalTable: "remedialProcedures",
                        principalColumn: "procedureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studentsProcedures_studentsViolations",
                        column: x => x.studentViolationId,
                        principalTable: "studentsViolations",
                        principalColumn: "studentViolationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "periodsDetails",
                columns: table => new
                {
                    periodDetailId = table.Column<long>(nullable: false),
                    periodId = table.Column<int>(nullable: true),
                    studentId = table.Column<string>(type: "char(10)", nullable: true),
                    attandanceTime = table.Column<TimeSpan>(nullable: true),
                    leaveTime = table.Column<TimeSpan>(nullable: true),
                    isEalryExit = table.Column<bool>(nullable: true),
                    homeworkRate = table.Column<byte>(nullable: true),
                    participationsCount = table.Column<byte>(nullable: true),
                    participationsQuality = table.Column<byte>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodsDetails", x => x.periodDetailId);
                    table.ForeignKey(
                        name: "FK_periodsDetails_periods",
                        column: x => x.periodId,
                        principalTable: "periods",
                        principalColumn: "periodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_periodsDetails_students",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "weeksPlans",
                columns: table => new
                {
                    weekPlanId = table.Column<short>(nullable: false),
                    weekId = table.Column<short>(nullable: true),
                    timeTableId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    lessonId = table.Column<int>(nullable: true),
                    homework = table.Column<string>(nullable: true),
                    quiz = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weeksPlans", x => x.weekPlanId);
                    table.ForeignKey(
                        name: "FK_weeksPlans_lessons",
                        column: x => x.lessonId,
                        principalTable: "lessons",
                        principalColumn: "lessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_weeksPlans_timeTable",
                        column: x => x.timeTableId,
                        principalTable: "timeTables",
                        principalColumn: "timeTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_weeksPlans_academicWeeks",
                        column: x => x.weekId,
                        principalTable: "academicWeeks",
                        principalColumn: "weekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "periodsFiles",
                columns: table => new
                {
                    periodFileId = table.Column<int>(nullable: false),
                    docTypeId = table.Column<byte>(nullable: true),
                    weekPlanId = table.Column<short>(nullable: true),
                    filePath = table.Column<string>(nullable: true),
                    createdBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    isExternalLink = table.Column<bool>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodsFiles", x => x.periodFileId);
                    table.ForeignKey(
                        name: "FK_periodsFiles_docTypes",
                        column: x => x.docTypeId,
                        principalTable: "docTypes",
                        principalColumn: "docTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_periodsFiles_weeksPlans",
                        column: x => x.weekPlanId,
                        principalTable: "weeksPlans",
                        principalColumn: "weekPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_academicSemesters_yearId",
                table: "academicSemesters",
                column: "yearId");

            migrationBuilder.CreateIndex(
                name: "IX_academicWeeks_semesterId",
                table: "academicWeeks",
                column: "semesterId");

            migrationBuilder.CreateIndex(
                name: "IX_branches_schoolId",
                table: "branches",
                column: "schoolId");

            migrationBuilder.CreateIndex(
                name: "IX_classesStudents_classroomId",
                table: "classesStudents",
                column: "classroomId");

            migrationBuilder.CreateIndex(
                name: "IX_classesStudents_studentId",
                table: "classesStudents",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_classesStudents_yearId",
                table: "classesStudents",
                column: "yearId");

            migrationBuilder.CreateIndex(
                name: "IX_classrooms_gradeId",
                table: "classrooms",
                column: "gradeId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_countryId",
                table: "employees",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_employeesActions_actionId",
                table: "employeesActions",
                column: "actionId");

            migrationBuilder.CreateIndex(
                name: "IX_employeesJobs_departmentId",
                table: "employeesJobs",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_employeesJobs_empId",
                table: "employeesJobs",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_employeesJobs_jobId",
                table: "employeesJobs",
                column: "jobId");

            migrationBuilder.CreateIndex(
                name: "IX_grades_stageId",
                table: "grades",
                column: "stageId");

            migrationBuilder.CreateIndex(
                name: "IX_gradesSubjects_subjectId",
                table: "gradesSubjects",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "ucGradeSubject",
                table: "gradesSubjects",
                columns: new[] { "gradeId", "subjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_jobsActions_actionId",
                table: "jobsActions",
                column: "actionId");

            migrationBuilder.CreateIndex(
                name: "IX_lessonsFiles_docTypeId",
                table: "lessonsFiles",
                column: "docTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_lessonsFiles_lessonId",
                table: "lessonsFiles",
                column: "lessonId");

            migrationBuilder.CreateIndex(
                name: "IX_parents_countryId",
                table: "parents",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_periods_classeroomId",
                table: "periods",
                column: "classeroomId");

            migrationBuilder.CreateIndex(
                name: "IX_periods_empJobId",
                table: "periods",
                column: "empJobId");

            migrationBuilder.CreateIndex(
                name: "IX_periods_gradeSubjectId",
                table: "periods",
                column: "gradeSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_periods_schoolDayEventId",
                table: "periods",
                column: "schoolDayEventId");

            migrationBuilder.CreateIndex(
                name: "IX_periods_semesterId",
                table: "periods",
                column: "semesterId");

            migrationBuilder.CreateIndex(
                name: "IX_periodsDetails_periodId",
                table: "periodsDetails",
                column: "periodId");

            migrationBuilder.CreateIndex(
                name: "IX_periodsDetails_studentId",
                table: "periodsDetails",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_periodsFiles_docTypeId",
                table: "periodsFiles",
                column: "docTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_periodsFiles_weekPlanId",
                table: "periodsFiles",
                column: "weekPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_userId",
                table: "refreshTokens",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_schoolDayEvents_stageId",
                table: "schoolDayEvents",
                column: "stageId");

            migrationBuilder.CreateIndex(
                name: "IX_stages_branchId",
                table: "stages",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_students_countryId",
                table: "students",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_students_parentId",
                table: "students",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsProcedures_empJobId",
                table: "studentsProcedures",
                column: "empJobId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsProcedures_procedureId",
                table: "studentsProcedures",
                column: "procedureId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsProcedures_studentViolationId",
                table: "studentsProcedures",
                column: "studentViolationId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsViolations_empJobId",
                table: "studentsViolations",
                column: "empJobId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsViolations_studentId",
                table: "studentsViolations",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsViolations_violationId",
                table: "studentsViolations",
                column: "violationId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_majorId",
                table: "subjects",
                column: "majorId");

            migrationBuilder.CreateIndex(
                name: "IX_teachersEdu_gradeSubjectId",
                table: "teachersEdu",
                column: "gradeSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_teachersQuorums_empJobId",
                table: "teachersQuorums",
                column: "empJobId");

            migrationBuilder.CreateIndex(
                name: "IX_teachersQuorums_semesterId",
                table: "teachersQuorums",
                column: "semesterId");

            migrationBuilder.CreateIndex(
                name: "IX_timeTables_empJobId",
                table: "timeTables",
                column: "empJobId");

            migrationBuilder.CreateIndex(
                name: "IX_timeTables_gradeSubjectId",
                table: "timeTables",
                column: "gradeSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_timeTables_schoolDayEventId",
                table: "timeTables",
                column: "schoolDayEventId");

            migrationBuilder.CreateIndex(
                name: "IX_users_accountStatusId",
                table: "users",
                column: "accountStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_users_userTypeId",
                table: "users",
                column: "userTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_usersDocs_docTypeId",
                table: "usersDocs",
                column: "docTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_usersDocs_userId",
                table: "usersDocs",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_verificationCodes_codeTypeId",
                table: "verificationCodes",
                column: "codeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_verificationCodes_userId",
                table: "verificationCodes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_weeksPlans_lessonId",
                table: "weeksPlans",
                column: "lessonId");

            migrationBuilder.CreateIndex(
                name: "IX_weeksPlans_timeTableId",
                table: "weeksPlans",
                column: "timeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_weeksPlans_weekId",
                table: "weeksPlans",
                column: "weekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classesStudents");

            migrationBuilder.DropTable(
                name: "employeesActions");

            migrationBuilder.DropTable(
                name: "employeesFinance");

            migrationBuilder.DropTable(
                name: "employeesHR");

            migrationBuilder.DropTable(
                name: "jobsActions");

            migrationBuilder.DropTable(
                name: "lessonsFiles");

            migrationBuilder.DropTable(
                name: "periodsDetails");

            migrationBuilder.DropTable(
                name: "periodsFiles");

            migrationBuilder.DropTable(
                name: "refreshTokens");

            migrationBuilder.DropTable(
                name: "studentsProcedures");

            migrationBuilder.DropTable(
                name: "teachersEdu");

            migrationBuilder.DropTable(
                name: "teachersQuorums");

            migrationBuilder.DropTable(
                name: "usersDocs");

            migrationBuilder.DropTable(
                name: "verificationCodes");

            migrationBuilder.DropTable(
                name: "actions");

            migrationBuilder.DropTable(
                name: "periods");

            migrationBuilder.DropTable(
                name: "weeksPlans");

            migrationBuilder.DropTable(
                name: "remedialProcedures");

            migrationBuilder.DropTable(
                name: "studentsViolations");

            migrationBuilder.DropTable(
                name: "docTypes");

            migrationBuilder.DropTable(
                name: "verificationCodeTypes");

            migrationBuilder.DropTable(
                name: "classrooms");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "timeTables");

            migrationBuilder.DropTable(
                name: "academicWeeks");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "behavioralViolations");

            migrationBuilder.DropTable(
                name: "employeesJobs");

            migrationBuilder.DropTable(
                name: "gradesSubjects");

            migrationBuilder.DropTable(
                name: "schoolDayEvents");

            migrationBuilder.DropTable(
                name: "academicSemesters");

            migrationBuilder.DropTable(
                name: "parents");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "grades");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "academicYears");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "stages");

            migrationBuilder.DropTable(
                name: "majors");

            migrationBuilder.DropTable(
                name: "accountStatus");

            migrationBuilder.DropTable(
                name: "userTypes");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "schools");
        }
    }
}
