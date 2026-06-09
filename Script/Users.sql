create table dbo.Users
(
    UserId       uniqueidentifier not null
        constraint PK_Users
            primary key,
    Username     nvarchar(max)    not null,
    PasswordHash nvarchar(max)    not null,
    Role         nvarchar(max)    not null,
    IsActive     bit              not null,
    CreatedOn    datetime2        not null,
    CreatedBy    nvarchar(max),
    ModifiedOn   datetime2,
    ModifiedBy   nvarchar(max)
)
go

INSERT INTO SecureEmployeeManagementDb.dbo.Users (UserId, Username, PasswordHash, Role, IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) VALUES (N'6c14163c-95d7-4aff-a8d5-f66827a97e12', N'Morris', N'$2a$11$/MmfXy.bVhgQqM4r8lDbe.bsB8nQLzJC11C5WGusleIP6i4YP4az2', N'Admin', 1, N'2026-06-08 21:12:49.7600000', null, null, null);
INSERT INTO SecureEmployeeManagementDb.dbo.Users (UserId, Username, PasswordHash, Role, IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) VALUES (N'7c14163c-95d7-4aff-a8d5-f66827a97e12', N'Dc', N'$2a$11$/MmfXy.bVhgQqM4r8lDbe.bsB8nQLzJC11C5WGusleIP6i4YP4az2', N'User', 1, N'2026-06-08 21:12:49.7600000', null, null, null);
