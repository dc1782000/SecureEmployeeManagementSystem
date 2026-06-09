create table dbo.Employees
(
    EmployeeId   uniqueidentifier not null
        constraint PK_Employees
            primary key,
    EmployeeCode nvarchar(max)    not null,
    FirstName    nvarchar(max)    not null,
    LastName     nvarchar(max)    not null,
    Email        nvarchar(max)    not null,
    Department   nvarchar(max)    not null,
    Designation  nvarchar(max)    not null,
    JoiningDate  datetime2        not null,
    IsActive     bit              not null,
    CreatedOn    datetime2        not null,
    CreatedBy    nvarchar(max),
    ModifiedOn   datetime2,
    ModifiedBy   nvarchar(max)
)
go

INSERT INTO SecureEmployeeManagementDb.dbo.Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, Department, Designation, JoiningDate, IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) VALUES (N'0b478229-e0d8-4e80-a39f-06a1002813da', N'EMP003', N'Manoj', N'Singh', N'rahul@test.com', N'IT', N'Backend Dev', N'2026-06-09 00:00:00.0000000', 1, N'2026-06-09 02:02:03.7027460', N'Morris', N'2026-06-09 02:14:06.1543870', N'SYSTEM');
INSERT INTO SecureEmployeeManagementDb.dbo.Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, Department, Designation, JoiningDate, IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) VALUES (N'acfb1b13-cdc2-4bb5-aed8-35b9fecf6646', N'EMP011', N'Dinesh Chandra', N'Sharma', N'ds49472@gmail.com', N'IT', N'SDE', N'2026-06-10 00:00:00.0000000', 1, N'2026-06-09 02:26:07.5835580', N'Morris', N'2026-06-09 04:30:58.9417580', N'Morris');
INSERT INTO SecureEmployeeManagementDb.dbo.Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, Department, Designation, JoiningDate, IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) VALUES (N'250c76c7-309e-44fa-9c08-4e75e1752eeb', N'EMP005', N'David', N'Poll', N'David@gmail.com', N'HR', N'Senior HR', N'2026-06-24 00:00:00.0000000', 0, N'2026-06-09 04:28:01.2921020', N'Morris', N'2026-06-09 04:28:19.1377730', N'Morris');
INSERT INTO SecureEmployeeManagementDb.dbo.Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, Department, Designation, JoiningDate, IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) VALUES (N'dc04e149-03e3-48e4-8924-6d786de737ed', N'EMP001', N'Rishi', N'Sunak', N'rishi007@Yoopmail.com', N'HR', N'junior HR', N'2026-05-05 00:00:00.0000000', 0, N'2026-06-09 04:29:13.6564520', N'Morris', null, null);
INSERT INTO SecureEmployeeManagementDb.dbo.Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, Department, Designation, JoiningDate, IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) VALUES (N'5290144d-1b86-47f6-9f38-7228a8e86b5a', N'EMP002', N'Pankaj', N'Pathak', N'pk79@yoopmail.com', N'HR', N'Manager', N'2025-06-08 00:00:00.0000000', 1, N'2026-06-09 04:58:42.9791810', N'Morris', N'2026-06-09 04:59:10.6349270', N'Morris');
